using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.Json;
using System.Runtime.Remoting.Messaging;

namespace Akinator
{
    internal class KnowledgeBase
    {
        private TreeNode head;
        private Queue<bool> dialogBackTrace;
        private bool isFinal;
        private string baseFilePath;

        //public event EventHandler<MessageEventArgs> Message;
        public TreeNode Current { private set; get; }
        public TreeNode ToBinaryTreeRepresentation { get { return head.Value != null ? head : null; } }

        public KnowledgeBase(string baseFilePath = null)
        {
            this.baseFilePath = baseFilePath;
            Load();
        }

        private void Load()
        {
            try { head = JsonSerializer.Deserialize<TreeNode>(File.ReadAllText(baseFilePath)); }
            catch 
            {
                head = new TreeNode(); 
            }
            finally 
            {
                if (head.Left == null && head.Right == null)
                {
                    head.Left = new TreeNode();
                    head.Right = new TreeNode();
                }
            }
        }
        public string Unload()
        {
            if(baseFilePath == null)
            {
                var curDir = Directory.GetCurrentDirectory();
                baseFilePath = curDir + "\\KnowledgeBase.json";
                int i = 0;
                while (File.Exists(baseFilePath))
                {
                    baseFilePath = curDir + $"\\KnowledgeBase({++i}).json";
                }
            }
            File.WriteAllText(baseFilePath, JsonSerializer.Serialize(head));
            return baseFilePath;
        }

        //intitialObject запишется в базу, если она пустая
        public string GetInitialResponse(string intitialObject)
        {
            if (head.Value == null)
                head.Value = intitialObject;
                
            isFinal = false;
            dialogBackTrace = new Queue<bool> ();
            Current = new TreeNode(head.Value, head.Left, head.Right);
            return Current.Type == ValueType.Object ? $"Это {Current.Value}?" : Current.Value;
        }

        //null if end, else answer
        public string GetResponseIfYes()
        {
            if (isFinal)
            {
                return null;
            }
            else if (Current == null || Current.Type == ValueType.Ref)
            {
                isFinal = true;
                // return null; 
                throw new InvalidOperationException("GetResponseIfYes() was called before GetInitialResponse() method");
            }
            else if (Current.Right != null)
            {
                if(Current.Type == ValueType.Object)
                {
                    isFinal = true;
                    return null;
                }
                else
                {
                    dialogBackTrace.Enqueue(true);
                    Current = Current.Right;
                    return Current.Type == ValueType.Object ? $"Это {Current.Value}?" : Current.Value;
                }
            }
            isFinal = true;
            return null;
        }
        public string GetResponseIfNo()
        {
            if (isFinal)
            {
                return null;
            }
            else if (Current == null || Current.Type == ValueType.Ref)
            {
                isFinal = true;
                //return null; 
                throw new InvalidOperationException("GetResponseIfNo() was called before GetInitialResponse() method");
            }
            else if (Current.Left != null)
            {
                if (Current.Type == ValueType.Object)
                {
                    isFinal = true;
                    return null;
                }
                else
                {
                    dialogBackTrace.Enqueue(false);
                    Current = Current.Left;
                    return Current.Type == ValueType.Object ? $"Это {Current.Value}?" : Current.Value;
                }
            }
            isFinal = true;
            return null;
        }

        public void AddObject(string question, bool isPositiveAnswer, string newObject)
        {
            if(Current == null)
            {
                throw new InvalidOperationException("AddObject() was called before GetInitialResponse() method");
            }

            var temp = Current.Value;
            newObject = newObject.Trim().ToLower();
            question = question.Trim().ToLower();
            Current.Value = question;
            if (Current.Left != null && Current.Right != null)
            {
                if (Current.Left.Type == ValueType.Ref && Current.Right.Type == ValueType.Ref) {
                    head.Value = question;
                }
                else
                {
                    throw new Exception("left and right not null, but they not refs");
                }
            }

            if (Current.Left != null) 
            {
                Current.Left.Value = isPositiveAnswer ? temp : newObject;
            }
            else
            {
                Current.Left = new TreeNode(isPositiveAnswer ? temp : newObject);
            }

            if (Current.Right != null)
            {
                Current.Right.Value = isPositiveAnswer ? newObject : temp;
            }
            else
            {
                Current.Right = new TreeNode(isPositiveAnswer ? newObject : temp);
            }
        }

        public string GetDataOfObject(string objectName)
        {
            objectName = objectName.Trim().ToLower();
            var backTrace = new List<bool>();
            
            if (isObjectExist(head, backTrace, objectName, 0))
            {
                var res = getObjectInfo(new Queue<bool>(backTrace));
                if(res == "")
                {
                    res += $"для объекта '{objectName}' характеристики еще не заданы";
                }
                return res;
            }
            else
            {
                return null;
            }
        }

        private bool isObjectExist(TreeNode node, List<bool> stack, string objectName, int depthLevel)
        {
            if(node == null)
            {
                return false;
            }
            if(node.Value == objectName)
            {
                return true;
            }

            stack.Add(false);
            if(isObjectExist(node.Left, stack, objectName, depthLevel + 1))
            {
                return true;
            }
            stack.RemoveRange(depthLevel, stack.Count - depthLevel);

            stack.Add(true);
            if (isObjectExist(node.Right, stack, objectName, depthLevel + 1))
            {
                return true;
            }
            stack.RemoveRange(depthLevel, stack.Count - depthLevel);

            return false;
        }

        public string GetAnswerAnalisys()
        {
            if (Current == null)
            {
                throw new InvalidOperationException("GetAnswerAnalisys() was called before GetInitialResponse() method");
            }

            var s = getObjectInfo(dialogBackTrace);

            if(s != "")
            {
                s += "следовательно, ";
            }
            s += "это " + Current.Value;
            return s;
        }

        private string getObjectInfo(Queue<bool> backTrace)
        {
            Current = new TreeNode(head.Value, head.Left, head.Right);
            var s = "";
            while (true)
            {
                if (backTrace.Count == 0)
                {
                    break;
                }
                else if (backTrace.Dequeue())
                {
                    s += Current.Value.Substring(0, Current.Value.Length - 1) + ", ";
                    Current = Current.Right;
                }
                else
                {
                    s += getNegativeAnswer(Current.Value.Substring(0, Current.Value.Length - 1)) + ", ";
                    Current = Current.Left;
                }
            }
            return s;
        }
        private string getNegativeAnswer(string positiveAnswer)
        {
            var res = positiveAnswer.IndexOf("это");
            if(res != -1)
            {
                return positiveAnswer.Insert(res + 3, " не");
            }

            res = positiveAnswer.IndexOf("оно");
            if (res != -1)
            {
                return positiveAnswer.Insert(res + 3, " не");
            }

            res = positiveAnswer.IndexOf("он");
            if (res != -1)
            {
                return positiveAnswer.Insert(res + 2, " не");
            }

            res = positiveAnswer.IndexOf("можно");
            if (res != -1)
            {
                var temp = positiveAnswer.Remove(res, "можно".Length);
                return temp.Insert(res, "нельзя");
            }
            return $"не {positiveAnswer}";
        }

       /* protected virtual void OnMessage(MessageEventArgs e)
        {
            EventHandler<MessageEventArgs> handler = Message;
            if (handler != null)
            {
                handler(this, e);
            }
        }*/
    }

    /*public class MessageEventArgs : EventArgs
    {
        public readonly string Message;

        public MessageEventArgs(string message)
        {
            Message = message;
        }
    }*/
}
