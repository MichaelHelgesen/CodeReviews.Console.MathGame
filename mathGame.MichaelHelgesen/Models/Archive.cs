namespace mathGame.MichaelHelgesen.Models;

internal class Archive
{
    internal List<Game.GameData> ArchivedGames = new();
    internal void ArchiveGameRound(Game.GameData game)
    {
        ArchivedGames.Add(game);
    }

    internal void DisplayArchive()
    {
        foreach (var gameRound in ArchivedGames)
        {
            Console.WriteLine($"A game of {gameRound.GameType}");
            Console.WriteLine($"Game number: {gameRound.GameNumber}");
            foreach (var gameTurn in gameRound.GameTurns)
            {
                Console.WriteLine($"Math problem: {gameTurn.MathProblem.AsString}");
                Console.WriteLine($"Correct answer: {gameTurn.MathProblem.CorrectAnswer}");
                Console.WriteLine($"Player answer: {gameTurn.PlayerAnswer.Answer}");
                Console.WriteLine($"Player answer correct: {gameTurn.PlayerAnswer.IsCorrect}");
            }
        }
    }
}