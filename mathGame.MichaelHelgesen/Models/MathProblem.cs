using mathGame.MichaelHelgesen.Enums;

namespace mathGame.MichaelHelgesen.Models;

internal class MathProblem
{
    public int FirstNumber { get; }
    public int SecondNumber { get; }
    public string Operator { get; }
    public int CorrectAnswer { get; }

    public MathProblem(MenuItems gameType)
    {
        var random = Random.Shared;

        switch (gameType)
        {
            case MenuItems.Addition:
                FirstNumber = random.Next(1, 100);
                SecondNumber = random.Next(1, 100);
                Operator = "+";
                CorrectAnswer = FirstNumber + SecondNumber;
                break;
            case MenuItems.Subtraction:
                FirstNumber = random.Next(1, 100);
                SecondNumber = random.Next(1, 100);
                Operator = "-";
                CorrectAnswer = FirstNumber - SecondNumber;
                break;
            case MenuItems.Multiplication:
                FirstNumber = random.Next(1, 100);
                SecondNumber = random.Next(1, 100);
                Operator = "*";
                CorrectAnswer = FirstNumber * SecondNumber;
                break;
            case MenuItems.Division:
                FirstNumber = random.Next(1, 10);
                SecondNumber = random.Next(1, 10);
                FirstNumber *=  SecondNumber;
                Operator = "/";
                CorrectAnswer = FirstNumber / SecondNumber;
                break;
        }
    }
}