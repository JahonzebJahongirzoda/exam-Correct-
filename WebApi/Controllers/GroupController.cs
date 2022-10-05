using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupController : ControllerBase
{
    private readonly IGroupService _groupService;

    public GroupController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet]
    public async Task<Response<List<GetGroupDto>>> Get()
    {
        var groups = await _groupService.GetGroups();
        return groups;
    }
    
    [HttpGet("{id}")]
    public async Task<Response<GetGroupDto>> Get(int id)
    {
        var group = await _groupService.GetGroupById(id);
        return group;
    }
    
    [HttpPost]
    public async Task<Response<AddGroupDto>> Post(AddGroupDto group)
    {
        var newGroup = await _groupService.AddGroup(group);
        return newGroup;
    }
    
    [HttpPut]
    public async Task<Response<AddGroupDto>> Put(AddGroupDto group)
    {
        var updatedGroup = await _groupService.UpdateGroup(group);
        return updatedGroup;
    }
    
    [HttpDelete]
    public async Task<Response<string>> Delete(int id)
    {
        var group = await _groupService.DeleteGroup(id);
        return group;
    }

}