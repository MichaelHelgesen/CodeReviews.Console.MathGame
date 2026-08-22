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
        MenuController.RenderMainMenu();
    }
}