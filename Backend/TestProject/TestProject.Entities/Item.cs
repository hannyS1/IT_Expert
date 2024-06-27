using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Entities;

[Table("items")]
public class Item
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("code")]
    public int Code { get; set; }
    
    [Column("value")]
    public string Value { get; set; }
}