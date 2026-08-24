namespace mathGame.MichaelHelgesen.Controllers;
using mathGame.MichaelHelgesen.Enums;
using mathGame.MichaelHelgesen.Models;
using Spectre.Console;


class GameController()
{
    internal static Archive archive = new();

    internal static void RunGame(GameType gameType)
    {
        Console.Clear();
        AnsiConsole.Prompt(
            new TextPrompt<string>($"[grey]Press [bold]Enter[/] when ready. Your game is beeing timed.[/]")
            .AllowEmpty()
        );
        Console.Clear();

        var gameRound = Game.PlayRound(gameType);
        archive.ArchiveGameRound(gameRound);

        Console.Clear();

        archive.DisplayLastGame();

        AnsiConsole.Prompt(
            new TextPrompt<string>($"[grey]Press [bold]Enter[/] to return to main menu.[/]")
            .AllowEmpty()
        );
        MenuController.RenderMainMenu();
    }
}

