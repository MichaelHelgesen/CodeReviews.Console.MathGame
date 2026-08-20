namespace mathGame.MichaelHelgesen.Models;

internal class Archive
{
    public  List<Game.GameData> ArchivedGames = new();
    public void ArchiveGameRound(Game.GameData game)
    {
        ArchivedGames.Add(game);
    }
}