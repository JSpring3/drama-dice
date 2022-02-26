namespace DramaDice.Models;

public class RaiseGroup
{
    public int Id { get; set; }
    public GroupingType RaiseGroupingType { get; set; } = GroupingType.Normal;
    public List<Die> DiceSet { get; set; } = new List<Die>();
    public int SuccessTarget { get; set; }
}