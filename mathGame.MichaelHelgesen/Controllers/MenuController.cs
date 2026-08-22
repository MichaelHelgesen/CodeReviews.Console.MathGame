namespace mathGame.MichaelHelgesen.Controllers;

using mathGame.MichaelHelgesen.Enums;
using mathGame.MichaelHelgesen.Models;
using Spectre.Console;

// DONE: Users should be presented with a menu to choose an operation
// DONE: A game needs to have at least 5 questions.
// DONE: The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.
// DONE: You need to create a game that consists of asking the player what's the result of a math question (i.e. 9 x 9 = ?), collecting the input and adding a point in case of a correct answer.
// DONE: You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.
// DONE: To follow the DRY Principle, try using just one method for all games. Additionally, double check your project and try to find opportunities to achieve the same functionality with less code, avoiding repetition when possible.
// DONE: Create a 'Random Game' option where the players will be presented with questions from random operations
// DONE: Try to implement levels of difficulty.
// DONE: Add a timer to track how long the user takes to finish the game.


class MenuController
{
    internal static void RenderMainMenu()
    {
        Console.Clear();

        AnsiConsole.MarkupLine("[bold blue]Welcome[/] to [green]the Math Game[/]!");

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
        var DifficultyChoices = Enum.GetValues<Difficulty>().ToList();
        var DifficultyChoice = AnsiConsole.Prompt(
             new SelectionPrompt<Difficulty>()
                    .Title("Choose [green]game type[/] would you like?")
                    .UseConverter(item => GenerateDifficultyMenu(item))
                    .AddChoices(DifficultyChoices));
        Game.DifficultySetting = DifficultyChoice;
        RenderMainMenu();
    }

    private static void DisplayResults(GameChoice mainMenuChoice)
    {
        Console.Clear();
        AnsiConsole.MarkupLine($"You selected: [yellow]{mainMenuChoice}[/]");
        GameController.archive.DisplayArchive();
        AnsiConsole.Prompt(
            new TextPrompt<string>($"[grey]Press [bold]Enter[/] to continue...[/]")
            .AllowEmpty()
        );
        RenderMainMenu();
    }
    private static void DisplayGameMenu()
    {
        var GameChoices = Enum.GetValues<GameType>().ToList();
        var gameChoice = AnsiConsole.Prompt(
             new SelectionPrompt<GameType>()
                    .Title("Choose [green]game type[/] would you like?")
                    .UseConverter(item => GenerateGameMenu(item))
                    .AddChoices(GameChoices));
        GameController.StartGame(gameChoice);
    }

    private static GameChoice DisplayMainMenu()
    {
        var menuChoices = GenerateMenuChoices();
        var menuChoice = AnsiConsole.Prompt(
        new SelectionPrompt<GameChoice>()
            .Title("Choose [green]game type[/] would you like?")
            .UseConverter(item => GenerateMainMenuItem(item))
            .AddChoices(menuChoices));
        return menuChoice;
    }

    private static List<GameChoice> GenerateMenuChoices()
    {
        var choices = Enum.GetValues<GameChoice>().ToList();
        if (GameController.archive.ArchivedGames.Count < 1) choices.Remove(GameChoice.Results);
        return choices;
    }

    private static string GenerateMainMenuItem(GameChoice item)
    {
        return item switch
        {
            GameChoice.Difficulty => "Velg vanskelighetsgrad",
            GameChoice.Play => "Spill en runde",
            GameChoice.Results => "📊 Vis tidligere resultat og statistikk",
            GameChoice.Quit => "❌ Avslutt spillet",
            _ => item.ToString()
        };
    }

    private static string GenerateGameMenu(GameType item)
    {
        return item switch
        {
            GameType.Addition => "➕ Legg sammen tall (Addisjon)",
            GameType.Subtraction => "➖ Trekk fra tall (Subtraksjon)",
            GameType.Division => "Dele",
            GameType.Multiplication => "* Gange",
            _ => item.ToString()
        };
    }

    private static string GenerateDifficultyMenu(Difficulty item)
    {
        bool isSelected = item == Game.DifficultySetting;

        string text = item switch
        {
            Difficulty.Easy => "Easy: Opp til 10",
            Difficulty.Normal => "Normal: Opp til 100",
            Difficulty.Hard => "Difficult: Opp til 1000",
            _ => item.ToString()
        };
        if (isSelected)
        {
            return $"[bold green]{text} (Aktiv)[/]";
        }

        // Ellers returneres teksten uendret/tonet ned
        return $"[grey]{text}[/]";
    }
}