namespace Domain.Dtos;

public class GetGroupDto
{
    public int Id { get; set; } 
    public string GroupNick { get; set; }
    public int ChallangeId { get; set; }
    public bool NeededMember { get; set; }
    public string TeamSlogan { get; set; }
    public DateTime CreatedAt { get; set; }
}