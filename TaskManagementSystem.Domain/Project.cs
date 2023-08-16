namespace TaskManagementSystem.Domain;

public class Project: BaseDomainEntity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public int OwnerId {get; set;}

     public  ICollection<Task> Tasks { get; set; }

}
