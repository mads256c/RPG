using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

//Brugt til niece småting og forlængelser af sproget og frameworken.
namespace RPG.Extensions
{
    public enum ProgressBarColor
    {
        Green = 1,
        Red = 2,
        Yellow = 3
    }

    //Taget fra internettet. Ændret en smugle af mig. I stedet for tal har jeg lavet det om til et enum.
    /// <summary>
    /// Denne klasse inderholder forlængelser af klassen <see cref="ProgressBar"/>.
    /// </summary>
    public static class ProgressBarExtension
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr w, IntPtr l);
        /// <summary>
        /// Sætter farven på en <see cref="ProgressBar"/>.
        /// </summary>
        /// <param name="progressBar">Den <see cref="ProgressBar"/>, som skal have farven ændret.</param>
        /// <param name="progressBarColor">Den farve <see cref="ProgressBar"/>en skal have.</param>
        public static void SetColor(this ProgressBar progressBar, ProgressBarColor progressBarColor)
        {
            SendMessage(progressBar.Handle, 1040, (IntPtr) progressBarColor, IntPtr.Zero);
        }
    }

    //Taget fra internettet. Kraftigt ændret af mig. Før skulle man selv skrive hvor mange gange billedet skulle gentage og det virkede kun ud af x aksen. Jeg har fjernet begge limitationer.
    /// <summary>
    /// Denne klasse inderholder forlængelser af klassen <see cref="PictureBox"/>.
    /// </summary>
    public static class PictureBoxExtension
    {
        /// <summary>
        /// Gør sådan at billedet gentages i begge akser.
        /// </summary>
        /// <param name="pictureBox">Den <see cref="PictureBox"/> som skal have et gentagende billede.</param>
        /// <param name="image">Det <see cref="Image"/> som skal gentages.</param>
        public static void SetRepeatingImage(this PictureBox pictureBox, Image image)
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
    //Den har også nu en caching funktion, fordi at reflektion er meget langsomt.
    /// <summary>
    /// Enumererer alle klasser som arver fra den specificerede klasse.
    /// </summary>
    public static class InheritedClassEnumerator
    {
        private static Dictionary<Type, List<string>> listOfStringsCache = new Dictionary<Type, List<string>>();

        /// <summary>
        /// Få en liste af alle klasser der arver fra <see cref="T"/>.
        /// </summary>
        /// <typeparam name="T">Klassen der skal enumereres.</typeparam>
        /// <returns>En liste af klassernes fulde navne.</returns>
        public static List<string> GetListOfStrings<T>() where T : class
        {
            foreach (var keypair in listOfStringsCache)
            {
                if (keypair.Key == typeof(T))
                    return keypair.Value;
            }

            var objects = Assembly.GetAssembly(typeof(T))
                .GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T)))
                .Select(type => type.FullName)
                .ToList();
            objects.Sort();
            listOfStringsCache.Add(typeof(T), objects);
            return objects;
        }

        private static Dictionary<Type, List<Type>> listOfTypesCache = new Dictionary<Type, List<Type>>();

        /// <summary>
        /// Få en liste af alle klasser der arver fra <see cref="T"/>.
        /// </summary>
        /// <typeparam name="T">Klassen der skal enumereres.</typeparam>
        /// <returns>En liste af klassernes <see cref="Type"/>.</returns>
        public static List<Type> GetListOfTypes<T>() where T : class
        {
            foreach (var keypair in listOfTypesCache)
            {
                if (keypair.Key == typeof(T))
                    return keypair.Value;
            }

            var objects = Assembly.GetAssembly(typeof(T))
                .GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T)))
                .ToList();
            listOfTypesCache.Add(typeof(T), objects);
            return objects;
        }
    }

    /// <summary>
    /// En simpel tilfældighedsgenerator.
    /// </summary>
    public static class RandomGenerator
    {
        public static Random Random = new Random();
    }

    /// <summary>
    /// Matematik forlængelser.
    /// </summary>
    public static class MathExtension
    {
        /// <summary>
        /// Holder <see cref="value"/> indenfor <see cref="min"/> og <see cref="max"/>.
        /// </summary>
        /// <param name="value">Det tal der skal holdes indenfor minimum og maksimum.</param>
        /// <param name="min">Det mindste.</param>
        /// <param name="max">Det maksimale.</param>
        /// <returns></returns>
        public static int Clamp(int value, int min, int max)
        {
            return Math.Max(min, Math.Min(value, max));
        }
    }

    /// <summary>
    /// En klasse der hjælper med variabler.
    /// </summary>
    public static class VariableHelper
    {
        /// <summary>
        /// Bytter to variablers indehold.
        /// </summary>
        /// <typeparam name="T">Typen af variablet som skal byttes.</typeparam>
        public static void Swap<T>(ref T x, ref T y)
        {
            var t = y;
            y = x;
            x = t;
        }
    }


}
