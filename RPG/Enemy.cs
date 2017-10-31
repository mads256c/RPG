using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RPG.Properties;

namespace RPG
{
    public class Enemy
    {
        public static Image[] Sprites = {Resources.Orc};

        public int MaxHealth;
        public int Health;

        public int MaxMana;
        public int Mana;

        public int Speed;
        public string Name;
        public Image Sprite;

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
