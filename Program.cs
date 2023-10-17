using System.Reflection;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EvenDigitNumberFinder finder = new EvenDigitNumberFinder();

            Console.Write("Enter an integer N: ");
            int N = int.Parse(Console.ReadLine());

            int closestEvenNumber = finder.FindClosestEvenNumber(N);

            Console.WriteLine($"The closest number with all even digits is: {closestEvenNumber}");

            // Fetch all class members (methods, constructors, properties) using reflection.
            Type type = typeof(EvenDigitNumberFinder);

            Console.WriteLine("Methods:");
            foreach (MethodInfo method in type.GetMethods())
            {
                Console.WriteLine(method.Name);
            }

            Console.WriteLine("\nConstructors:");
            foreach (ConstructorInfo constructor1 in type.GetConstructors())
            {
                Console.WriteLine(constructor1.Name);
            }

            Console.WriteLine("\nProperties:");
            foreach (PropertyInfo property in type.GetProperties())
            {
                Console.WriteLine(property.Name);
            }

            // Create an empty object (default constructor) of the class using reflection.
            EvenDigitNumberFinder finder1 = Activator.CreateInstance<EvenDigitNumberFinder>();

            Console.Write("Enter an integer N: ");
            int N1 = int.Parse(Console.ReadLine());

            int closestEvenNumber1 = finder1.FindClosestEvenNumber(N1);
            Console.WriteLine($"The closest number with all even digits is: {closestEvenNumber1}");

            // Create a parameterized object using reflection.
            ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(int), typeof(int) });
            if (constructor != null)
            {
                constructor.Invoke(new object[] { 42, 10 });
            }

            // 5) Invoke a method using reflection.
            MethodInfo findClosestEvenNumberMethod = type.GetMethod("FindClosestEvenNumber");
            if (findClosestEvenNumberMethod != null)
            {
                object[] methodParameters = { 17 }; 
                int result = (int)findClosestEvenNumberMethod.Invoke(finder, methodParameters);
                Console.WriteLine($"Result of invoking the method: {result}");
            }
        }
    }
}