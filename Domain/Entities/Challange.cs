using System.ComponentModel.DataAnnotations;

public class Challange
{   
    public int Id { get; set; }
    [Required,MaxLength(200)]
    public string Title { get; set; } 
    public string Description  { get; set; }

    public virtual List<Group> Groups { get; set; }
}
