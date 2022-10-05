using Domain.Dtos;
using Infrastructure.Context;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

public  class LocationService : ILocationService
{
    private readonly DataContext _context;

    public LocationService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GEtLocationDto>>> GetLocations()
    {
        var locations = await _context.Locations.Select(l=> new GEtLocationDto()
        {
            Description = l.Description,
            Id = l.Id,
            Title = l.Title
        }).ToListAsync();
        return new Response<List<GEtLocationDto>>(locations);
    }

    //add location 
    public async Task<Response<AddLocationDto>> AddLocation(AddLocationDto model)
    {
        try
        {
            var location = new Location()
            {
                Description = model.Description,
                Title = model.Title
            };
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();
            model.Id = location.Id;
            return new Response<AddLocationDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<AddLocationDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<Location>> GetLocationById(int id)
    {
        var find = await _context.Locations.FindAsync(id);
        return new Response<Location>(find);
    }

    //add location 
    public async Task<Response<AddLocationDto>> UpdateLocation(AddLocationDto location)
    {
        try
        {
            var find = await _context.Locations.FindAsync(location.Id);
            if (find == null) return new Response<AddLocationDto>(System.Net.HttpStatusCode.NotFound, "");

            // if location is found
            find.Description = location.Description;
            find.Title = location.Title;
            await _context.SaveChangesAsync();
            return new Response<AddLocationDto>(location);
        }
        catch (System.Exception ex)
        {
            return new Response<AddLocationDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    //add location 
    public async Task<Response<string>> DeleteLocation(int id)
    {
        try
        {
            var find = await _context.Locations.FindAsync(id);
            if (find == null) return new Response<string>(System.Net.HttpStatusCode.NotFound, "");

            _context.Locations.Remove(find);
            await _context.SaveChangesAsync();
            return new Response<string>("removed successfully");
        }
        catch (System.Exception ex)
        {
            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}

