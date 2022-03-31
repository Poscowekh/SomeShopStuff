using System.ComponentModel.DataAnnotations;

namespace EasyShop.Models;

public enum LoyaltyStatus 
{
    NoLoyaltyProgramCard = 0,
    HasLoyaltyProgramCard = 1,
    HasPremiumLoyaltyProgramCard = 2
}

public class User : BasicPerson
{
    public Cart? Cart { set; get; } = null;
    public List<Order>? Orders { set; get; } = null;

    public bool IsDeleted { set; get; } = false;

    public ushort FinishedOrders { set; get; } = 0;
    // public uint BonusPoints { set; get; } = 0;

    public User(UserRegisterForm form)
    {
        LastName = form.LastName;
        FirstName = form.FirstName;
        EmailAddress = form.EmailAddress;
        Password = form.Password;
    }
}

public class Cart
{
    public uint Id { set; get; }
    
    public uint UserId { set; get; }
    public User User { set; get; }

    [DataType(DataType.DateTime)] public DateTime CreationDate { set; get; }
    
    public ushort ProductCount { set; get; } = 0;
    public decimal TotalCost { set; get; } = decimal.Zero;

    public bool IsFinished { set; get; } = false;
    
    public List<Product>? Products { set; get; } = null;
}

public class UserRegisterForm
{
    [Required(ErrorMessage = "This field must be filled")]
    [StringLength(32, ErrorMessage = "Field length is limited to 32 characters")] 
    public string LastName { set; get; }
    
    [Required(ErrorMessage = "This field must be filled")]
    [StringLength(32, ErrorMessage = "Field length is limited to 32 characters")] 
    public string FirstName { set; get; }
    
    [Required(ErrorMessage = "This field must be filled")]
    [DataType(DataType.EmailAddress, ErrorMessage = "This is not a valid email address")] 
    [StringLength(64, ErrorMessage = "This field is limited to 64 characters")] 
    public string EmailAddress { set; get; }
    
    [Required(ErrorMessage = "This field must be filled")]
    [DataType(DataType.Password, ErrorMessage = "This is not a valid password")] 
    [StringLength(64, ErrorMessage = "This field is limited to 64 characters")] 
    public string Password { set; get; }
}