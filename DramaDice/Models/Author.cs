// ReSharper disable InconsistentNaming
namespace DramaDice.Models;

public class Author
{
    public string name { get; set; } 
    public string url { get; set; }
    public string icon_url { get; set; }

    public Author(string name, string url, string iconUrl)
    {
        this.name = name;
        this.url = url;
        icon_url = iconUrl;
    }
}