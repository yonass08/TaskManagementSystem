namespace TaskManagementSystem.Domain;

public class Task: BaseDomainEntity
{
    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime DueDate {get; set;}

    public int UserId { get; set; }

    public Status Status { get; set; } = Status.NotStarted;

    public int ProjectId {get; set;}

    public Project Project {get; set;}
    public User User {get; set;}


}