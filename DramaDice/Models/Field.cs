// ReSharper disable InconsistentNaming
namespace DramaDice.Models;

public class Field
{
    public string name { get; set; }
    public string value { get; set; }
    public bool inline { get; set; }

    public Field(string name, string value, bool inline = false)
    {
        this.name = name;
        this.value = value;
        this.inline = inline;
    }
}