// ReSharper disable InconsistentNaming
namespace DramaDice.Models;

public class DiscordMessage
{
    public string content { get; set; }
    public IEnumerable<Embed> embeds { get; set; }

    public DiscordMessage(IEnumerable<Embed> embeds, string content = "")
    {
        this.embeds = embeds;
        this.content = content;
    }

}
