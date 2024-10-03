namespace Akinator
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.yesButton = new System.Windows.Forms.Button();
            this.noButton = new System.Windows.Forms.Button();
            this.guessTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.playerQuestionTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.sendQuestionButton = new System.Windows.Forms.Button();
            this.dialogPanel = new System.Windows.Forms.Panel();
            this.dialogTextBox = new System.Windows.Forms.RichTextBox();
            this.guessWordPanel = new System.Windows.Forms.Panel();
            this.saveKnowledgeBaseButton = new System.Windows.Forms.Button();
            this.wordSearchButton = new System.Windows.Forms.Button();
            this.addQuestionPanel = new System.Windows.Forms.Panel();
            this.whyThisAnswerButton = new System.Windows.Forms.Button();
            this.showBaseButton = new System.Windows.Forms.Button();
            this.curPathTextbox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.dialogPanel.SuspendLayout();
            this.guessWordPanel.SuspendLayout();
            this.addQuestionPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // yesButton
            // 
            this.yesButton.Location = new System.Drawing.Point(9, 25);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(75, 23);
            this.yesButton.TabIndex = 0;
            this.yesButton.Text = "ДА";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.YesButtonClick);
            // 
            // noButton
            // 
            this.noButton.Location = new System.Drawing.Point(90, 25);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(75, 23);
            this.noButton.TabIndex = 1;
            this.noButton.Text = "НЕТ";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.NoButtonClick);
            // 
            // guessTextBox
            // 
            this.guessTextBox.Location = new System.Drawing.Point(12, 26);
            this.guessTextBox.Name = "guessTextBox";
            this.guessTextBox.Size = new System.Drawing.Size(156, 20);
            this.guessTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Напишите слово";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Диалог";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Варианты ответов";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(178, 24);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(145, 23);
            this.startButton.TabIndex = 7;
            this.startButton.Text = "Начать игру";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartGuessingButtonClick);
            // 
            // playerQuestionTextBox
            // 
            this.playerQuestionTextBox.Location = new System.Drawing.Point(3, 27);
            this.playerQuestionTextBox.Name = "playerQuestionTextBox";
            this.playerQuestionTextBox.Size = new System.Drawing.Size(270, 23);
            this.playerQuestionTextBox.TabIndex = 8;
            this.playerQuestionTextBox.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Поле для вопроса";
            // 
            // sendQuestionButton
            // 
            this.sendQuestionButton.Location = new System.Drawing.Point(279, 25);
            this.sendQuestionButton.Name = "sendQuestionButton";
            this.sendQuestionButton.Size = new System.Drawing.Size(75, 23);
            this.sendQuestionButton.TabIndex = 10;
            this.sendQuestionButton.Text = "Отправить";
            this.sendQuestionButton.UseVisualStyleBackColor = true;
            this.sendQuestionButton.Click += new System.EventHandler(this.SendQuestionButtonClick);
            // 
            // dialogPanel
            // 
            this.dialogPanel.Controls.Add(this.yesButton);
            this.dialogPanel.Controls.Add(this.noButton);
            this.dialogPanel.Controls.Add(this.label3);
            this.dialogPanel.Location = new System.Drawing.Point(6, 308);
            this.dialogPanel.Name = "dialogPanel";
            this.dialogPanel.Size = new System.Drawing.Size(169, 58);
            this.dialogPanel.TabIndex = 11;
            // 
            // dialogTextBox
            // 
            this.dialogTextBox.Location = new System.Drawing.Point(12, 86);
            this.dialogTextBox.Name = "dialogTextBox";
            this.dialogTextBox.ReadOnly = true;
            this.dialogTextBox.Size = new System.Drawing.Size(456, 207);
            this.dialogTextBox.TabIndex = 4;
            this.dialogTextBox.Text = "";
            // 
            // guessWordPanel
            // 
            this.guessWordPanel.Controls.Add(this.wordSearchButton);
            this.guessWordPanel.Controls.Add(this.guessTextBox);
            this.guessWordPanel.Controls.Add(this.label1);
            this.guessWordPanel.Controls.Add(this.startButton);
            this.guessWordPanel.Location = new System.Drawing.Point(3, 6);
            this.guessWordPanel.Name = "guessWordPanel";
            this.guessWordPanel.Size = new System.Drawing.Size(785, 52);
            this.guessWordPanel.TabIndex = 12;
            // 
            // saveKnowledgeBaseButton
            // 
            this.saveKnowledgeBaseButton.Location = new System.Drawing.Point(3, 269);
            this.saveKnowledgeBaseButton.Name = "saveKnowledgeBaseButton";
            this.saveKnowledgeBaseButton.Size = new System.Drawing.Size(301, 23);
            this.saveKnowledgeBaseButton.TabIndex = 9;
            this.saveKnowledgeBaseButton.Text = "Сохранить базу знаний";
            this.saveKnowledgeBaseButton.UseVisualStyleBackColor = true;
            this.saveKnowledgeBaseButton.Click += new System.EventHandler(this.SaveKnowledgeBaseButtonClick);
            // 
            // wordSearchButton
            // 
            this.wordSearchButton.Location = new System.Drawing.Point(331, 24);
            this.wordSearchButton.Name = "wordSearchButton";
            this.wordSearchButton.Size = new System.Drawing.Size(136, 23);
            this.wordSearchButton.TabIndex = 8;
            this.wordSearchButton.Text = "Найти в базе знаний";
            this.wordSearchButton.UseVisualStyleBackColor = true;
            this.wordSearchButton.Click += new System.EventHandler(this.SearchButtonClick);
            // 
            // addQuestionPanel
            // 
            this.addQuestionPanel.Controls.Add(this.playerQuestionTextBox);
            this.addQuestionPanel.Controls.Add(this.sendQuestionButton);
            this.addQuestionPanel.Controls.Add(this.label4);
            this.addQuestionPanel.Location = new System.Drawing.Point(3, 372);
            this.addQuestionPanel.Name = "addQuestionPanel";
            this.addQuestionPanel.Size = new System.Drawing.Size(785, 66);
            this.addQuestionPanel.TabIndex = 13;
            this.addQuestionPanel.Visible = false;
            // 
            // whyThisAnswerButton
            // 
            this.whyThisAnswerButton.Location = new System.Drawing.Point(334, 333);
            this.whyThisAnswerButton.Name = "whyThisAnswerButton";
            this.whyThisAnswerButton.Size = new System.Drawing.Size(134, 23);
            this.whyThisAnswerButton.TabIndex = 7;
            this.whyThisAnswerButton.Text = "Почему такой ответ?";
            this.whyThisAnswerButton.UseVisualStyleBackColor = true;
            this.whyThisAnswerButton.Visible = false;
            this.whyThisAnswerButton.Click += new System.EventHandler(this.WhyThisAnswerButtonClick);
            // 
            // showBaseButton
            // 
            this.showBaseButton.Location = new System.Drawing.Point(179, 343);
            this.showBaseButton.Name = "showBaseButton";
            this.showBaseButton.Size = new System.Drawing.Size(147, 23);
            this.showBaseButton.TabIndex = 8;
            this.showBaseButton.Text = "Покажи всю базу знаний";
            this.showBaseButton.UseVisualStyleBackColor = true;
            this.showBaseButton.Click += new System.EventHandler(this.ShowBaseButtonClick);
            // 
            // curPathTextbox
            // 
            this.curPathTextbox.Location = new System.Drawing.Point(10, 22);
            this.curPathTextbox.Name = "curPathTextbox";
            this.curPathTextbox.Size = new System.Drawing.Size(301, 20);
            this.curPathTextbox.TabIndex = 10;
            this.curPathTextbox.Click += new System.EventHandler(this.SelectKnowledgeBaseButtonClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.curPathTextbox);
            this.panel1.Controls.Add(this.saveKnowledgeBaseButton);
            this.panel1.Location = new System.Drawing.Point(474, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 302);
            this.panel1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Выберите файл базы знаний";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(276, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "* если файл не выбран, то создастся автоматически";
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(179, 317);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(147, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Отменить игру";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelGame);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.whyThisAnswerButton);
            this.Controls.Add(this.addQuestionPanel);
            this.Controls.Add(this.showBaseButton);
            this.Controls.Add(this.guessWordPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dialogPanel);
            this.Controls.Add(this.dialogTextBox);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosingHandler);
            this.dialogPanel.ResumeLayout(false);
            this.dialogPanel.PerformLayout();
            this.guessWordPanel.ResumeLayout(false);
            this.guessWordPanel.PerformLayout();
            this.addQuestionPanel.ResumeLayout(false);
            this.addQuestionPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.TextBox guessTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.RichTextBox playerQuestionTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button sendQuestionButton;
        private System.Windows.Forms.Panel dialogPanel;
        private System.Windows.Forms.RichTextBox dialogTextBox;
        private System.Windows.Forms.Panel guessWordPanel;
        private System.Windows.Forms.Panel addQuestionPanel;
        private System.Windows.Forms.Button whyThisAnswerButton;
        private System.Windows.Forms.Button showBaseButton;
        private System.Windows.Forms.Button wordSearchButton;
        private System.Windows.Forms.Button saveKnowledgeBaseButton;
        private System.Windows.Forms.TextBox curPathTextbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cancelButton;
    }
}

