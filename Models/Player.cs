namespace BlackJack.Models;
public class Player
{
    public string Name{get;set;}
    public int Coin{get;set;}=1000;
    public int BetOfTheRound{get;set;}=0;
    public List<Card>ListCards{get;set;}=new List<Card>();
    public int ScoreCards{get;set;}=0;
    public bool StopTakingCards{get;set;}=false;
    //utiliser un événement pour modifier le deck général
    public void TakeCard(List<Card> generalCards)
    {   
        var newCard=generalCards.First();
        this.ListCards.Add(newCard);
        var cardValue=newCard.VerifValueCard();
        generalCards.RemoveAt(0);
        this.ScoreCards+=cardValue;
        if(!Rule.VerifValueNumbers(ScoreCards))
            Card.ReplaceAsCard(this.ListCards);
    }
    public void ShowPoints(int IsShowingWinners)
    {
        if(IsShowingWinners==1)
            Console.WriteLine($"Votre score est de : {this.ScoreCards}");
        else if(IsShowingWinners==2)
            Console.WriteLine($"{this.ScoreCards}");
        else
           Console.WriteLine($"Le score de {this.Name} est de : {this.ScoreCards}");
    }
    public void StopTakingCardsFunction()
    {
        this.StopTakingCards=true;
    }
    public void ResetInformation()
    {
         this.StopTakingCards=false;
         this.ScoreCards=0;
         this.BetOfTheRound=0;
    }
    public void CheckBet()
    {
        Console.WriteLine($"\nVous avez misé : {this.BetOfTheRound}");
    }
    public void CheckCard()
    {
        Console.WriteLine($"\nVos cartes sont :");
        foreach(Card card in this.ListCards)
        {
            Console.WriteLine($"\n{(FaceCard)card.Number} de {card.Type}");
        }
    }
    public static void ShowWinnersOrWinnersWithSameScore(List<Player>potentialWinners,List<Player>winnersWithSameScore)
    {
        if(potentialWinners.Any())
        {
            if(potentialWinners.Count()==1)
                Console.WriteLine("\nLe seul gagnant de jeton est : ");
            else
                Console.WriteLine("\nLes gagnants de jeton sont : ");
            foreach(Player player in potentialWinners)
            {
                Console.WriteLine($"\n{player.Name} avec ");
                player.ShowPoints(2);
                player.GiveWinnerCoinsAndReturnCoins(true);
            }
        }
        if(winnersWithSameScore.Any())
        {
            if(winnersWithSameScore.Count()==1)
                Console.WriteLine("\nLe seul gagnant égalité avec le croupier est : ");
            else
                Console.WriteLine("\nLes gagnants égalité avec le croupier sont : ");
            foreach(Player player in winnersWithSameScore)
            {
                Console.WriteLine($"\n{player.Name} avec ");
                player.ShowPoints(2);
                player.GiveWinnerCoinsAndReturnCoins(false);
            }
        }
    }
    public void GiveWinnerCoinsAndReturnCoins(bool winner)
    {
        if(winner)
        {
            if(this.ListCards.Count()==2&&this.ScoreCards==21)
                this.Coin+=(int)(this.BetOfTheRound*2.5);
            else
                this.Coin+=this.BetOfTheRound*2;
        }
        else
            this.Coin+=this.BetOfTheRound;
    }
}
