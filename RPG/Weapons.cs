using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Extensions;

namespace RPG.Weapons
{
    public sealed class Sword : Weapon
    {
        public Sword(string name, int damage) : base(name, damage, damage)
        {
            Name = "Sværd";
        }
    }

    public sealed class Axe : Weapon
    {
        public Axe(string name, int damage) : base(name, damage * 2, damage / 2)
        {
            Name = "Økse";
        }
    }

    public sealed class Wand : Weapon
    {
        public Wand(string name, int damage) : base(name, damage / 2, damage * 2)
        {
            Name = "Tryllestav";
        }
    }

    public abstract class Weapon
    {
        public string LongName;

        public string Name;

        public int PhysicalDamage;
        public int MagicalDamage;

        protected Weapon(string name, int physicalDamage, int magicalDamage)
        {
            LongName = name;
            PhysicalDamage = physicalDamage;
            MagicalDamage = magicalDamage;
        }

        public static Weapon GenerateWeapon()
        {
            var temp = InheritedClassEnumerator.GetListOfInheritedClasses<Weapon>();
            Weapon tempweapon = (Weapon) Activator.CreateInstance(Type.GetType(temp[RandomGenerator.Random.Next(temp.Count)]) ??
                                              throw new ArgumentNullException(), "", 0);
            int damage = RandomGenerator.Random.Next(11);
            Logger.WriteLine(damage.ToString());
            return (Weapon)Activator.CreateInstance(Type.GetType(temp[RandomGenerator.Random.Next(temp.Count)]) ??
                                                    throw new ArgumentNullException(), NameGeneration.WeaponName(tempweapon, damage), damage);
        }
    }
}
