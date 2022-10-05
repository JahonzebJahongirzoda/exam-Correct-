using Domain.Dtos;

namespace Infrastructure.Services;

public interface IChallengeService
{
    Task<Response<AddChallengeDto>> AddChallenge(AddChallengeDto model);
    Task<Response<string>> DeleteChallenge(int id);
    Task<Response<GetChallengeDto>> GetChallengeById(int id);
    Task<Response<List<GetChallengeDto>>> GetChallenges();
    Task<Response<AddChallengeDto>> UpdateChallenge(AddChallengeDto location);
}