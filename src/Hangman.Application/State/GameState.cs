using Orleans;

namespace Hangman.App.State;

[GenerateSerializer]
public record GameState
{
    [Id(0)]
    public string GameId { get; set; }
    [Id(1)]
    public string Word { get; set; }

    [Id(2)] 
    public List<char> UsedLetters { get; set; } = new();
    [Id(3)] 
    public int Guesses { get; set; }
}