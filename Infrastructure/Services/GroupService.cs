using System.Net;
using Domain.Dtos;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class GroupService : IGroupService
{
    private readonly DataContext _context;

    public GroupService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetGroupDto>>> GetGroups()
    {
        var locations = await _context.Groups.Select(l=> new GetGroupDto()
        {
            ChallangeId = l.ChallangeId,
            CreatedAt = l.CreatedAt,
            GroupNick = l.GroupNick,
            NeededMember = l.NeededMember,
            TeamSlogan = l.TeamSlogan
        }).ToListAsync();
        return new Response<List<GetGroupDto>>(locations);
    }

    //add location 
    public async Task<Response<AddGroupDto>> AddGroup(AddGroupDto model)
    {
        try
        {
            var group = new Group()
            {
                ChallangeId = model.ChallangeId,
                CreatedAt = model.CreatedAt,
                GroupNick = model.GroupNick,
                NeededMember = model.NeededMember,
                TeamSlogan = model.TeamSlogan
            };
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();
            model.Id = group.Id;
            return new Response<AddGroupDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<AddGroupDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<GetGroupDto>> GetGroupById(int id)
    {
        var find = await _context.Groups.FindAsync(id);
        if (find == null) return new Response<GetGroupDto>(HttpStatusCode.NotFound, "");
        var group = new GetGroupDto()
        {
            Id = find.Id,
            ChallangeId = find.ChallangeId,
            CreatedAt = find.CreatedAt,
            GroupNick = find.GroupNick,
            NeededMember = find.NeededMember,
            TeamSlogan = find.TeamSlogan,
        };
        return new Response<GetGroupDto>(group);
    }

    //add location 
    public async Task<Response<AddGroupDto>> UpdateGroup(AddGroupDto groupDto)
    {
        try
        {
            var finds = await _context.Groups.FindAsync(groupDto.Id);
            if (finds == null) return new Response<AddGroupDto>(System.Net.HttpStatusCode.NotFound, "");

            // if location is found
            finds.ChallangeId = groupDto.ChallangeId;
            finds.Id = groupDto.Id;
            finds.GroupNick = groupDto.GroupNick; 
            finds.NeededMember = groupDto.NeededMember;
            finds.TeamSlogan = groupDto.TeamSlogan; 
            finds.CreatedAt = groupDto.CreatedAt;
            
            await _context.SaveChangesAsync();
            return new Response<AddGroupDto>(groupDto);
        }
        catch (System.Exception ex)
        {
            return new Response<AddGroupDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    //add location 
    public async Task<Response<string>> DeleteGroup(int id)
    {
        try
        {
            var find = await _context.Groups.FindAsync(id);
            if (find == null) return new Response<string>(System.Net.HttpStatusCode.NotFound, "");

            _context.Groups.Remove(find);
            await _context.SaveChangesAsync();
            return new Response<string>("removed successfully");
        }
        catch (System.Exception ex)
        {
            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}