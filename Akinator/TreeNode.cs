using System;
using System.Collections;
using System.Text;
using System.Text.Json.Serialization;

namespace Akinator
{
    enum ValueType
    {
        Object,
        Question,
        Ref
    }

    internal class TreeNode
    {
        [JsonInclude]
        public string Value;
        [JsonInclude]
        public TreeNode Left;
        [JsonInclude]
        public TreeNode Right;
        public ValueType Type { get { return evaluateNodeType(); } }
        public int MaxDepth { get { return getMaxDepth(this, 0); } }

        [JsonConstructor]
        public TreeNode(string Value = null, TreeNode Left = null, TreeNode Right = null)
        {
            this.Value = Value;
            this.Left = Left;
            this.Right = Right;
        }
        private ValueType evaluateNodeType() 
        {
            if (Left == null && Right == null && Value == null) 
            {
                return ValueType.Ref;
            }
            if(Left == null && Right == null || 
                Left != null && Right != null && Left.Type == ValueType.Ref && Right.Type == ValueType.Ref)
            {
                return ValueType.Object;
            }
            else
            {
                return ValueType.Question;
            }
        }

        private int getMaxDepth(TreeNode root, int curDepth)
        {
            if (root == null)
            {
                return curDepth;
            }
            return Math.Max(getMaxDepth(root.Left, ++curDepth), getMaxDepth(root.Right, curDepth));
        }
    }
}
