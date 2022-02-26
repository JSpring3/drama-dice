namespace DramaDice.Models;

public class Die
{
    public int Id { get; set; }
    public int Value { get; set; }

    public bool IsLegendary { get; set; }
    public DieStatus Status { get; set; } = DieStatus.New;
    public DieCategory Category { get; set; } = DieCategory.Live;

}

public enum DieStatus
{
    New = 0,
    InGroup = 1
}

public enum DieCategory
{
    Live = 1,
    Exploding = 2
}