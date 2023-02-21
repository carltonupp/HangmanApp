using Orleans;

namespace Hangman.App.Models;

[GenerateSerializer]
public record GameStateModel
{
    [Id(0)]
    public int NumberOfGuesses { get; init; }
    [Id(1)]
    public IEnumerable<char> UsedLetters { get; init; }
    [Id(2)]
    public IEnumerable<char> WordProgress { get; init; }
}