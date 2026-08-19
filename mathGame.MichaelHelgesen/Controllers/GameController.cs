namespace mathGame.MichaelHelgesen.Controllers;
using mathGame.MichaelHelgesen.Enums;
using mathGame.MichaelHelgesen.Models;
using Spectre.Console;


public class GameController()
{
    // DONE: Display message
    // Play Game
    // Archive game

    internal static void StartGame(MenuItems gameType)
    {
        // var game = List of rounds?
        DisplayStartMessage(gameType);
        Game.PlayGame(gameType);
    }

    internal static void DisplayStartMessage(MenuItems gameType)
    {
        AnsiConsole.Prompt(
    new TextPrompt<string>($"You selected: [yellow]{gameType}[/]. [grey]Press [bold]Enter[/] to continue...[/]")
        .AllowEmpty()
);
    }
}