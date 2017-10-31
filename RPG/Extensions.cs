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

    //Kraftigt ændret af mig. Den returnerer ikke længere en klasse. Nu returnerer den en liste af strenge, hvor alle nedavede klassers navner ligger i.
    public static class InheritedClassEnumerator
    {
        public static List<string> GetListOfStrings<T>() where T : class
        {
            var objects = Assembly.GetAssembly(typeof(T))
                .GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T)))
                .Select(type => type.FullName)
                .ToList();
            objects.Sort();
            return objects;
        }

        public static List<Type> GetListOfTypes<T>() where T : class
        {
            var objects = Assembly.GetAssembly(typeof(T))
                .GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T)))
                .ToList();
            return objects;
        }
    }

    //Lavet af mig
    public static class RandomGenerator
    {
        public static Random Random = new Random();
    }

    //Lavet af mig
    public static class MathExtension
    {

        public static int Clamp(int value, int min, int max)
        {
            return Math.Max(min, Math.Min(value, max));
        }
    }

    public static class VariableHelper
    {
        public static void Swap<T>(ref T x, ref T y)
        {
            T t = y;
            y = x;
            x = t;
        }
    }


}
