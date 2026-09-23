namespace BlackJack.Models;

public class Rule
{
    public static int NumberMax=21;
    public static void RuleTwentyOne(List<Player> players)
    {
        var listePlayerMaybeWinners=new List<Player>();;
        int addition=0;
        foreach(Player player in players)
        {
            if(VerifValueNumbers(addition))
                listePlayerMaybeWinners.Add(player);
        }
        var allPlayersOrder=listePlayerMaybeWinners.OrderByDescending(p=>p.ScoreCards)
                                                    .ToList();
        var maxValue=allPlayersOrder.First()                                 
        foreach(Player player in allPlayersOrder)
        {
            
        }
    }
    public static bool VerifValueNumbers(int addition)
    {
        return addition<=NumberMax;
    }
}
