using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EnigmatologistAI.Meander
{
    public class MeanderPuzzle
    {
        public MeanderPuzzle(int numberOfPoints)
        {
            Permutations = new List<PuzzlePermutation>();
            var sequences = new List<int>();
            for (var i = 1; i <= numberOfPoints; ++i)
            {
                sequences.Add(i);
            }
            var sequnenceList = MathHelpers.Permutation(sequences);

            Permutations = MathHelpers.Permutation(sequences)
                .Select(s => new PuzzlePermutation(s));
        }

        public IEnumerable<PuzzlePermutation> Permutations { get; set; }

    }
}
