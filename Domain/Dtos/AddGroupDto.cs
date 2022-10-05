using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class AddGroupDto
{
    public int Id { get; set; } 
    [MaxLength(100)]
    public string GroupNick { get; set; }
    public int ChallangeId { get; set; }
    public bool NeededMember { get; set; }
    [MaxLength(300)]
    public string TeamSlogan { get; set; }
    public DateTime CreatedAt { get; set; }
}