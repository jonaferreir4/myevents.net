
namespace Domain.Entities;

public sealed class User : BaseEntity
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public DateOnly BirthDate { get; set; }
    public string? CPF { get; set; }
    public int Enrollment { get; set; }
    public string? Password { get; set; }


    public User(string name, string email, DateOnly birthDate, string cpf, int enrollment, string password)
    {
        Name = name;
        Email = email;
        BirthDate = birthDate;
        CPF = cpf;
        Enrollment = enrollment;
        Password = password;
    }
    public User() { }
    
    
    }
