namespace TaskFlowPro.Domain.Entities;

public class Role
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty; // e.g., Admin, Manager, Employee

    // Navigation properties
    public ICollection<User> Users { get; set; } = new List<User>();
}
