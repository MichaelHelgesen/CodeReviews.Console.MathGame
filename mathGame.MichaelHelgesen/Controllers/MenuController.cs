namespace mathGame.MichaelHelgesen.Controllers;
using mathGame.MichaelHelgesen.Enums;
using Spectre.Console;

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
            case MenuItems.Addition:
                AnsiConsole.MarkupLine($"You selected: [yellow]{playerChoice}[/]");
                break;
            case MenuItems.Multiplication:
                AnsiConsole.MarkupLine($"You selected: [yellow]{playerChoice}[/]");
                break;
            case MenuItems.Division:
                AnsiConsole.MarkupLine($"You selected: [yellow]{playerChoice}[/]");
                break;
            case MenuItems.Subtraction:
                AnsiConsole.MarkupLine($"You selected: [yellow]{playerChoice}[/]");
                break;
            case MenuItems.Results:
                AnsiConsole.MarkupLine($"You selected: [yellow]{playerChoice}[/]");
                break;
            default:
                AnsiConsole.MarkupLine($"By bye");
                break;
        }
    }

}