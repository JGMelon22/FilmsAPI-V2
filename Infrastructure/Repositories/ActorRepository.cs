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

    public async Task AddActor(ActorInput newActor)
    {
        var actor = newActor.Adapt<Actor>();

        await _dbContext.Actors.AddAsync(actor);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddActors(ActorInput[] newActors)
    {
        var actors = newActors.Adapt<Actor[]>();

        await _dbContext.Actors.AddRangeAsync(actors);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<ServiceResponse<ActorResult>> GetActorById(int id)
    {
        var serviceResponse = new ServiceResponse<ActorResult>();

        try
        {
            var actor = await _dbContext.Actors.FindAsync(id);

            if (actor == null)
                throw new Exception("Actor not found!");

            serviceResponse.Data = actor.Adapt<ActorResult>();
        }

        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<ActorResult>> GetActorByName(string actorName)
    {
        var serviceResponse = new ServiceResponse<ActorResult>();
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

            serviceResponse.Data = actor.Adapt<ActorResult>();
            _dbConnection.Close();
        }

        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<ActorResult>>> GetAllActors()
    {
        var serviceResponse = new ServiceResponse<List<ActorResult>>();
        var getActorsQuery =
                            """
                            SELECT actor_id AS ActorId, 
                                    actor_name AS ActorName,
                                    salary AS Salary,
                                    birthdate AS BirthDate
                            FROM actors;
                            """;

        _dbConnection.Open();

        var result = await _dbConnection.QueryAsync<ActorResult>(getActorsQuery);

        serviceResponse.Data = result.Adapt<List<ActorResult>>().ToList();

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

    public async Task<ServiceResponse<ActorResult>> UpdateActor(ActorInput updateActor)
    {
        var serviceResponse = new ServiceResponse<ActorResult>();

        try
        {
            var actor = await _dbContext.Actors.FindAsync(updateActor.ActorId);
            if (actor != null)
            {
                actor.Adapt<ActorInput>();

                actor.ActorName = updateActor.ActorName;
                actor.Salary = updateActor.Salary;
                actor.BirthDate = updateActor.BirthDate;

                await _dbContext.SaveChangesAsync();

                serviceResponse.Data = actor.Adapt<ActorResult>();
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