using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class GetParticipantDto
{
    public int Id { get; set; }
    [Required, MaxLength(60)]
    public string? FullName { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    [Required,MaxLength(13)]
    public string? Phone { get; set; }
    public DateTime CreatedAt { get; set; }
    public int GroupId { get; set; }
    public int LocationId { get; set; }
}