using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyShop.Models;

public abstract class Person
{
    [StringLength(32)] public string LastName { set; get; }
    [StringLength(32)] public string FirstName { set; get; }

    [StringLength(32)] public string? MiddleName { set; get; } = null;
    [StringLength(32)] public string? Patronymic { set; get; } = null;

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string FullName { private set { } get => LastName + FirstName + MiddleName + Patronymic; }

    [DataType(DataType.Date)] public DateTime? BirthDate { set; get; } = null;
    [DataType(DataType.DateTime)] public DateTime RegisterDate { set; get; }
    
    [DataType(DataType.EmailAddress), StringLength(64)] public string EmailAddress { set; get; }
    [DataType(DataType.Password), StringLength(64)] public string Password { set; get; }
    [DataType(DataType.PhoneNumber), StringLength(16)] public string? PhoneNumber { set; get; } = null;

    public bool ConfirmedEmailAddress { set; get; } = false;
    public bool HasTwoFactorAuthorisation { set; get; } = false;
    public ushort AuthenticationFailCount { set; get; } = 0;    
}