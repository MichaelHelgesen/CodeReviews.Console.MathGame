// Hva betyr static og ikke static igjen?
public class Game
{
    public int GameNumber { get; set; }
    public int GameScore { get; set; }
    public string GameType { get; set; }
    public string PlayerName { get; set;}
    public List<MathQuestion> Questions { get; set; } = new List<MathQuestion>();

}