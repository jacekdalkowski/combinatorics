namespace Combinatorics;

public class AntilexicographicalPermutationsComputer : IPermutationsComputer
{
    public IEnumerable<IEnumerable<int>> Compute(int sequenceLength)
    {
        var allPossibleElements = Enumerable.Range(1, sequenceLength);
        var lexicographicalPermutations = GenerateAntilexicographicalPermutations(Enumerable.Empty<int>(), allPossibleElements);
        return lexicographicalPermutations;
    }

    private IEnumerable<IEnumerable<int>> GenerateAntilexicographicalPermutations(IEnumerable<int> usedElements, IEnumerable<int> allPossibleElements)
    {
        var antilexicographicalPermutations = new List<IEnumerable<int>>();
        var possibleElements = allPossibleElements.Where(pe => usedElements.All(ue => ue != pe)).OrderByDescending(pe => pe);
        foreach(var pe in possibleElements)
        {
            var subpermutations = GenerateAntilexicographicalPermutations(usedElements.Concat(new int[] { pe }), allPossibleElements);
            if (subpermutations.Count() > 0) 
            {
                foreach(var subpermutation in subpermutations)
                {
                    var antilexicographicalPermutation = subpermutation.Concat(new int[] { pe });
                    antilexicographicalPermutations.Add(antilexicographicalPermutation);
                }
            }
            else
            {
                var antilexicographicalPermutation = (new int[] { pe });
                antilexicographicalPermutations.Add(antilexicographicalPermutation);
            }
        }
        return antilexicographicalPermutations;
    }
}
