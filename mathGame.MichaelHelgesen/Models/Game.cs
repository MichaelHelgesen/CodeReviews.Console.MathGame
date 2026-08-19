namespace mathGame.MichaelHelgesen.Models;

using mathGame.MichaelHelgesen.Enums;
using Microsoft.VisualBasic;
using Spectre.Console;

internal class Game
{
    private static int numberOfTurns = 5;

    private static int points = 0;

    internal static List<GameTurn> gameTurns = new();

    public class GameTurn
    {
        public MathProblem MathProblem { get; set; }
        public PlayerAnswer PlayerAnswer { get; set; }
        //public int TurnNumber { get; set; }
    }
        public class GameData
        {
            public string GameType { get; set; }
            public List<GameTurn> GameTurns { get; set; }
        }
    
    internal static void PlayGame(MenuItems gameType)
    {
        GameData playedGame = new GameData();
        playedGame.GameType = gameType.ToString();

        for (int i = 0; i < numberOfTurns; i++)
        {
            // Initialize turn
            GameTurn gameTurn = new();

            // Create math problem(dice1, dice2, operator)
            MathProblem mathProblem = new MathProblem(gameType);

            // Turn number
            AnsiConsole.MarkupLine($"[bold blue]Spørsmål {i + 1} av 5[/]");

            // Generate question + collect answer
            int playerAnswer = AnsiConsole.Ask<int>($"Hva er [green]{mathProblem.AsString}[/]?");

            // Player answer
            PlayerAnswer answer = new PlayerAnswer(mathProblem.CorrectAnswer, playerAnswer);

            // Add math problem to list
            gameTurn.MathProblem = mathProblem;
            gameTurn.PlayerAnswer = answer;

            gameTurns.Add(gameTurn);

        }
        playedGame.GameTurns = gameTurns;

        foreach (var item in playedGame.GameTurns)
        {
            Console.WriteLine($"{item.MathProblem.FirstNumber} {item.MathProblem.Operator} {item.MathProblem.SecondNumber}");
            Console.WriteLine(item.PlayerAnswer.Answer);
            Console.WriteLine(item.MathProblem.CorrectAnswer);
            Console.WriteLine(item.PlayerAnswer.IsCorrect);
        }
        // return playedGame;
    }
}