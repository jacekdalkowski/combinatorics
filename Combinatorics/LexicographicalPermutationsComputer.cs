namespace Combinatorics;

public class LexicographicalPermutationsComputer : IPermutationsComputer
{
    public IEnumerable<IEnumerable<int>> Compute(int sequenceLength)
    {
        var allPossibleElements = Enumerable.Range(1, sequenceLength);
        var lexicographicalPermutations = GenerateLexicographicalPermutations(Enumerable.Empty<int>(), allPossibleElements);
        return lexicographicalPermutations;
    }

    private IEnumerable<IEnumerable<int>> GenerateLexicographicalPermutations(IEnumerable<int> usedElements, IEnumerable<int> allPossibleElements)
    {
        var lexicographicalPermutations = new List<IEnumerable<int>>();
        var possibleElementsOnCurrentPosition = allPossibleElements.Where(possibleElement => !usedElements.Any(usedElement => usedElement == possibleElement));
        foreach(var possibleElementOnCurrentPosition in possibleElementsOnCurrentPosition)
        {
            var remainingLexicographicalPermutations = GenerateLexicographicalPermutations(usedElements: usedElements.Concat(new List<int>() {possibleElementOnCurrentPosition}), allPossibleElements);
            if (remainingLexicographicalPermutations.Count() > 0) 
            {
                foreach(var remainingLexicographicalPermutation in remainingLexicographicalPermutations) 
                {
                    lexicographicalPermutations.Add((new int[] { possibleElementOnCurrentPosition }).Concat(remainingLexicographicalPermutation).ToArray());
                }
            }
            else
            {
                lexicographicalPermutations.Add((new int[] { possibleElementOnCurrentPosition }));
            }
        }

        return lexicographicalPermutations;
    }
}
