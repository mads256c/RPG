using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Alt i dette namespace er kopieret fra stackoverflow
namespace RPG.Extensions
{
    public enum ProgressBarColor : int
    {
        Green = 1,
        Red = 2,
        Yellow = 3
    }

    public static class ProgressBarSetStyle
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);

        public static void SetState(this ProgressBar pBar, ProgressBarColor state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr) state, IntPtr.Zero);
        }
    }

    //Kraftigt ændret af mig
    public static class PictureBoxExtension
    {
        public static void SetImage(this PictureBox pic, Image image)
        {
            Bitmap bm = new Bitmap(pic.Width, pic.Height);
            Graphics gp = Graphics.FromImage(bm);
            for (int x = 0; x < (bm.Width - image.Width) + bm.Width; x += image.Width)
            {

                for (int y = 0; y < (bm.Height - image.Height) + bm.Height; y += image.Height)
                {
                    gp.DrawImage(image, new Point(x, y));
                }
            }
            pic.Image = bm;
        }
    }
}
