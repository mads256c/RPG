using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using RPG.Extensions;
using RPG.Properties;

namespace RPG.Potions
{
    public sealed class ManaPotion : Potion
    {
        public ManaPotion() : base()
        {

        }

        public ManaPotion(PotionSize potionSize) : base(potionSize)
        {

        }

        public override void ApplyEffect()
        {
            switch (potionSize)
            {
                case PotionSize.Small:
                    Player.Mana += (int)(1f / 4f * (float)Player.Mana);
                    break;
                case PotionSize.Medium:
                    Player.Mana += (int)(2f / 4f * (float)Player.Mana);
                    break;
                case PotionSize.Big:
                    Player.Mana += (int)(3f / 4f * (float)Player.Mana);
                    break;
                case PotionSize.Max:
                    Player.Mana += (int)(4f / 4f * (float)Player.Mana);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override string GetName()
        {
            return "Manaelexir";
        }

        public override string GetDescription()
        {
            switch (potionSize)
            {
                case PotionSize.Small:
                    return "Giver dig en lille del af din mana.";
                case PotionSize.Medium:
                    return "Giver dig halvdelen af din mana.";
                case PotionSize.Big:
                    return "Giver dig en stor del af din mana.";
                case PotionSize.Max:
                    return "Giver dig max mana.";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override Image GetImage()
        {
            switch (potionSize)
            {
                case PotionSize.Small:
                    return Resources.SmallMana;
                case PotionSize.Medium:
                    return Resources.MediumMana;
                case PotionSize.Big:
                    return Resources.BigMana;
                case PotionSize.Max:
                    return Resources.MaxMana;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public sealed class HealthPotion : Potion
    {
        public HealthPotion() : base()
        {
            
        }

        public HealthPotion(PotionSize potionSize) : base(potionSize)
        {
            
        }

        public override void ApplyEffect()
        {
            switch (potionSize)
            {
                case PotionSize.Small:
                    Player.Health += (int)(1f / 4f * (float)Player.MaxHealth);
                    break;
                case PotionSize.Medium:
                    Player.Health += (int)(2f / 4f * (float)Player.MaxHealth);
                    break;
                case PotionSize.Big:
                    Player.Health += (int)(3f / 4f * (float)Player.MaxHealth);
                    break;
                case PotionSize.Max:
                    Player.Health += (int)(4f / 4f * (float)Player.MaxHealth);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override string GetName()
        {
            return "Livselexir";
        }

        public override string GetDescription()
        {
            switch (potionSize)
            {
                case PotionSize.Small:
                    return "Heler en lille del af dit liv.";
                case PotionSize.Medium:
                    return "Heler halvdelen af dit liv.";
                case PotionSize.Big:
                    return "Heler en stor del af dit liv.";
                case PotionSize.Max:
                    return "Heler dig til fuld liv.";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override Image GetImage()
        {
            switch (potionSize)
            {
                case PotionSize.Small:
                    return Resources.SmallHealth;
                case PotionSize.Medium:
                    return Resources.MediumHealth;
                case PotionSize.Big:
                    return Resources.BigHealth;
                case PotionSize.Max:
                    return Resources.MaxHealth;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public abstract class Potion
    {
        public enum PotionSize
        {
            Small = 0,
            Medium = 1,
            Big = 2,
            Max = 3
        }

        public PotionSize potionSize;

        protected Potion() : this((PotionSize)RandomGenerator.Random.Next(4))
        {

        }

        protected Potion(PotionSize potionSize)
        {
            this.potionSize = potionSize;
        }

        public abstract void ApplyEffect();

        public abstract string GetName();

        public virtual string GetLongName()
        {
            string name;
            switch (potionSize)
            {
                case PotionSize.Small:
                    name = "Lille";
                    break;
                case PotionSize.Medium:
                    name =  "Medium";
                    break;
                case PotionSize.Big:
                    name = "Stor";
                    break;
                case PotionSize.Max:
                    name = "Maximum";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return $"{name} {GetName()}";
        }

        public abstract string GetDescription();

        public abstract Image GetImage();

        public static Potion GeneratePotion()
        {
            return GeneratePotion((PotionSize)RandomGenerator.Random.Next(4));
        }

        public static Potion GeneratePotion(PotionSize potionSize)
        {
            List<Type> typeList = InheritedClassEnumerator.GetListOfTypes<Potion>();

            return (Potion)Activator.CreateInstance(typeList[RandomGenerator.Random.Next(typeList.Count)] ?? throw new ArgumentNullException(), potionSize);
        }

    }
}
