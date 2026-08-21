namespace mathGame.MichaelHelgesen.Models;

using mathGame.MichaelHelgesen.Enums;
using Spectre.Console;

class Game
{
    static readonly int numberOfTurns = 5;
    internal static GameData PlayRound(MenuItems gameType)
    {
        List<GameTurn> turns = [];

        for (int i = 0; i < numberOfTurns; i++)
        {

            MathProblem mathProblem = new MathProblem(gameType);

            AnsiConsole.MarkupLine($"[bold blue]Spørsmål {i + 1} av 5[/]");

            int playerAnswer = AnsiConsole.Ask<int>($"Hva er [green]{mathProblem.AsString}[/]?");

            PlayerAnswer answer = new PlayerAnswer(mathProblem.CorrectAnswer, playerAnswer);

            GameTurn gameTurn = new GameTurn(mathProblem, answer);

            turns.Add(gameTurn);

        }
        GameData playedGame = new GameData(gameType, turns);
        return playedGame;
    }
    internal class GameTurn(MathProblem mathProblem, PlayerAnswer playerAnswer)
    {
        internal MathProblem MathProblem { get; } = mathProblem;
        internal PlayerAnswer PlayerAnswer { get; } = playerAnswer;
    }
    internal class GameData(MenuItems gameType, List<GameTurn> turns)
    {
        static int _nextGameNumber = 1;
        internal int GameNumber { get; } = _nextGameNumber++;
        internal MenuItems GameType { get; } = gameType;
        internal List<GameTurn> GameTurns { get; } = turns;


        internal int Points()
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