using Sharlayan.Core;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Mappy.Helpers
{
    static class AppHelper
    {
        /// <summary>
        /// Get the path to the application
        /// </summary>
        /// <returns></returns>
        public static string getApplicationPath() 
        {
            string path = Assembly.GetExecutingAssembly().CodeBase;
            var directory = Path.GetDirectoryName(path);
            return new Uri(directory).LocalPath;
        }

        /// <summary>
        /// Get the current time
        /// </summary>
        /// <returns></returns>
        public static string getCurrentTime() 
        {
            DateTime now = DateTime.Now;
            return now.ToString(Properties.Settings.Default.TimeFormat);
        }

        /// <summary>
        /// Create a fast bitmap of: Format32bppPArgb
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static Bitmap createBitmap(string file)
        {
            Bitmap orig = new Bitmap(file);
            Bitmap clone = new Bitmap(orig.Width, orig.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            using (Graphics gr = Graphics.FromImage(clone)) {
                gr.DrawImage(orig, new Rectangle(0, 0, clone.Width, clone.Height));
            }

            orig.Dispose();

            return clone;
        }
    }
}
