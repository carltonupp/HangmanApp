using System.Diagnostics.Metrics;
using Hangman.Server.Grains;
using Hangman.Server.Models;
using Microsoft.AspNetCore.Http.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseOrleans(builder =>
{
    builder.UseLocalhostClustering();
    builder.AddMemoryGrainStorage("games");
});

var app = builder.Build();

app.MapGet("/", () => Results.Ok("Hello, World!"));

app.MapGet("/game/start", async (IGrainFactory grains, HttpRequest request) =>
{
    var gameId = Guid.NewGuid()
        .GetHashCode()
        .ToString("X");

    var gameGrain = grains.GetGrain<IGameGrain>(gameId);
    await gameGrain.StartGame("Godfather");

    var resultBuilder = new UriBuilder(request.GetEncodedUrl())
    {
        Path = $"/game/{gameId}"
    };

    return Results.Redirect(resultBuilder.Uri.ToString());

});

app.MapGet("/game/{gameId}", async (IGrainFactory grains, string gameId) =>
{
    var gameGrain = grains.GetGrain<IGameGrain>(gameId);
    return Results.Ok(await gameGrain.GetState());
});

app.MapPost("/game/{gameId}", async (IGrainFactory grains, string gameId, GuessModel guess) =>
{
    var gameGrain = grains.GetGrain<IGameGrain>(gameId);
    await gameGrain.Guess(guess.Letter);
    return Results.Ok();
});

await app.RunAsync();