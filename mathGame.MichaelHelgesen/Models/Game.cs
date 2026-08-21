namespace mathGame.MichaelHelgesen.Models;
using mathGame.MichaelHelgesen.Enums;
using Spectre.Console;

internal class Game
{
    static readonly int numberOfTurns = 5;
    internal static GameData PlayRound(MenuItems gameType)
    {
        GameData playedGame = new GameData(gameType);

        for (int i = 0; i < numberOfTurns; i++)
        {
            GameTurn gameTurn = new();

            MathProblem mathProblem = new MathProblem(gameType);

            AnsiConsole.MarkupLine($"[bold blue]Spørsmål {i + 1} av 5[/]");

            int playerAnswer = AnsiConsole.Ask<int>($"Hva er [green]{mathProblem.AsString}[/]?");

            PlayerAnswer answer = new PlayerAnswer(mathProblem.CorrectAnswer, playerAnswer);

            gameTurn.MathProblem = mathProblem;
            gameTurn.PlayerAnswer = answer;

            playedGame.GameTurns.Add(gameTurn);

        }
        return playedGame;
    }
    public class GameTurn
    {
        public MathProblem MathProblem { get; set; }
        public PlayerAnswer PlayerAnswer { get; set; }
    }
    public class GameData(MenuItems gameType)
    {
        private static int _nextGameNumber = 1;
        public int GameNumber { get; } = _nextGameNumber++;
        public MenuItems GameType { get; set; } = gameType;
        public List<GameTurn> GameTurns { get; set; } = new();


        int Points()
        {
            int points = 0;
            foreach (var turn in GameTurns)
            {
                if (turn.PlayerAnswer.IsCorrect)
                    points++;
            }

            return points;
        }
    }
}