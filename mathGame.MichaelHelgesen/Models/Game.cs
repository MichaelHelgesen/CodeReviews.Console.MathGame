namespace mathGame.MichaelHelgesen.Models;

using mathGame.MichaelHelgesen.Enums;
using Spectre.Console;
using System.Diagnostics;

class Game
{
    static readonly int numberOfTurns = 5;

    internal static Difficulty DifficultySetting { get; set; } = Difficulty.Easy;

    internal static GameData PlayRound(GameType gameType)
    {
        long startTimestamp = Stopwatch.GetTimestamp();

        List<GameTurn> turns = [];

        PlayTurns(gameType, turns);

        TimeSpan timeUsed = Stopwatch.GetElapsedTime(startTimestamp);

        GameData playedGame = new GameData(gameType, turns, timeUsed);

        return playedGame;
    }
    internal class GameTurn(MathProblem mathProblem, PlayerAnswer playerAnswer)
    {
        internal MathProblem MathProblem { get; } = mathProblem;
        internal PlayerAnswer PlayerAnswer { get; } = playerAnswer;
    }
    internal class GameData(GameType gameType, List<GameTurn> turns, TimeSpan timeUsed)
    {
        static int _nextGameNumber = 1;
        internal int GameNumber { get; } = _nextGameNumber++;
        internal TimeSpan TimeUsed { get; } = timeUsed;
        internal GameType GameType { get; } = gameType;
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

    static void PlayTurns(GameType gameType, List<GameTurn> turns)
    {
        for (int i = 0; i < numberOfTurns; i++)
        {
            Console.Clear();
            
            MathProblem mathProblem = new MathProblem(gameType);

            AnsiConsole.MarkupLine($"[bold blue]Question {i + 1} of 5[/]");

            int playerAnswer = AnsiConsole.Ask<int>($"What is [green]{mathProblem.AsString}[/]?");
            PlayerAnswer answer = new PlayerAnswer(mathProblem.CorrectAnswer, playerAnswer);
            GameTurn gameTurn = new GameTurn(mathProblem, answer);
            turns.Add(gameTurn);

        }
    }
}