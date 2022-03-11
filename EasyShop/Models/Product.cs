using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyShop.Models;

public class Product
{
    public uint Id { set; get; }
    
    [StringLength(128)] public string Name { set; get; }
    [StringLength(256)] public string Description { set; get; }
    
    [DataType(DataType.DateTime)] public DateTime CreationDate { set; get; }
    
    public Manufacturer Manufacturer { set; get; }
}

public class Manufacturer
{
    public uint Id { set; get; }
    
    [StringLength(128)] public string Name { set; get; }
    [StringLength(128), DataType(DataType.Url)] public string Website { set; get; }
    [StringLength(128), DataType(DataType.EmailAddress)] public string? EmailAddress { set; get; }
    
    public List<Product>? Products { set; get; } = null;
}

public class ProductScore
{
    [ComplexType]
    public class CommentaryType
    {
        public uint Id { set; get; }
        
        public string TimeOfUse { set; get; }
        public string Advantages { set; get; }
        public string Disadvantages { set; get; }
        public string? Additional { set; get; } = null;
    }
    
    public Product Product { set; get; }
    public uint ProductId { set; get; }
    
    public User User { set; get; }
    public uint UserId { set; get; }

    [Range(0, 10)]
    public ushort Value { set; get; }
    public CommentaryType? Commentary { set; get; } = null;
}