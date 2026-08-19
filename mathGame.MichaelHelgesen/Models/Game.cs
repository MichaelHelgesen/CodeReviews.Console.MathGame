namespace mathGame.MichaelHelgesen.Models;

using mathGame.MichaelHelgesen.Enums;
using Microsoft.VisualBasic;
using Spectre.Console;

internal class Game
{
    private static int numberOfRounds = 5;

    internal List<GameData> playedGame;

    public class GameData
    {
        public string GameType { get; set; }
        //public List<Round> Rounds { get; set; } = new List<Round>();
    }

    internal static void PlayGame(MenuItems gameType)
    {
        GameData playedGame = new GameData();
        playedGame.GameType = gameType.ToString();

        for (int i = 0; i < numberOfRounds; i++)
        {
            // Create math problem
            // Save user input
            // Add to Game-object
            AnsiConsole.MarkupLine($"[bold blue]Spørsmål {i + 1} av 5[/]");
            int svar = AnsiConsole.Ask<int>("Hva er [green]5 + 5[/]?");
        }
        Console.WriteLine(playedGame.GameType);
        // return playedGame;
    }
}