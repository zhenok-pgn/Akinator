using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Akinator
{
    internal partial class BinaryTreeVisualizeForm : Form
    {
        private readonly TreeNode tree;
        private readonly int maxDepth;
        private readonly Pen pen = new Pen(Color.Black);
        private readonly Font drawFont = new Font("Arial", 12);
        private readonly SolidBrush drawBrush = new SolidBrush(Color.Black);
        private readonly Size rectangleSize = new Size(100, 100);
        private readonly Size bitmapSize;

        public BinaryTreeVisualizeForm(TreeNode tree)
        {
            InitializeComponent();

            this.tree = tree; 
            maxDepth = tree.MaxDepth;
            bitmapSize = new Size(
                    ((int)Math.Pow(2, maxDepth) - 1) * rectangleSize.Width,
                    maxDepth * rectangleSize.Height * 2);
            InitializeImageBoxComponent(
                bitmapSize,
                new Point(bitmapSize.Width / 2 - Width / 2, 0));
        }

        private void InitializeImageBoxComponent(Size bitmapSize, Point startPosition)
        {
            var box = new ImageBox
            {
                Image = new Bitmap(bitmapSize.Width, bitmapSize.Height),
                Dock = DockStyle.Fill
            };
            box.Paint += DrawBinaryTree;
            box.AutoScrollPosition = startPosition;
            Controls.Add(box);
        }

        private void DrawBinaryTree(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            var rootPoint = new Point(bitmapSize.Width / 2 - rectangleSize.Width / 2, 5);
            Draw(tree, rootPoint, rootPoint, 1, g);
        }

        private void Draw(TreeNode root, Point curPoint, Point prevPoint, int curDepth, Graphics g)
        {
            if (root == null)
            {
                return;
            }

            var rectangle = new Rectangle(curPoint, rectangleSize);
            if(curPoint != prevPoint)
            {
                g.DrawLine(
                    pen, 
                    new Point(prevPoint.X + rectangle.Width / 2, prevPoint.Y + rectangle.Height), 
                    new Point(curPoint.X + rectangle.Width / 2, curPoint.Y)
                    );
                var ansPoint = new Point((curPoint.X + prevPoint.X) / 2, (curPoint.Y + prevPoint.Y) / 2);
                g.DrawString(ansPoint.X < prevPoint.X ? "Нет" : "Да", drawFont, drawBrush, ansPoint);
            }
            
            g.DrawRectangle(pen, rectangle);
            g.DrawStringInside(rectangle, drawFont, drawBrush, root.Value);

            int delta = (int)(Math.Pow(2, maxDepth - curDepth) - 1) * rectangle.Width;
            var nextPoint = new Point(curPoint.X - rectangle.Width / 2 - delta / 2, curPoint.Y + rectangle.Height * 2);
            Draw(root.Left, nextPoint, curPoint, ++curDepth, g);

            nextPoint.X += delta + rectangle.Width;
            Draw(root.Right, nextPoint, curPoint, curDepth, g);
        }

        private void Close(object sender, FormClosedEventArgs e)
        {
            pen.Dispose();
            drawFont.Dispose();
            drawBrush.Dispose();
        }
    }

    internal static class GraphicsExtensions
    {
        public static void DrawStringInside(this Graphics graphics, Rectangle rect, Font font, Brush brush, string text)
        {
            SizeF textSize;
            float fontSize = font.Size;
            do
            {
                font = new Font(font.FontFamily, fontSize, font.Style);
                textSize = graphics.MeasureString(text, font, new SizeF(rect.Width, rect.Height));
                fontSize--;
            } while (textSize.Width > rect.Width || textSize.Height > rect.Height);
            graphics.DrawString(text, font, brush, rect);
        }
    }
}
