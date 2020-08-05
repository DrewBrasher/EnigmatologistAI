using System;
using System.Collections.Generic;
using System.Linq;

namespace EnigmatologistAI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public IEnumerable<IEnumerable<T>> Permutation<T>(IEnumerable<T> input)
        {
            if (input == null || !input.Any()) yield break;
            if (input.Count() == 1) yield return input;

            foreach (var item in input)
            {
                var next = input.Where(l => !l.Equals(item)).ToList();
                foreach (var perm in Permutation(next))
                {
                    yield return (new List<T> { item }).Concat(perm);
                }
            }
        }
    }
}
