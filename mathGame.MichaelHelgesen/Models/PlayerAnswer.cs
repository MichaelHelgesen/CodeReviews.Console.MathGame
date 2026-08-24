namespace mathGame.MichaelHelgesen.Models;

class PlayerAnswer(int correctMathAnswer, int playerAnswer)
{
    internal int Answer { get; } = playerAnswer;
    internal int MathAnswer { get; } = correctMathAnswer;
    internal bool IsCorrect => Answer == MathAnswer;
}