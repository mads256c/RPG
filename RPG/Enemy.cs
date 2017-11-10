using System.Drawing;
using RPG.Properties;

namespace RPG
{
    /// <summary>
    /// En simpel klasse der har fjende information.
    /// </summary>
    public class Enemy
    {
        /// <summary>
        /// Alle de forskellige fjende sprites.
        /// </summary>
        public static Image[] Sprites = {Resources.Orc};

        public int MaxHealth;
        public int Health;

        public int MaxMana;
        public int Mana;

        public int Speed;
        public string Name;
        public Image Sprite;

        /// <summary>
        /// Laver en ny <see cref="Enemy"/>.
        /// </summary>
        /// <param name="health">Fjendens livspoint.</param>
        /// <param name="mana">Fjendens mana.</param>
        /// <param name="speed">Fjendens hastighed.</param>
        /// <param name="name">Fjendens navn.</param>
        /// <param name="sprite">Fjendens sprite.</param>
        public Enemy(int health, int mana, int speed, string name, Image sprite)
        {
            MaxHealth = health;
            Health = health;

            MaxMana = mana;
            Mana = mana;

            Speed = speed;
            Name = name;
            Sprite = sprite;
        }

    }
}
