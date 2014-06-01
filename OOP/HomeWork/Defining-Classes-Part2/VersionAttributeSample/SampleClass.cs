namespace VersionAttributeSample
{
    using System;
    using System.Reflection;

    [Version("1.0", "Pesho")]
    public class VersionsDemo
    {
        [Version("2.1")]
        private enum DemoConfiguration
        {
            Debug = 0,
            Release = 1,
        }

        [Version("3.15", "Doing calculations")]
        private static void DoesSomething()
        {
            dynamic dummy = 5;
            dummy += 5 + 6;
        }

        [Version("5.67")]
        private static bool IsIdiotOutside()
        {
            return true;
        }

        [Version("7.77", "Main method")]
        private static void Main()
        {
            Type typeOfClass = typeof(VersionsDemo);
            object[] customAttributes = typeOfClass.GetCustomAttributes(false);
            if (customAttributes.Length > 0)
            {
                Console.WriteLine(
                    "Class variant {0} info \"{1}\"",
                    (customAttributes[0] as VersionAttribute).Version,
                    (customAttributes[0] as VersionAttribute).Info);
            }

            MethodInfo[] methods = typeOfClass.GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            foreach (MethodInfo method in methods)
            {
                object[] methodAttributes = method.GetCustomAttributes(false);
                if (methodAttributes.Length > 0 && methodAttributes[0] is VersionAttribute)
                {
                    Console.WriteLine(
                        "Method \"{0}\" , version {1}, info \"{2}\"",
                        method.Name,
                        (methodAttributes[0] as VersionAttribute).Version,
                        (methodAttributes[0] as VersionAttribute).Info);
                }
            }

            Type enumType = typeOfClass.GetNestedType("DemoConfiguration", BindingFlags.NonPublic);
            object[] enumCustomAttributes = enumType.GetCustomAttributes(false);
            if (enumCustomAttributes.Length > 0 && enumCustomAttributes[0] is VersionAttribute)
            {
                Console.WriteLine(
                    "Enum \"{0}\", version {1}, info \"{2}\"",
                    enumType.Name,
                    (enumCustomAttributes[0] as VersionAttribute).Version,
                    (enumCustomAttributes[0] as VersionAttribute).Info);
            }
        }
    }
}
