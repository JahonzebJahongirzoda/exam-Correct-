using System.Net;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ParticipantService : IParticipantService
{
    private readonly DataContext _context;

    public ParticipantService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetParticipantDto>>> GetParticipants()
    {
        var locations = await _context.Participants.Select(l=> new GetParticipantDto()
        {
            Id = l.Id,
            CreatedAt = l.CreatedAt,
            FullName = l.FullName,
            Email = l.Email,
            GroupId = l.GroupId, 
            LocationId = l.LocationId,
            Phone = l.Phone
        }).ToListAsync();
        return new Response<List<GetParticipantDto>>(locations);
    }

    //add location 
    public async Task<Response<AddParticipantDto>> AddParticipant(AddParticipantDto model)
    {
        try
        {
            var participant = new Participant()
            {
                Id = model.Id,
                CreatedAt = model.CreatedAt,
                FullName = model.FullName,
                Email = model.Email,
                GroupId = model.GroupId,
                LocationId = model.LocationId,
                Phone = model.Phone
            };
            await _context.Participants.AddAsync(participant);
            await _context.SaveChangesAsync();
            model.Id = participant.Id;
            return new Response<AddParticipantDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<AddParticipantDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<GetParticipantDto>> GetParticipantById(int id)
    {
        var find = await _context.Participants.FindAsync(id);
        if (find == null) return new Response<GetParticipantDto>(HttpStatusCode.NotFound, "");
        var participant = new GetParticipantDto()
        {
            Id = find.Id,
            FullName = find.FullName,
            CreatedAt = find.CreatedAt,
            Email = find.Email,
            Phone = find.Phone,
            LocationId = find.LocationId,
            GroupId = find.GroupId
        };
        return new Response<GetParticipantDto>(participant);
    }

    //add location 
    public async Task<Response<AddParticipantDto>> UpdateParticipant(AddParticipantDto participantDto)
    {
        try
        {
            var finds = await _context.Participants.FindAsync(participantDto.Id);
            if (finds == null) return new Response<AddParticipantDto>(System.Net.HttpStatusCode.NotFound, "");

            // if location is found
            finds.FullName = participantDto.FullName;
            finds.Id = participantDto.Id;
            finds.Email = participantDto.Email; 
            finds.Phone = participantDto.Phone;
            finds.GroupId = participantDto.GroupId; 
            finds.CreatedAt = participantDto.CreatedAt;
            finds.LocationId = participantDto.LocationId;
            
            await _context.SaveChangesAsync();
            return new Response<AddParticipantDto>(participantDto);
        }
        catch (System.Exception ex)
        {
            return new Response<AddParticipantDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    //add location 
    public async Task<Response<string>> DeleteParticipant(int id)
    {
        try
        {
            var find = await _context.Participants.FindAsync(id);
            if (find == null) return new Response<string>(System.Net.HttpStatusCode.NotFound, "");

            _context.Participants.Remove(find);
            await _context.SaveChangesAsync();
            return new Response<string>("removed successfully");
        }
        catch (System.Exception ex)
        {
            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}