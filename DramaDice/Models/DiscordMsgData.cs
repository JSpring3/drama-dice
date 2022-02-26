namespace DramaDice.Models;

public class DiscordMsgData
{
    public bool UsePlusOne { get; set; }
    public bool UseExploding { get; set; }
    public bool UseLegendary { get; set; }
    public string CharacterName { get; set; } = string.Empty;
    public string CharacterType { get; set; } = string.Empty;
    public int RaiseTotal { get; set; }
    public int ReRollTotal { get; set; }
    public int SuccessTarget { get; set; }
    public int SkilledSuccessTarget { get; set; }
    public int DicePool { get; set; }
    public List<Die> StartingDice { get; set; } = new();
    public List<Die> LiveDice { get; set; } = new();
    public List<Die> ExplodedDice { get; set; } = new();
    public List<Die> ReRollHistory { get; set; } = new();
    public List<Die> ReRollNewValues { get; set; } = new();
    public List<Die> TraitorDice { get; set; } = new();
    public List<RaiseGroup> SummedGroups { get; set; } = new();


}