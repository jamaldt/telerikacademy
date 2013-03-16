using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2D_drawing_test_usihng_windows_forms
{
    public partial class Form1 : Form
    {
        System.Drawing.Drawing2D.GraphicsPath _gPath = null;
        Random _rnd = new Random();
        Timer t = new Timer();
        private PointF[] _points;
        private int _i;
        private Bitmap _bmp = null;
	String chess = "\u2654 \u2655 \u2656 \u2657 \u2658 \u2659 | \u265A \u265B \u265C \u265D \u265E \u265F";



        public Form1()
        {
            InitializeComponent();

            

            this.Name = chess; // "Form1";
            this.Text = chess; // "Form1";
            //avoid flickering
            this.DoubleBuffered = true;

            //make a bitmap to display
            _bmp = new Bitmap(100, 100);
            using (Graphics g = Graphics.FromImage(_bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                using (SolidBrush sb = new SolidBrush(Color.FromArgb(127, 0, 0, 255)))
                    g.FillEllipse(sb, new Rectangle(0, 0, _bmp.Width, _bmp.Height));

                g.FillEllipse(Brushes.Black, new Rectangle(_bmp.Width / 2 - 2, _bmp.Height / 2 - 2, 4, 4));
            }

            //make the Form somewhat larger
            this.ClientSize = new Size(600, 400);

            //cleanup
            this.FormClosing += delegate { if (_bmp != null) _bmp.Dispose(); if (_gPath != null) _gPath.Dispose(); };

            //setup a path and add some random values
            _gPath = new System.Drawing.Drawing2D.GraphicsPath();

            List<Point> fList = new List<Point>();

            //add points that will let the picturebox be fully visible inside the form
            for (int i = 0; i < 10; i++)
                fList.Add(new Point(_rnd.Next(_bmp.Width / 2, this.ClientSize.Width - _bmp.Width / 2),
                    _rnd.Next(_bmp.Height / 2, this.ClientSize.Height - _bmp.Height / 2)));

            //add a closed curve by these values
            _gPath.AddClosedCurve(fList.ToArray());

            //flatten, to make the path a Path of lines and points
            _gPath.Flatten();

            //get these points as Array to loacte the picturebox
            this._points = _gPath.PathPoints;

            //add the handler for the paint-event
            this.Paint += new PaintEventHandler(Form1_Paint);


            //start the timer
            t.Tick += new EventHandler(t_Tick);
            t.Interval = 20;
            t.Start();
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (_gPath != null && _bmp != null)
            {
                //draw the image
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(Pens.Red, _gPath);
                e.Graphics.DrawImage(_bmp, (int)_points[_i].X - (_bmp.Width / 2), (int)_points[_i].Y - (_bmp.Height / 2));
            }
        }

        void t_Tick(object sender, EventArgs e)
        {
            t.Stop();

            //redraw
            this.Invalidate();

            _i++;
            if (_i >= _points.Length)
                _i = 0;

            t.Start();
        }


        private void label2_Click(object sender, EventArgs e)
        {
            this.label2.Text = chess;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = "hello world";
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
