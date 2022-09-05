namespace Combinatorics;

public interface IPermutationsComputer
{
    public IEnumerable<IEnumerable<int>> Compute(int sequenceLength);
}