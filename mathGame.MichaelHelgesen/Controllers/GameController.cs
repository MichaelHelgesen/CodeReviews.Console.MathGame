namespace mathGame.MichaelHelgesen.Controllers;

using mathGame.MichaelHelgesen.Enums;
using mathGame.MichaelHelgesen.Models;
using Spectre.Console;


class GameController()
{
    internal static Archive archive = new();

    internal static void StartGame(GameType gameType)
    {
        AnsiConsole.Prompt(
            new TextPrompt<string>($"You selected: [yellow]{gameType}[/]. [grey]Press [bold]Enter[/] to continue...[/]")
            .AllowEmpty()
        );

        var gameRound = Game.PlayRound(gameType);

        archive.ArchiveGameRound(gameRound);

        DisplayGameResults(gameRound);

        MenuController.RenderMainMenu();
    }

    internal static void DisplayGameResults(Game.GameData gameRound)
    {
        Console.Clear();
        Console.WriteLine($"Round over. You scored: {gameRound.Points()}, in {gameRound.TimeUsed.ToString(@"mm\:ss")}");
        foreach (var q in gameRound.GameTurns)
        {
            Console.WriteLine($"{q.MathProblem.AsString} = {q.MathProblem.CorrectAnswer}\tYour answer: {q.PlayerAnswer.Answer}");
        }
        
        AnsiConsole.Prompt(
            new TextPrompt<string>($"[grey]Press [bold]Enter[/] to continue...[/]")
            .AllowEmpty()
        );
    }
}

