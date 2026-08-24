namespace mathGame.MichaelHelgesen.Controllers;

using mathGame.MichaelHelgesen.Enums;
using mathGame.MichaelHelgesen.Models;
using Spectre.Console;

class MenuController
{
    internal static void RenderMainMenu()
    {
        Console.Clear();

        AnsiConsole.MarkupLine("[bold blue]Welcome[/] to [green]the Math Game[/]!");
        AnsiConsole.MarkupLine($"[bold blue]Current difficulty:[/] [green]{Game.DifficultySetting}[/].\n");

        var mainMenuChoice = DisplayMainMenu();

        switch (mainMenuChoice)
        {
            case GameChoice.Play:
                DisplayGameMenu();
                break;
            case GameChoice.Results:
                DisplayResults(mainMenuChoice);
                break;
            case GameChoice.Difficulty:
                DisplayDifficultyMenu();
                break;
        }
    }

    private static void DisplayDifficultyMenu()
    {
        Console.Clear();
        var DifficultyChoices = Enum.GetValues<Difficulty>().Cast<Difficulty?>().ToList();
        DifficultyChoices.Add(null);
        var DifficultyChoice = AnsiConsole.Prompt(
             new SelectionPrompt<Difficulty?>()
                    .Title("Choose [green]difficulty[/] level:")
                .UseConverter(item => item.HasValue
                    ? GenerateDifficultyMenu(item.Value)
                    : "[yellow]<- Back to Main Menu[/]")
                .AddChoices(DifficultyChoices));
        if (DifficultyChoice == null)
        {
            RenderMainMenu();
            return;
        }
        Game.DifficultySetting = DifficultyChoice.Value;
        RenderMainMenu();
    }

    private static void DisplayResults(GameChoice mainMenuChoice)
    {
        Console.Clear();
        AnsiConsole.MarkupLine($"[yellow]{mainMenuChoice}[/]:\n");
        GameController.archive.DisplayArchive();
        AnsiConsole.Prompt(
            new TextPrompt<string>($"[grey]Press [bold]Enter[/] to return to main menu.[/]")
            .AllowEmpty()
        );
        RenderMainMenu();
    }
    private static void DisplayGameMenu()
    {
        Console.Clear();
        var GameChoices = Enum.GetValues<GameType>().Cast<GameType?>().ToList();
        GameChoices.Add(null);
        var gameChoice = AnsiConsole.Prompt(
             new SelectionPrompt<GameType?>()
                    .Title("Choose a [green]game mode[/] from the meny to continue.")
                    .UseConverter(item => item.HasValue
                    ? GenerateGameMenu(item.Value)
                    : "[yellow]<- Back to Main Menu[/]")
                    .AddChoices(GameChoices));
        if (gameChoice == null)
        {
            RenderMainMenu();
            return;
        }
        GameController.RunGame(gameChoice.Value);
    }

    private static GameChoice DisplayMainMenu()
    {
        var menuChoices = GenerateMainMenuChoices();
        var menuChoice = AnsiConsole.Prompt(
        new SelectionPrompt<GameChoice>()
            .Title("Please choose [green]an option[/] from the meny below")
            .UseConverter(item => GenerateMainMenuItem(item))
            .AddChoices(menuChoices));
        return menuChoice;
    }

    private static List<GameChoice> GenerateMainMenuChoices()
    {
        var choices = Enum.GetValues<GameChoice>().ToList();
        if (GameController.archive.ArchivedGames.Count < 1) choices.Remove(GameChoice.Results);
        return choices;
    }

    private static string GenerateMainMenuItem(GameChoice item)
    {
        return item switch
        {
            GameChoice.Difficulty => "🪜  Choose difficulty",
            GameChoice.Play => "▶️  Play a round of The Math Game",
            GameChoice.Results => "📊  Show results of previous games",
            GameChoice.Quit => "❌  Quit the game",
            _ => item.ToString()
        };
    }

    private static string GenerateGameMenu(GameType item)
    {
        return item switch
        {
            GameType.Addition => "➕  Add numbers (addition)",
            GameType.Subtraction => "➖  Subtract numbers (subtraction)",
            GameType.Division => "➗  Divide numbers (division)",
            GameType.Multiplication => "✖️  Multiply numbers (multiplication)",
            GameType.Random => "🔄 Random (random operators)",
            _ => item.ToString()
        };
    }

    private static string GenerateDifficultyMenu(Difficulty item)
    {
        bool isSelected = item == Game.DifficultySetting;

        string text = item switch
        {
            Difficulty.Easy => "Easy: up to 10",
            Difficulty.Normal => "Normal: up to 100",
            Difficulty.Hard => "Difficult: up to 1000",
            _ => item.ToString()
        };
        if (isSelected)
        {
            return $"[bold green]{text} (active)[/]";
        }

        // Ellers returneres teksten uendret/tonet ned
        return $"[grey]{text}[/]";
    }
}