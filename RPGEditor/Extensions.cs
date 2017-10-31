using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RPGEditor
{
    //Kraftigt ændret af mig. Den returnere ikke længere en klasse. Nu returnerer den en liste af strenge, hvor alle nedavede klassers navner ligger i.
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
}
