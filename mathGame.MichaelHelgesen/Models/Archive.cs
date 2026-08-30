namespace mathGame.MichaelHelgesen.Models;
using Spectre.Console;

class Archive
{
    internal List<Game.GameData> ArchivedGames = new();

    internal void ArchiveGameRound(Game.GameData game)
    {
        ArchivedGames.Add(game);
    }

    internal void DisplayLastGame()
    {
        if (ArchivedGames.Count == 0) return;

        DisplayArchive([ArchivedGames[^1]]);
    }

    internal void DisplayArchive()
    {
        DisplayArchive(ArchivedGames);
    }

    void DisplayArchive(List<Game.GameData> games)
    {
        foreach (var gameRound in games)
        {
            AnsiConsole.MarkupLine($"[bold blue]Game #{gameRound.GameNumber} - {gameRound.GameType}[/]");
            AnsiConsole.MarkupLine($"[dim]Time used:[/] [yellow]{gameRound.TimeUsed:mm\\:ss}[/]");
            AnsiConsole.MarkupLine($"[dim]Total points:[/]  [bold underline]{gameRound.Points()}[/]\n");

            for (int i = 0; i < gameRound.GameTurns.Count; i++)
            {
                var turn = gameRound.GameTurns[i];
                bool isCorrect = turn.PlayerAnswer.IsCorrect;

                string statusColor = isCorrect ? "green" : "red";
                string statusIcon = isCorrect ? "[✓]" : "[✗]";

                AnsiConsole.MarkupLine(
                    $"  [dim]Round {i + 1}:[/] {turn.MathProblem.AsString} = [bold]{turn.MathProblem.CorrectAnswer}[/]" +
                    $"\tYour answer: [{statusColor}]{turn.PlayerAnswer.Answer} [{statusIcon}][/]"
                );
            }

            AnsiConsole.WriteLine();
        }
    }
}