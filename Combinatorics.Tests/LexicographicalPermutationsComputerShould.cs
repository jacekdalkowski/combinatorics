using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Combinatorics.Tests;

public class LexicographicalPermutationsComputerShould
{
    [Fact]
    public void GenerateLexicographicalPermutations()
    {
        var lexicographicalPermutationsComputer = new LexicographicalPermutationsComputer();

        var computedPermutations = lexicographicalPermutationsComputer.Compute(3);

        IEnumerable<int[]> lexicographicalPermutations = new List<int[]>()
        { 
            new int[] { 1, 2, 3 },
            new int[] { 1, 3, 2 },
            new int[] { 2, 1, 3 },
            new int[] { 2, 3, 1 },
            new int[] { 3, 1, 2 },
            new int[] { 3, 2, 1 },
        };
        Xunit.Assert.Equal(6, computedPermutations.Count());
        for(int i = 0; i < 6; i++)
        {
            Xunit.Assert.Equal(lexicographicalPermutations.ElementAt(i), computedPermutations.ElementAt(i));
        }
    }
}