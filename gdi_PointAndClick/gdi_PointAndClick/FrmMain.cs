using System;

namespace gdi_PointAndClick
{
    public partial class FrmMain : Form
    {
        List<Rectangle> rectangles = new List<Rectangle>();

        public FrmMain()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        private void FrmMain_Paint(object sender, PaintEventArgs e)
        {
            // Hilfsvarablen
            Graphics g = e.Graphics;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            // Zeichenmittel
            Random random = new Random();
            Brush b = new SolidBrush(Color.Black);
            for (int i = 0; i < rectangles.Count; i++)
            {
                b = new SolidBrush(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
                g.FillRectangle(b, rectangles[i]);
            }
        }

        private void FrmMain_MouseClick(object sender, MouseEventArgs e)
        {



            Point mausposition = e.Location;
            Random random = new Random();
            Rectangle r = new Rectangle(mausposition.X - 20, mausposition.Y - 20, random.Next(30, 40), random.Next(30, 40));
            bool contains = false;

            if (e.Button == MouseButtons.Left) 
            {
                for (int i = 0; i < rectangles.Count; i++)
                {
                    if (rectangles[i].Contains(e.Location.X, e.Location.Y))
                    {
                        contains = true;
                    }
                }
                if (!contains)
                {
                    rectangles.Add(r);
                    contains = false;
                }

                Refresh();
            }

            if (e.Button == MouseButtons.Right) // Rechtsklick
            {
                for (int i = 0; i < rectangles.Count; i++)
                {
                    if (rectangles[i].Contains(e.Location.X, e.Location.Y))
                    {
                        rectangles.Remove(rectangles[i]);
                    }
                }
                Refresh();
            }
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                rectangles.Clear();
                Refresh();
            }
        }

        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}