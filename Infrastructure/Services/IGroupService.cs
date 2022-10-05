using Domain.Dtos;

namespace Infrastructure.Services;

public interface IGroupService
{
    Task<Response<AddGroupDto>> AddGroup(AddGroupDto model);
    Task<Response<string>> DeleteGroup(int id);
    Task<Response<GetGroupDto>> GetGroupById(int id);
    Task<Response<List<GetGroupDto>>> GetGroups();
    Task<Response<AddGroupDto>> UpdateGroup(AddGroupDto location);
}