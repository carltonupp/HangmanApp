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
}