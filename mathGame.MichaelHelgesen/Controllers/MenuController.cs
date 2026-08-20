namespace mathGame.MichaelHelgesen.Controllers;

using mathGame.MichaelHelgesen.Enums;
using Spectre.Console;

// DONE: Users should be presented with a menu to choose an operation
// DONE: A game needs to have at least 5 questions.
// DONE: The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.
// DONE: You need to create a game that consists of asking the player what's the result of a math question (i.e. 9 x 9 = ?), collecting the input and adding a point in case of a correct answer.
// DONE: You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.
// DONE: To follow the DRY Principle, try using just one method for all games. Additionally, double check your project and try to find opportunities to achieve the same functionality with less code, avoiding repetition when possible.


// TODO: Try to implement levels of difficulty.
// TODO: Add a timer to track how long the user takes to finish the game.
// TODO: Create a 'Random Game' option where the players will be presented with questions from random operations

internal class MenuController
{
    internal static void Run()
    {
        ShowWelcomeMessage();
        var playerChoice = PromptMenu();
        ExecutePlayerChoice(playerChoice);

    }

    private static void ShowWelcomeMessage()
    {
        AnsiConsole.MarkupLine("[bold blue]Welcome[/] to [green]the Math Game[/]!");
    }

    private static MenuItems PromptMenu()
    {
        var choices = Enum.GetValues<MenuItems>().ToList();
        if (GameController.archive.ArchivedGames.Count < 1)
            choices.Remove(MenuItems.Results);
        var menuChoices = AnsiConsole.Prompt(
        new SelectionPrompt<MenuItems>()
            .Title("Choose [green]game type[/] would you like?")
            .UseConverter(item => item switch
        {
            MenuItems.Addition => "➕ Legg sammen tall (Addisjon)",
            MenuItems.Subtraction => "➖ Trekk fra tall (Subtraksjon)",
            MenuItems.Division => "Dele",
            MenuItems.Multiplication => "* Gange",
            MenuItems.Results => "📊 Vis tidligere resultat og statistikk",
            MenuItems.Quit => "❌ Avslutt spillet",
            _ => item.ToString()
        })
            .AddChoices(choices));
        return menuChoices;
    }

    private static void ExecutePlayerChoice(MenuItems playerChoice)
    {
        switch (playerChoice)
        {
            case MenuItems.Quit:
                AnsiConsole.MarkupLine($"You selected: [yellow]{playerChoice}[/]");
                break;
            case MenuItems.Results:
                Console.Clear();
                AnsiConsole.MarkupLine($"You selected: [yellow]{playerChoice}[/]");
                GameController.archive.DisplayArchive();
                AnsiConsole.Prompt(
    new TextPrompt<string>($"[grey]Press [bold]Enter[/] to continue...[/]")
        .AllowEmpty()
);
                Run();
                break;
            default:
                //AnsiConsole.MarkupLine($"Spill spill");
                GameController.StartGame(playerChoice);
                break;
        }
    }
}