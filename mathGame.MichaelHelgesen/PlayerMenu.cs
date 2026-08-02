
public static class PlayerMenu
{
    public static int GeneratePlayerMenu(int gameNumber, string playerName)
    {
        ConsoleKeyInfo tastInput;
        int selectedGame;
        bool validPlayerChoise = false;

        List<string> allMenuChoices = new List<string> {
            "Press 1 for addition (+)",
            "Press 2 for multiplication (*)",
            "Press 3 for division (/)",
            "Press 4 for subtraction (-)",
            "Press 5 for game results",
            "Press Esc to quit"
        };

        List<string> activeMenuChoices = new List<string>();

        for (int i = 0; i < 4; i++)
        {
            activeMenuChoices.Add(allMenuChoices[i]);
        }

        if (gameNumber > 1)
            activeMenuChoices.Add(allMenuChoices[4]);

        activeMenuChoices.Add(allMenuChoices[5]);

        Console.Clear();
        Console.WriteLine($"Choose your prefered game, {playerName}:\n");

        foreach (string menuElement in activeMenuChoices)
        {
            Console.WriteLine(menuElement);
        }

        do
        {
            tastInput = Console.ReadKey(intercept: true);
            if (((int)char.GetNumericValue(tastInput.KeyChar) > 0 && (int)char.GetNumericValue(tastInput.KeyChar) < activeMenuChoices.Count) || tastInput.Key == ConsoleKey.Escape)
            {
                validPlayerChoise = true;
            }
        } while (!validPlayerChoise);

        if (tastInput.Key == ConsoleKey.Escape) {
                selectedGame = -1;
        } else
        {
            selectedGame = (int)char.GetNumericValue(tastInput.KeyChar);
        }

        return selectedGame;
    }
}