using System.ComponentModel.DataAnnotations;

namespace EasyShop.Models;

public enum Gender
{
    NotStated,
    Male, 
    Female
}

public abstract class BasicPerson : BasicEntity
{
    public string FirstName { set; get; }
    public string LastName { set; get; }
    public string? UserName { set; get; }


    public Gender Gender { set; get; } = Gender.NotStated;
    
    public DateTime? BirthDate { set; get; } = null;
    
    // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    // public int Age 
    // { 
    //     private set { }
    //     get => (DateTime.Now.Year - BirthDate?.Year + (DateTime.Now.Day < BirthDate?.Day ? 1 : 0)) ?? -1;
    // }
    
    public string Email { set; get; }
    public string? PhoneNumber { set; get; }
    /// <summary>
    /// cringe TODO
    /// </summary>
    public string Password { set; get; }

    
    protected BasicPerson(BasicPersonForm form)
    {
        FirstName = form.FirstName;
        LastName = form.LastName;
        // UserName = form.UserName;
        
        Email = form.Email;
        // PhoneNumber = form.PhoneNumber;
        // cringe TODO
        Password = form.Password;

        // Gender = form.Gender;
        // BirthDate = form.BirthDate;
    }
}

/// <summary>
/// a.k.a. RegisterForm. TODO: add error messages and proper display names
/// </summary>
public abstract class BasicPersonForm
{
    [Required, StringLength(64)] 
    public string FirstName { set; get; }

    [Required, StringLength(64)] 
    public string LastName { set; get; }

    // public Gender? Gender { set; get; } = Models.Gender.NotStated;
    
    // [DataType(DataType.Date)]
    // public DateTime? BirthDate { set; get; } = null;

    // [StringLength(32)] 
    // public string? UserName { set; get; } = null;
    
    [Required, DataType(DataType.EmailAddress), StringLength(128)] 
    public string Email { set; get; }
    
    // [StringLength(16), DataType(DataType.PhoneNumber)] 
    // public string? PhoneNumber { set; get; } = null;
    
    [Required, DataType(DataType.Password), StringLength(32, MinimumLength = 8)]
    public string Password { set; get; }
    
    [Required, DataType(DataType.Password), StringLength(32, MinimumLength = 8), Compare(nameof(Password))]
    public string ConfirmPassword { set; get; }
}
