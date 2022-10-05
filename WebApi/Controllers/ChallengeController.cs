using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChallengeController : ControllerBase
{
    private readonly IChallengeService _challengeService;

    public ChallengeController(IChallengeService challengeService)
    {
        _challengeService = challengeService;
    }

    [HttpGet]
    public async Task<Response<List<GetChallengeDto>>> Get()
    {
        var challenges = await _challengeService.GetChallenges();
        return challenges;
    }
    
    [HttpGet("{id}")]
    public async Task<Response<GetChallengeDto>> Get(int id)
    {
        var challenge = await _challengeService.GetChallengeById(id);
        return challenge;
    }
    
    [HttpPost]
    public async Task<Response<AddChallengeDto>> Post(AddChallengeDto challenge)
    {
        var newChallenge = await _challengeService.AddChallenge(challenge);
        return newChallenge;
    }
    
    [HttpPut]
    public async Task<Response<AddChallengeDto>> Put(AddChallengeDto challenge)
    {
        var updatedChallenge = await _challengeService.UpdateChallenge(challenge);
        return updatedChallenge;
    }
    
    [HttpDelete]
    public async Task<Response<string>> Delete(int id)
    {
        var challenge = await _challengeService.DeleteChallenge(id);
        return challenge;
    }

}