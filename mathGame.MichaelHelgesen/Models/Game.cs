namespace mathGame.MichaelHelgesen.Models;

using mathGame.MichaelHelgesen.Enums;
using Microsoft.VisualBasic;
using Spectre.Console;

internal class Game
{
    private static int numberOfTurns = 5;

    internal static List<GameTurn> gameTurns = new();

    public class GameTurn
    {
        public MathProblem MathProblem { get; set; }
        public PlayerAnswer PlayerAnswer { get; set; }
        public int TurnNumber { get; set; }
    }
    /*
        public class GameData
        {
            public string GameType { get; set; }
            public List<GameRound> Rounds { get; set; } = new List<GameRound>();
        }
    */
    internal static void PlayGame(MenuItems gameType)
    {
        //GameData playedGame = new GameData();
        //playedGame.GameType = gameType.ToString();

        for (int i = 0; i < numberOfTurns; i++)
        {
            // Initialize turn
            GameTurn gameTurn = new();

            // Roll dice 1
            int dice1 = Dice.RollDice(10);
            // Roll dice 2
            int dice2 = Dice.RollDice(10);

            // Create math problem(dice1, dice2, operator)
            MathProblem mathProblem = new MathProblem(dice1, dice2, "+");

            // Turn number
            AnsiConsole.MarkupLine($"[bold blue]Spørsmål {i + 1} av 5[/]");

            // Generate question + collect answer
            int svar = AnsiConsole.Ask<int>($"Hva er [green]{dice1} + {dice2}[/]?");

            // Player answer
            PlayerAnswer playerAnswer = new PlayerAnswer(mathProblem.MathProblemAsString, mathProblem.CorrectAnswer, svar);

            // Add math problem to list
            gameTurn.MathProblem = mathProblem;

            // Add

            gameTurn.PlayerAnswer = playerAnswer;
            gameTurn.TurnNumber = i + 1;
            gameTurns.Add(gameTurn);

        }
        foreach (var item in gameTurns)
        {
            Console.WriteLine(item.MathProblem.MathProblemAsString);
            Console.WriteLine(item.PlayerAnswer.Answer);
            Console.WriteLine(item.PlayerAnswer.IsCorrect);
            Console.WriteLine(item.TurnNumber);
        }
        // return playedGame;
    }
}