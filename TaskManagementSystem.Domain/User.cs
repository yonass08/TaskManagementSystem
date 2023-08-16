namespace TaskManagementSystem.Domain;
public class User: BaseDomainEntity
{

    public string UserName {get; set;}

    public string Email {get; set;}

    public string Password {get; set;}

    public  ICollection<Task> Tasks { get; set; }

    public  ICollection<Project> Projects { get; set; }
    

}