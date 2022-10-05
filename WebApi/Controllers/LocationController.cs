using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class LocationController : ControllerBase
{
    private readonly ILocationService _locationService;

    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet]
    public async Task<Response<List<GEtLocationDto>>> Get()
    {
        var locations = await _locationService.GetLocations();
        return locations;
    }
    
    [HttpGet("{id}")]
    public async Task<Response<Location>> Get(int id)
    {
        var location = await _locationService.GetLocationById(id);
        return location;
    }
    
    [HttpPost]
    public async Task<Response<AddLocationDto>> Post(AddLocationDto location)
    {
        var newLocation = await _locationService.AddLocation(location);
        return newLocation;
    }
    
    [HttpPut]
    public async Task<Response<AddLocationDto>> Put(AddLocationDto location)
    {
        var updatedLocation = await _locationService.UpdateLocation(location);
        return updatedLocation;
    }
    
    [HttpDelete]
    public async Task<Response<string>> Delete(int id)
    {
        var location = await _locationService.DeleteLocation(id);
        return location;
    }

}