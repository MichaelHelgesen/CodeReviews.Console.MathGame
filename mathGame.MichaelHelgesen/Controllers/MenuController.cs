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

// TODO: Add a timer to track how long the user takes to finish the game.

class MenuController
{
    internal static void Run()
    {
        Console.Clear();

        AnsiConsole.MarkupLine("[bold blue]Welcome[/] to [green]the Math Game[/]!");

        var playerChoice = DisplayMainMenu();

        switch (playerChoice)
        {
            case MenuItems.Play:
                DisplayGameMenu();
                break;
            case MenuItems.Results:
                DisplayResults(playerChoice);
                break;
            case MenuItems.Difficulty:
                DisplayDifficultyMenu();
                break;
        }
    }

    private static void DisplayDifficultyMenu()
    {
        var difficulty = Enum.GetValues<Difficulty>().ToList();
        var difficultyChoice = AnsiConsole.Prompt(
             new SelectionPrompt<Difficulty>()
                    .Title("Choose [green]game type[/] would you like?")
                    .AddChoices(difficulty));
        Game.DifficultySetting = difficultyChoice;
        Run();
    }

    private static void DisplayResults(MenuItems playerChoice)
    {
        Console.Clear();
        AnsiConsole.MarkupLine($"You selected: [yellow]{playerChoice}[/]");
        GameController.archive.DisplayArchive();
        AnsiConsole.Prompt(
            new TextPrompt<string>($"[grey]Press [bold]Enter[/] to continue...[/]")
            .AllowEmpty()
        );
        Run();
    }
    private static void DisplayGameMenu()
    {
        var choices = Enum.GetValues<Menu>().ToList();
        var menuChoice = AnsiConsole.Prompt(
             new SelectionPrompt<Menu>()
                    .Title("Choose [green]game type[/] would you like?")
                    .UseConverter(item => GenerateGameMenu(item))
                    .AddChoices(choices));
        GameController.StartGame(menuChoice);
    }

    private static MenuItems DisplayMainMenu()
    {
        var menuChoices = GenerateMenuChoices();
        var menuChoice = AnsiConsole.Prompt(
        new SelectionPrompt<MenuItems>()
            .Title("Choose [green]game type[/] would you like?")
            .UseConverter(item => GenerateMenuItems(item))
            .AddChoices(menuChoices));
        return menuChoice;
    }

    private static List<MenuItems> GenerateMenuChoices()
    {
        var choices = Enum.GetValues<MenuItems>().ToList();
        if (GameController.archive.ArchivedGames.Count < 1) choices.Remove(MenuItems.Results);
        return choices;
    }

    private static string GenerateMenuItems(MenuItems item)
    {
        return item switch
        {
            MenuItems.Difficulty => "Velg vanskelighetsgrad",
            MenuItems.Play => "Spill en runde",
            MenuItems.Results => "📊 Vis tidligere resultat og statistikk",
            MenuItems.Quit => "❌ Avslutt spillet",
            _ => item.ToString()
        };
    }

    private static string GenerateGameMenu(Menu item)
    {
        return item switch
        {
            Menu.Addition => "➕ Legg sammen tall (Addisjon)",
            Menu.Subtraction => "➖ Trekk fra tall (Subtraksjon)",
            Menu.Division => "Dele",
            Menu.Multiplication => "* Gange",
            _ => item.ToString()
        };
    }

}