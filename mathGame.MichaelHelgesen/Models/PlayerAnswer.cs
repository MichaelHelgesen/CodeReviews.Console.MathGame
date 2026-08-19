namespace mathGame.MichaelHelgesen.Models;

internal class PlayerAnswer
{
    public int Answer { get; }
    public int MathAnswer { get; }
    public PlayerAnswer(int correctMathAnswer, int playerAnswer)
    {
        Answer = playerAnswer;
        MathAnswer = correctMathAnswer;
    }
    public bool IsCorrect => Answer == MathAnswer;
}