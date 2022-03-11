using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyShop.Models;

public class Order
{
    public uint Id { set; get; }
    
    [DataType(DataType.DateTime)] public DateTime CreationDate { set; get; }
    [DataType(DataType.DateTime)] public DateTime? FinishedDate { set; get; }

    public bool IsAborted { set; get; } = false;
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)] 
    public bool IsFinished { private set { } get => FinishedDate is not null; }
    
    public uint UserId { set; get; }
    public User User { set; get; }
    
    public Cart FromCart { set; get; }
    public List<Product> Products { set; get; }

    public ushort ProductCount { set; get; } = 0;
    public decimal TotalCost { set; get; } = decimal.Zero;
}
