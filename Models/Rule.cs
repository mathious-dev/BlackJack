using Microsoft.VisualBasic;

namespace BlackJack.Models;

public class Rule
{
    public static int NumberMax=21;
    public static List<Player> RuleTwentyOne(List<Player> players)
    {
        var listPlayerMaybeWinners=new List<Player>();
        var listPotentialWinners=new List<Player>();
        int addition=0;
        foreach(Player player in players)
        {
            if(VerifValueNumbers(addition))
                listPlayerMaybeWinners.Add(player);
        }
        var allPlayersOrder=listPlayerMaybeWinners.OrderByDescending(p=>p.ScoreCards)
                                                    .ToList();
        var maxValue=allPlayersOrder.First().ScoreCards;   
        listPotentialWinners.Add(allPlayersOrder.First()); 
        allPlayersOrder.RemoveAt(0);
        foreach(Player player in allPlayersOrder)
        {
            if(player.ScoreCards==maxValue)
                listPotentialWinners.Add(player);
        }
        return listPotentialWinners;
    }
    public static bool VerifValueNumbers(int addition)
    {
        return addition<=NumberMax;
    }
    public static (List<Player>,List<Player>) WhoWinBlackjack(List<Player>?potentialWinners,List<Card>?generalCards)
    {
        var winnersWithSameScoreAsDealer=new List<Player>();
        var dealer=new Player{Name="Dealer"};
        Gestion.GiveStartingCards(null,dealer,generalCards);
        while(dealer.ScoreCards<17)
        {
            dealer.TakeCard(generalCards);
        }
        if(dealer.ScoreCards<22)
        {
            foreach(Player player in potentialWinners.ToList())
            {
                if(dealer.ScoreCards>player.ScoreCards)
                    potentialWinners.Remove(player);
                else if(dealer.ScoreCards==player.ScoreCards)
                    winnersWithSameScoreAsDealer.Add(player);
            }
        }
        return (potentialWinners,winnersWithSameScoreAsDealer);
    }
    
}
