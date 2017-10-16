using System;
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
        public Axe(string name, int damage) : base(name, damage * 2, 1 / 2  * damage)
        {
            Name = "Økse";
        }
    }

    public sealed class Wand : Weapon
    {
        public Wand(string name, int damage) : base(name,  1 / 2 * damage , damage * 2)
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

        public virtual string GetWeaponDescription()
        {
            return $"Fysisk skade: {PhysicalDamage} Magisk skade: {MagicalDamage}";
        }

        //TODO remake this. This is just stupid and sloppy code.
        public static Weapon GenerateWeapon()
        {
            var temp = InheritedClassEnumerator.GetListOfInheritedClasses<Weapon>();
            Weapon tempweapon = (Weapon) Activator.CreateInstance(Type.GetType(temp[RandomGenerator.Random.Next(temp.Count)]) ??
                                              throw new ArgumentNullException(), "", 0);
            int damage = RandomGenerator.Random.Next(11);
            return (Weapon)Activator.CreateInstance(Type.GetType(temp[RandomGenerator.Random.Next(temp.Count)]) ??
                                                    throw new ArgumentNullException(), NameGeneration.WeaponName(tempweapon, damage), damage);
        }
    }
}
