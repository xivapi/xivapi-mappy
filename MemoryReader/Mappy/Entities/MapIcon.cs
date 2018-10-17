using Sharlayan.Core;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Mappy.Helpers;

namespace Mappy.Entities
{
    // Player Icon struct
    public struct MapIcon
    {
        public ActorItem entity;
        public Bitmap icon;
        public int x, y;
        public int id;
        public double angle;
        public float width, height;

        //
        // Set the icons rotation
        //
        public void setRotation()
        {
            Bitmap newBitmap = new Bitmap((int)width, (int)height);
            Graphics graphics = Graphics.FromImage(newBitmap);

            try {
                lock (graphics)
                graphics.InterpolationMode = InterpolationMode.Bilinear;

                graphics.TranslateTransform(width / 2, ((float)height / 2));
                graphics.RotateTransform((float)angle);
                graphics.TranslateTransform(-width / 2, -((float)height / 2));
                graphics.DrawImage(icon, new Point(0, 0));
                icon = newBitmap;
            }
            catch (Exception ex)
            {
                //Logger.Exception(ex, "MapIcon -> SetRotation");
            }
        }
    }
}
