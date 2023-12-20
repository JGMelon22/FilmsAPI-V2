using System.Data;
using Dapper;
using FilmsAPI_V2.DTOs.Actor;
using FilmsAPI_V2.Infrastructure.Data;
using FilmsAPI_V2.Interfaces;
using Mapster;

namespace FilmsAPI_V2.Infrastructure.Repositories;

public class ActorRepository : IActorRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IDbConnection _dbConnection;

    public ActorRepository(AppDbContext dbContext, IDbConnection dbConnection)
    {
        _dbContext = dbContext;
        _dbConnection = dbConnection;

    }

    public async Task AddActor(AddActorDto newActor)
    {
        var actor = newActor.Adapt<Actor>();

        await _dbContext.Actors.AddAsync(actor);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddActors(AddActorDto[] newActors)
    {
        var actors = newActors.Adapt<Actor[]>();

        await _dbContext.Actors.AddRangeAsync(actors);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<ServiceResponse<GetActorDto>> GetActorById(int id)
    {
        var serviceResponse = new ServiceResponse<GetActorDto>();

        try
        {
            var actor = await _dbContext.Actors.FindAsync(id);

            if (actor == null)
                throw new Exception("Actor not found!");

            serviceResponse.Data = actor.Adapt<GetActorDto>();
        }

        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<GetActorDto>> GetActorByName(string actorName)
    {
        var serviceResponse = new ServiceResponse<GetActorDto>();
        var getActorByNameQuery =
                                """
                                SELECT actor_id AS ActorId,
                                 	   actor_name AS ActorName,
                                 	   salary AS Salary,
                                 	   birthdate AS Birthdate 
                                FROM actors
                                WHERE actor_name = @actorName;
                                """;
        try
        {
            _dbConnection.Open();

            var actor = await _dbConnection.QueryFirstOrDefaultAsync<Actor>(getActorByNameQuery, new
            {
                ActorName = actorName
            });

            if (actor == null)
                throw new Exception("Actor not found!");

            serviceResponse.Data = actor.Adapt<GetActorDto>();
            _dbConnection.Close();
        }

        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetActorDto>>> GetAllActors()
    {
        var serviceResponse = new ServiceResponse<List<GetActorDto>>();
        var getActorsQuery =
                            """
                            SELECT actor_id AS ActorId, 
                                    actor_name AS ActorName,
                                    salary AS Salary,
                                    birthdate AS BirthDate
                            FROM actors;
                            """;

        _dbConnection.Open();

        var result = await _dbConnection.QueryAsync<GetActorDto>(getActorsQuery);

        serviceResponse.Data = result.Adapt<List<GetActorDto>>().ToList();

        _dbConnection.Close();

        return serviceResponse;
    }

    public async Task RemoveActor(int id)
    {
        var serviceResponse = new ServiceResponse<Actor>();

        try
        {
            var actor = await _dbContext.Actors.FindAsync(id);

            if (actor == null)
                throw new Exception("Actor not found!");

            _dbContext.Remove(actor);
            await _dbContext.SaveChangesAsync();
        }

        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
    }

    public async Task<ServiceResponse<GetActorDto>> UpdateActor(UpdateActorDto updateActor)
    {
        var serviceResponse = new ServiceResponse<GetActorDto>();

        try
        {
            var actor = await _dbContext.Actors.FindAsync(updateActor.ActorId);
            if (actor != null)
            {
                actor.Adapt<UpdateActorDto>();

                actor.ActorName = updateActor.ActorName;
                actor.Salary = updateActor.Salary;
                actor.BirthDate = updateActor.BirthDate;

                await _dbContext.SaveChangesAsync();

                serviceResponse.Data = actor.Adapt<GetActorDto>();
            }

            else
                throw new Exception("Actor to updated not found!");
        }

        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}