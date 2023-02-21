using Hangman.App.Models;
using Hangman.App.State;
using Orleans;
using Orleans.Runtime;

namespace Hangman.App.Grains;

public interface IGameGrain : IGrainWithStringKey
{
    Task StartGame(string word);
    Task<GameStateModel> GetState();
    Task Guess(char letter);
}

public class GameGrain : Grain, IGameGrain
{
    private readonly IPersistentState<GameState> _state;

    public GameGrain(
        [PersistentState(
            stateName: "game",
            storageName: "games")]
        IPersistentState<GameState> state)
    {
        _state = state;
    }

    public async Task StartGame(string word)
    {
        _state.State = new GameState
        {
            GameId = this.GetPrimaryKeyString(),
            Word = word
        };

        await _state.WriteStateAsync();
    }

    public Task<GameStateModel> GetState()
    {
        var progress = _state.State.Word
            .Select(letter => _state.State.UsedLetters.Contains(letter) ? letter : '_')
            .ToList();

        var response = new GameStateModel
        {
            UsedLetters = _state.State.UsedLetters,
            NumberOfGuesses = _state.State.Guesses,
            WordProgress = progress
        };
        
        return Task.FromResult(response);
    }

    public async Task Guess(char letter)
    {
        _state.State = _state.State with
        {
            Guesses = _state.State.Guesses + 1,
            UsedLetters = _state.State.UsedLetters.Append(letter).ToList(),
        };
        await _state.WriteStateAsync();
    }
}