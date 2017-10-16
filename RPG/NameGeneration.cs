using RPG.Extensions;
using RPG.Weapons;

namespace RPG
{
    public static class NameGeneration
    {
        public static readonly string[] PositiveAdjektives = 
        {
            "Brillant",
            "Fabelagtig",
            "Fremragende",
            "Glimrende",
            "Sindsyg",
            "Legendarisk",
            "Episk",
            "Sylespids"
        };

        public static readonly string[] NormalAdjektives =
        {
            "Okay",
            "Nogenlunde",
            "Godt",
            "Rimelig",
            "Fin",
            "Acceptabel",
            "Skarp"
        };

        public static readonly string[] NegativeAdjektives =
        {
            "Dårlig",
            "Svagt",
            "Forfærtelig",
            "Elendig",
            "Sløv",
            "Miserabel",
            "Billig",
            "Ynkelig",
            "Rusten"
        };

        public static string WeaponName(Weapon weapon, int damage)
        {
            if (damage > 7)
            {
                return $"{PositiveAdjektives[RandomGenerator.Random.Next(PositiveAdjektives.Length)]} {weapon.Name}";
            }
            if (damage > 3 && damage < 8)
            {
                return $"{NormalAdjektives[RandomGenerator.Random.Next(NormalAdjektives.Length)]} {weapon.Name}";
            }
            return $"{NegativeAdjektives[RandomGenerator.Random.Next(NegativeAdjektives.Length)]} {weapon.Name}";
        }
    }
}
