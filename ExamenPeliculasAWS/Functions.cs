using System.Net;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;
using ExamenPeliculasAWS.Repositories;
using ExamenPeliculasAWS.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ExamenPeliculasAWS;

public class Functions
{

    private RepositoryPeliculas repo;

    public Functions(RepositoryPeliculas repo)
    {
        this.repo = repo;
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/peliculas")]
    public async Task<IHttpResult> GetPeliculas(ILambdaContext context)
    {
        context.Logger.LogInformation("Handling the 'Get' Request");
        List<Pelicula> peliculas = await this.repo.GetPeliculasAsync();
        return HttpResults.Ok(peliculas);
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/peliculas/{actor}")]
    public async Task<IHttpResult> GetPeliculasActores(string actor, ILambdaContext context)
    {
        context.Logger.LogInformation("Handling the 'GetActores' Request");
        List<Pelicula> peliculasActores = await this.repo.GetPeliculasActores(actor);
        return HttpResults.Ok(peliculasActores);
    }
}
