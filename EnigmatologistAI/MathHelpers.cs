using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnigmatologistAI
{
    public static class MathHelpers
    {
        /// <summary>
        /// Generating all permutations of a list. Credit: https://blog.kulman.sk/generating-all-permutations-of-a-list-how-hard-can-that-be/
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Permutation<T>(IEnumerable<T> input)
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
