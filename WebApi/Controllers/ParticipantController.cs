using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ParticipantController : ControllerBase
{
    private readonly IParticipantService _groupService;

    public ParticipantController(IParticipantService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet]
    public async Task<Response<List<GetParticipantDto>>> Get()
    {
        var groups = await _groupService.GetParticipants();
        return groups;
    }
    
    [HttpGet("{id}")]
    public async Task<Response<GetParticipantDto>> Get(int id)
    {
        var group = await _groupService.GetParticipantById(id);
        return group;
    }
    
    [HttpPost]
    public async Task<Response<AddParticipantDto>> Post(AddParticipantDto group)
    {
        var newParticipant = await _groupService.AddParticipant(group);
        return newParticipant;
    }
    
    [HttpPut]
    public async Task<Response<AddParticipantDto>> Put(AddParticipantDto group)
    {
        var updatedParticipant = await _groupService.UpdateParticipant(group);
        return updatedParticipant;
    }
    
    [HttpDelete]
    public async Task<Response<string>> Delete(int id)
    {
        var group = await _groupService.DeleteParticipant(id);
        return group;
    }

}