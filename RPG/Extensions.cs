using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

//Alt i dette namespace er kopieret fra stackoverflow, med mindre andet er skrevet.
namespace RPG.Extensions
{
    public enum ProgressBarColor
    {
        Green = 1,
        Red = 2,
        Yellow = 3
    }

    //Ændret en smugle af mig. I stedet for tal har jeg lavet det om til et enum.
    public static class ProgressBarSetColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr w, IntPtr l);

        public static void SetColor(this ProgressBar progressBar, ProgressBarColor progressBarColor)
        {
            SendMessage(progressBar.Handle, 1040, (IntPtr) progressBarColor, IntPtr.Zero);
        }
    }

    //Kraftigt ændret af mig. Før skulle man selv skrive hvor mange gange billedet skulle gentage og det virkede kun ud af x aksen. Jeg har fjernet begge limitationer.
    public static class PictureBoxExtension
    {
        public static void SetImage(this PictureBox pictureBox, Image image)
        {
            var bm = new Bitmap(pictureBox.Width, pictureBox.Height);
            var gp = Graphics.FromImage(bm);
            for (int x = 0; x < bm.Width - image.Width + bm.Width; x += image.Width)
            {

                for (int y = 0; y < bm.Height - image.Height + bm.Height; y += image.Height)
                {
                    gp.DrawImage(image, new Point(x, y));
                }
            }
            pictureBox.Image = bm;
        }
    }

    //Kraftigt ændret af mig. Den returnere ikke længere end klasse. Nu returnerer den en liste af strenge, hvor alle nedavede klassers navner ligger i.
    public static class InheritedClassEnumerator
    {
        public static List<string> GetListOfInheritedClasses<T>() where T : class
        {
            var objects = Assembly.GetAssembly(typeof(T))
                .GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T)))
                .Select(type => type.FullName)
                .ToList();
            objects.Sort();
            return objects;
        }
    }
}
