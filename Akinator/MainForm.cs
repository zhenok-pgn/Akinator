using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Akinator
{
    enum PlayerAnswer
    {
        Да,
        Нет
    }

    public partial class MainForm : Form
    {
        private KnowledgeBase knowledgeBase;
        private bool isFileSaved;
        private bool isTrainingMode;
        private bool isWordValidCheckingMode;
        public MainForm()
        {
            knowledgeBase = new KnowledgeBase();
            isFileSaved = true;
            InitializeComponent();
            Text = ThemeName.Plural;
            ManagePlayerInterface(false);
        }
        private void PrintProgrammResponse(string response = null)
        {
            if(response == null)
                dialogTextBox.Text += $"Программа: Это {ThemeName.Singular.ToLower()}?\n";
            else
                dialogTextBox.Text += "Программа: " + response + '\n';
        }

        private void PrintPlayerResponse(PlayerAnswer answer)
        {
            dialogTextBox.Text += "Игрок: " + answer + '\n';
        }
        private void WrongWordHandler()
        {
            dialogTextBox.Text += $"Программа: Я угадываю только {ThemeName.Plural.ToLower()}. Пожалуйста, загадайте другое слово\n";
            ManagePlayerInterface(false);

        }
        private void ManagePlayerInterface(bool isEnable)
        {
            guessWordPanel.Enabled = !isEnable;
            showBaseButton.Enabled = !isEnable;
            panel1.Enabled = !isEnable;
            whyThisAnswerButton.Visible = !Enabled;
            dialogPanel.Enabled = isEnable;
            cancelButton.Enabled = isEnable;
        }
        private void InitializeTrainingMode()
        {
            isTrainingMode = true;
            dialogPanel.Enabled = false;
            addQuestionPanel.Visible = true;
            dialogTextBox.Text += "Программа: Сдаюсь\n" + 
                "Программа: Переход в режим обучения\n" +
                $"Программа: Правильный ответ: {guessTextBox.Text}\n" +
                $"Программа: Сформулируйте вопрос, ответ на который поможет отличить '{guessTextBox.Text}' от '{knowledgeBase.Current.Value}'\n";
            
        }
        private void ContinueTrainingMode()
        {
            dialogPanel.Enabled = true;
            addQuestionPanel.Visible = false;
            dialogTextBox.Text += "Программа: Подскажите вариант правильного ответа: да или нет\n";
        }
        private void ExitTrainingMode(PlayerAnswer answer)
        {
            isTrainingMode = false;
            ManagePlayerInterface(false);
            // добавить ответ в базу знаний
            knowledgeBase.AddObject(playerQuestionTextBox.Text, answer == 0, guessTextBox.Text);
            isFileSaved = false;
            dialogTextBox.Text += "Программа: Спасибо!" + '\n';
        }

        private void StartGuessingButtonClick(object sender, EventArgs e)
        {
            if (guessTextBox.Text == "")
            {
                MessageBox.Show("Поле для ввода слова пустое");
                return;
            }

            dialogTextBox.Text += "========== Начало игры ==========\n";
            isWordValidCheckingMode = true;
            ManagePlayerInterface(true);
            PrintProgrammResponse();
        }

        private void YesButtonClick(object sender, EventArgs e)
        {
            PrintPlayerResponse(PlayerAnswer.Да);

            if (isWordValidCheckingMode)
            {
                isWordValidCheckingMode = false;
                var response = knowledgeBase.GetInitialResponse(guessTextBox.Text);
                PrintProgrammResponse(response);
                if(response == guessTextBox.Text.ToLower())
                {
                    PrintPlayerResponse(PlayerAnswer.Да);
                    ManagePlayerInterface(false);
                    isFileSaved = false;
                }
                return;
            }

            if (isTrainingMode)
            {
                ExitTrainingMode(PlayerAnswer.Да);
                return;
            }
            
            var knowledgeBaseResponse = knowledgeBase.GetResponseIfYes();

            if(knowledgeBaseResponse == null)
            {
                ManagePlayerInterface(false);
                whyThisAnswerButton.Visible = true;
                return;
            }
            PrintProgrammResponse(knowledgeBaseResponse);
        }

        private void NoButtonClick(object sender, EventArgs e)
        {
            PrintPlayerResponse(PlayerAnswer.Нет);

            if (isWordValidCheckingMode)
            {
                WrongWordHandler();
                return;
            }

            if (isTrainingMode)
            {
                ExitTrainingMode(PlayerAnswer.Нет);
                return;
            }
            
            var knowledgeBaseResponse = knowledgeBase.GetResponseIfNo();
            if (knowledgeBaseResponse == null)
            {
                InitializeTrainingMode();
                return;
            }
            PrintProgrammResponse(knowledgeBaseResponse);
        }

        private void SendQuestionButtonClick(object sender, EventArgs e)
        {
            ContinueTrainingMode();
        }

        private void ShowBaseButtonClick(object sender, EventArgs e)
        {
            dialogTextBox.Text += "Игрок: Покажи всю базу знаний\n";
            dialogTextBox.Text += $"Программа: Вывожу базу знаний...\n";

            if(knowledgeBase.ToBinaryTreeRepresentation == null)
            {
                MessageBox.Show("База знаний пока пустая");
                return;
            }

            new BinaryTreeVisualizeForm(knowledgeBase.ToBinaryTreeRepresentation).ShowDialog();
        }

        private void WhyThisAnswerButtonClick(object sender, EventArgs e)
        {
            whyThisAnswerButton.Visible = false;
            dialogTextBox.Text += "Игрок: Почему такой ответ?\n";
            dialogTextBox.Text += $"Программа: {knowledgeBase.GetAnswerAnalisys()}\n";
        }

        private void SearchButtonClick(object sender, EventArgs e)
        {
            if (guessTextBox.Text == "")
            {
                MessageBox.Show("Поле для ввода слова пустое");
                return;
            }

            dialogTextBox.Text += $"Игрок: Найди слово '{guessTextBox.Text}' в базе знаний\n";
            dialogTextBox.Text += $"Программа: Поиск объекта '{guessTextBox.Text}'...\n";
            dialogTextBox.Text += $"Программа: Результаты поиска: {knowledgeBase.GetDataOfObject(guessTextBox.Text) ?? $"объект '{guessTextBox.Text}' не найден"}\n";
        }

        private void SelectKnowledgeBaseButtonClick(object sender, EventArgs e)
        {
            if (!isFileSaved) 
            { 
                if (NotSavedFileWarning() == DialogResult.Yes)
                    return;
            }

            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = 
                    curPathTextbox.Text == "" ? 
                        Directory.GetCurrentDirectory() :
                        Path.GetDirectoryName(curPathTextbox.Text);
                openFileDialog.Filter = "JSON files|*.json";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                }
            }

            curPathTextbox.Text = filePath;
            knowledgeBase = new KnowledgeBase(filePath == "" ? null : filePath);
            isFileSaved = true;
        }

        private void SaveKnowledgeBaseButtonClick(object sender, EventArgs e)
        {
            curPathTextbox.Text = knowledgeBase.Unload();
            isFileSaved = true;
        }

        private DialogResult NotSavedFileWarning()
        {
            string message = "Файл базы знаний не сохранен. Сохранить файл?";
            string caption = "Потеря данных";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                curPathTextbox.Text = knowledgeBase.Unload();
                isFileSaved = true;
            }
            return result;
        }

        private void FormClosingHandler(object sender, FormClosingEventArgs e)
        {
            if (!isFileSaved)
            {
                if (NotSavedFileWarning() == DialogResult.Yes)
                    e.Cancel = true; 
            }
        }

        private void CancelGame(object sender, EventArgs e)
        {
            dialogTextBox.Text += $"Игрок: Отменить игру\n";
            ManagePlayerInterface(false);
            addQuestionPanel.Visible = false;
        }
    }

    internal static class ThemeName
    {
        public static string Singular { get { return "Предмет интерьера"; } }
        public static string Plural { get { return "Предметы интерьера"; } }
    }
}
