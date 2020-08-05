using System;
using System.Collections.Generic;
using System.Linq;
using EnigmatologistAI;
using EnigmatologistAI.Meander;

namespace EnigmatologistAI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 2; i <= 8; ++i)
            {
                var puzzle = new MeanderPuzzle(i);
                var total = puzzle.Permutations.Count();
                var valid = puzzle.Permutations.Count(p => p.IsValid);
                var invalid = puzzle.Permutations.Count(p => !p.IsValid);
                Console.WriteLine($"{i} points:\tpermutations: {total}\tValid: {valid}\tInvalid:{invalid}");
            }
        }
    }
}
