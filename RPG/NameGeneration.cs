using RPG.Extensions;
using RPG.Weapons;

namespace RPG
{
    public static class NameGeneration
    {
        private static readonly string[] PositiveAdjektives = 
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

        private static readonly string[] NormalAdjektives =
        {
            "Okay",
            "Nogenlunde",
            "God",
            "Rimelig",
            "Fin",
            "Acceptabel",
            "Skarp"
        };

        private static readonly string[] NegativeAdjektives =
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

        private static readonly string[] PlayerPrepend =
        {
            "Lille",
            "Store",
            "Farlige",
            "Troldmanden",
            "Krigeren",
            "Onde",
            "Tyven",
            "Dakmand",
            "Røvhullet",
            "Postmand",
            "Naren",
            "Knejten",
            "Orken",
            "Gnomen",
            ""
        };

        private static readonly string[] PlayerNames =
        {
            "John",
            "Per",
            "Mogens",
            "Karl",
            "Christian",
            "Nikolaj",
            "Mads",
            "Rasmus",
            "Tobias",
            "Meller",
            "Stella",
            "Anne-Sofie",
            "Anne",
            "Mette",
            "Martin",
            "Emil",
            "Lene",
            "Bonde",
            "Patrik",
            "Kasper",
            "John Hitler",
            ""
        };

        private static readonly string[] PlayerAppend =
        {
            "Den Lille",
            "Den Onde",
            "Den Gode",
            "Den Store",
            "Den Farlige",
            "Mogens",
            "Dak Lytter",
            "Sværdsvinger",
            "Fodboldmester",
            "Den tredje",
            "Den fjerde",
            "Den Dumme",
            "Den Kloge",
            "Den Tynde",
            "Den Tykke",
            "Den Svage",
            "Den Stærke",
            "Korytter",
            "Den modige",
            ""
        };

        public static string PlayerName()
        {
            return
                $"{PlayerPrepend[RandomGenerator.Random.Next(PlayerPrepend.Length)]} {PlayerNames[RandomGenerator.Random.Next(PlayerNames.Length)]} {PlayerAppend[RandomGenerator.Random.Next(PlayerAppend.Length)]}";
        }
    }
}
