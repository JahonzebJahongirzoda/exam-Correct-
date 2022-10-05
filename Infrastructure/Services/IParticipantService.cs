using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.Services;

public interface IParticipantService
{
    Task<Response<AddParticipantDto>> AddParticipant(AddParticipantDto location);
    Task<Response<string>> DeleteParticipant(int id);
    Task<Response<GetParticipantDto>> GetParticipantById(int id);
    Task<Response<List<GetParticipantDto>>> GetParticipants();
    Task<Response<AddParticipantDto>> UpdateParticipant(AddParticipantDto location);
}