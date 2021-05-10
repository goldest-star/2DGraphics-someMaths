using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace In_Lec
{
    public partial class Form1 : Form
    {
        Bitmap off;
        Timer tt = new Timer();
        Circle cr = new Circle();
        List<Circle> L = new List<Circle>();
        int Selector = 0;

        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += new EventHandler(Form1_Load);
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            tt.Tick += new EventHandler(tt_Tick);
                    
        }

        void tt_Tick(object sender, EventArgs e)
        {

            L[Selector].Calc();
            
            L[Selector].MoveStep();
            
            DrawDubb(this.CreateGraphics());
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    tt.Start();
                    break;

                case Keys.Up:
                    if (Selector < 7)
                        Selector++;
                    else
                        Selector = 0;
                    break;

                case Keys.Down:
                    if (Selector > 0)
                        Selector--;
                    else
                        Selector = 7;
                    break;
            }
            DrawDubb(this.CreateGraphics());

        }

        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            DrawDubb(this.CreateGraphics());
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);    
        }

        void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            cr.sTh = 0;
            cr.eTh = 360;

            for (int i = 0; i < 8; i++)
            {
                Circle pnn = new Circle();
                pnn.XC = 1000;
                pnn.YC = 500;
                pnn.cx = pnn.XC;
                pnn.cy = pnn.YC;
                pnn.Rad = 200;
                pnn.sTh = 45 * i;
                pnn.eTh = pnn.sTh + 45;
                pnn.OriginalCalc();
                pnn.drawL = true;
                L.Add(pnn);
            }
        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);

            for (int i = 0; i < L.Count; i++)
            {
                L[i].DrawPart(g);
            }
            if (L[Selector].drawL)
            g.DrawLine(Pens.Red, (int)L[Selector].OriginalXC, (int)L[Selector].OriginalYC, (int)L[Selector].MX, (int)L[Selector].MY);

        }

        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
    }
}
