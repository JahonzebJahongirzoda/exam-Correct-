using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class AddChallengeDto
{
    public int Id { get; set; }
    [Required,MaxLength(200)]
    public string Title { get; set; } 
    public string Description  { get; set; }

}