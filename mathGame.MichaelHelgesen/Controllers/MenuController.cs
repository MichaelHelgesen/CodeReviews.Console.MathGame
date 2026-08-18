namespace mathGame.MichaelHelgesen.Controllers;
using mathGame.MichaelHelgesen.Enums;
using Spectre.Console;


//You need to create a game that consists of asking the player what's the result of a math question (i.e. 9 x 9 = ?), collecting the input and adding a point in case of a correct answer.
//A game needs to have at least 5 questions.
//The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.
//Users should be presented with a menu to choose an operation
//You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.
//You don't need to record results on a database. Once the program is closed the results will be deleted.


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
        var menuChoices = AnsiConsole.Prompt(
        new SelectionPrompt<MenuItems>()
            .Title("Choose [green]game type[/] would you like?")
            .AddChoices(Enum.GetValues<MenuItems>()));
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
                AnsiConsole.MarkupLine($"You selected: [yellow]{playerChoice}[/]");
                break;
            default:
                //AnsiConsole.MarkupLine($"Spill spill");
                GameController.StartGame();
                break;
        }
    }
}