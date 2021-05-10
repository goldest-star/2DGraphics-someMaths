using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace In_Lec
{
    class Circle
    {
        public double XC, YC, Rad, OriginalXC, OriginalYC;
        public double sTh, eTh;
        public double MY, MX;
        public double cx, cy;
        public int dir;
        public bool x_based = true, drawL = false;
        public int spd = 10;
        public double dx, dy, m, inv_m;
        
        public void OriginalCalc()
        {
            OriginalXC = XC;
            OriginalYC = YC;
        }

        public void DrawPart(Graphics g)
        {
            
            Pen P = new Pen(Color.SkyBlue , 2);
            for (double cTheta = sTh; cTheta < eTh; cTheta++)
            {
                

                cx = Rad * Math.Cos(cTheta * Math.PI / 180) + XC;
                cy = Rad * Math.Sin(cTheta * Math.PI / 180) + YC;

                if (cTheta == sTh || cTheta == eTh-1)   // drawing the 2 lines of the segment
                    g.DrawLine(P, (int)cx, (int)cy, (int)XC, (int) YC);

                if (cTheta == (sTh + eTh-1) / 2)    // getting the mid points of the segment.
                {
                    MX = Rad * Math.Cos(cTheta * Math.PI / 180) + XC;
                    MY = Rad * Math.Sin(cTheta * Math.PI / 180) + YC;
                }
                //g.DrawLine(Brushes.White, (int) MX)
                g.FillEllipse(Brushes.Yellow, (int)cx - 3, (int)cy - 3, 6, 6);
                //if (drawL)
                    
            }
        }

        public void Calc()
        {
            
            dy = MY - YC;
            dx = MX - XC;
            m = dy / dx;
            cx = XC;
            cy = YC;
            drawL = true;

            if (Math.Abs(dx) > Math.Abs(dy))
            {
                x_based = true;
                if (XC < MX)
                    dir = 1;
                else
                    dir = -1;
            }
            else
            {
                x_based = false;
                if (YC < MY)
                    dir = 1;
                else
                    dir = -1;
            }
        }

        public void MoveStep()
        {
            if (x_based)
            {
                XC += dir * spd;
                YC += dir * m * spd;
            }
            else
            {
                YC += dir * spd;
                XC += dir * (1.0f / m) * spd;
            }
            

        }


    }
}
