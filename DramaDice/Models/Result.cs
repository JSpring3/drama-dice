namespace DramaDice.Models;

public class Result
{
    public List<Die> LiveDice { get; set; }
    public List<Die> ExplodedDice { get; set; }
    public List<Die> AllDice { get; set; }

    public Result(IEnumerable<Die> liveDice,IEnumerable<Die> explodedDice, IEnumerable<Die> allDice, DiceSort diceSort = DiceSort.RollOrder)
    {
        LiveDice = SortDice(diceSort, liveDice);
        ExplodedDice = SortDice(diceSort, explodedDice);
        AllDice = SortDice(diceSort, allDice);
    }
    private static List<Die> SortDice(DiceSort diceSort, IEnumerable<Die> diceList)
    {
        return diceSort switch
        {
            DiceSort.Ascending => diceList.OrderBy(x => x.Value).ToList(),
            DiceSort.Descending => diceList.OrderByDescending(x => x.Value).ToList(),
            DiceSort.RollOrder => diceList.OrderBy(x => x.Id).ToList(),
            _ => diceList.ToList()
        };
    }
}

public enum DiceSort
{
    RollOrder = 0,
    Ascending = 1,
    Descending = 2
}