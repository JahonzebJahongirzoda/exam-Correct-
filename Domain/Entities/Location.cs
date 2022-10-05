using System.ComponentModel.DataAnnotations;
using Domain.Entities;

public class Location
{
    public int Id { get; set; }
    [Required, MaxLength(200)]
    public string Title { get; set; }
    public string Description { get; set; }
    public virtual List<Participant> Participants { get; set; }
}