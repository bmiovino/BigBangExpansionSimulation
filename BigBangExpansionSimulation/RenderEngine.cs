﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBangExpansionSimulation
{
    public class RenderEngine
    {
        public void Render(string filepath, Region[] universe)
        {
            Bitmap b = new Bitmap(2048, 2048);

            Graphics g = Graphics.FromImage(b);

            foreach(Region r in universe)
            {
                int c = (int)((r.Energy + 1.0F) / 2.0F) * 255;

                Pen p = new Pen(Color.FromArgb(255, c, c));
                Brush br = p.Brush;
                Point pnt = new Point(r.Coordinate.X, r.Coordinate.Y);
                g.FillRectangle(br, pnt.X, pnt.Y, 1, 1);
            }

            b.Save(filepath,ImageFormat.Png);
        }

    }
}
