using mathGame.MichaelHelgesen.Enums;
using Spectre.Console;

namespace mathGame.MichaelHelgesen.Controllers;
public class GameController()
{
    // DONE: Display message
    // Play 5 rounds
    // Archive game

    internal static void PlayGame(MenuItems gameType)
    {
        DisplayStartMessage(gameType);
        PlayGame(gameType);
    }

    internal static void DisplayStartMessage(MenuItems gameType)
    {
        AnsiConsole.Prompt(
    new TextPrompt<string>($"You selected: [yellow]{gameType}[/]. [grey]Press [bold]Enter[/] to continue...[/]")
        .AllowEmpty()
);
    }
}