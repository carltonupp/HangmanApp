using Hangman.App.Grains;
using Hangman.App.Models;
using Microsoft.AspNetCore.Mvc;
using Orleans;

namespace Hangman.App.Controllers;

[Route("/api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IGrainFactory _grains;

    public GameController(IGrainFactory grains)
    {
        _grains = grains;
    }

    [HttpGet("/api/[controller]/start")]
    public async Task<IActionResult> StartGame()
    {
        var gameId = Guid.NewGuid()
            .GetHashCode()
            .ToString("X");

        var gameGrain = _grains.GetGrain<IGameGrain>(gameId);
        await gameGrain.StartGame("Godfather");

        return Ok(new CreatedGame(gameId));
    }

    [HttpGet("/api/[controller]/{gameId}")]
    public async Task<IActionResult> GetGameState(string gameId)
    {
        var game = _grains.GetGrain<IGameGrain>(gameId);
        return Ok(await game.GetState());
    }

    [HttpPost("/api/[controller]/{gameId}")]
    public async Task<IActionResult> Guess(string gameId, [FromBody]GuessModel guess)
    {
        var game = _grains.GetGrain<IGameGrain>(gameId);
        await game.Guess(guess.Letter);
        return Ok();
    }
}