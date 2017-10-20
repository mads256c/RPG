using System;
using System.Drawing;
using RPG.Extensions;
using RPG.Properties;

namespace RPG.Weapons
{
    public sealed class SwordWeapon : Weapon
    {
        public SwordWeapon(string prepend, int damage) : base(prepend, damage, damage)
        {

        }

        public override Image GetWeaponImage()
        {
            return Resources.Sword;
        }

        public override string GetWeaponName()
        {
            return "Sværd";
        }

        public override string GetWeaponLongName()
        {
            return $"{Prepend}t {GetWeaponName()}";
        }

        public override string GetWeaponDescription()
        {
            return $"Et {GetWeaponLongName()}{Environment.NewLine}{base.GetWeaponDescription()}";
        }
    }

    public sealed class AxeWeapon : Weapon
    {
        public AxeWeapon(string prepend, int damage) : base(prepend, damage * 2, (int)(1f / 2f * (float)damage))
        {

        }

        public override Image GetWeaponImage()
        {
            return Resources.Axe;
        }

        public override string GetWeaponName()
        {
            return "Økse";
        }

        public override string GetWeaponDescription()
        {
            return $"En {Prepend} {GetWeaponName()}{Environment.NewLine}{base.GetWeaponDescription()}";
        }
    }

    public sealed class WandWeapon : Weapon
    {
        public WandWeapon(string prepend, int damage) : base(prepend, (int)(1f / 2f * (float)damage) , damage * 2)
        {

        }

        public override Image GetWeaponImage()
        {
            return Resources.Wand;
        }

        public override string GetWeaponName()
        {
            return "Tryllestav";
        }

        public override string GetWeaponDescription()
        {
            return $"En {Prepend} {GetWeaponName()}{Environment.NewLine}{base.GetWeaponDescription()}";
        }
    }

    public abstract class Weapon
    {
        public int PhysicalDamage;
        public int MagicalDamage;

        protected string Prepend;

        protected Weapon(string prepend, int physicalDamage, int magicalDamage)
        {
            Prepend = prepend;
            PhysicalDamage = physicalDamage;
            MagicalDamage = magicalDamage;
        }

        public abstract Image GetWeaponImage();

        public abstract string GetWeaponName();

        public virtual string GetWeaponLongName()
        {
            return $"{Prepend} {GetWeaponName()}";
        }

        public virtual string GetWeaponDescription()
        {
            return $"Fysisk skade: {PhysicalDamage} Magisk skade: {MagicalDamage}";
        }

        //TODO remake this. This is just stupid and sloppy code.
        public static Weapon GenerateWeapon()
        {
            var temp = InheritedClassEnumerator.GetListOfTypes<Weapon>();
            Weapon tempweapon = (Weapon) Activator.CreateInstance(temp[RandomGenerator.Random.Next(temp.Count)] ??
                                              throw new ArgumentNullException(), "", 0);
            int damage = RandomGenerator.Random.Next(11);
            return (Weapon)Activator.CreateInstance(tempweapon.GetType(), NameGeneration.WeaponName(tempweapon, damage), damage);
        }
    }
}
