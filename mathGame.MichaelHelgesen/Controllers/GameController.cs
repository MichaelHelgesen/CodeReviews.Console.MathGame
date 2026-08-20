namespace mathGame.MichaelHelgesen.Controllers;

using mathGame.MichaelHelgesen.Enums;
using mathGame.MichaelHelgesen.Models;
using Spectre.Console;


public class GameController()
{
    // DONE: Display message
    // Play Game
    // Archive game
    internal static Archive archive = new();
    // Etablere arkiv
    internal static void StartGame(MenuItems gameType)
    {
        DisplayStartMessage(gameType);
        var gameRound = Game.PlayRound(gameType);
        archive.ArchiveGameRound(gameRound);
        MenuController.Run();
    }

    internal static void DisplayStartMessage(MenuItems gameType)
    {
        AnsiConsole.Prompt(
    new TextPrompt<string>($"You selected: [yellow]{gameType}[/]. [grey]Press [bold]Enter[/] to continue...[/]")
        .AllowEmpty()
);
    }
}