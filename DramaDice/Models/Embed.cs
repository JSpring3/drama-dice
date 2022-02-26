// ReSharper disable InconsistentNaming
namespace DramaDice.Models;

public class Embed
{
    public string title { get; set; }
    public string description { get; set; } 
    public string url { get; set; } 
    public int color { get; set; }
    public IEnumerable<Field> fields { get; set; }
    public Author author { get; set; }
    public Thumbnail thumbnail { get; set; }

    public Embed(string title,string description,string url,int color,IEnumerable<Field> fields,Author author, Thumbnail thumbnail)
    {
        this.title = title;
        this.description = description;
        this.url = url;
        this.color = color;
        this.fields = fields;
        this.author = author;
        this.thumbnail = thumbnail;
    }
}