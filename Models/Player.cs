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
        var cardValue=Card.VerifValueCard(newCard);
        generalCards.RemoveAt(0);
        this.ScoreCards+=cardValue;
        if(!Rule.VerifValueNumbers(ScoreCards))
            Card.ReplaceAsCard(this.ListCards);
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
}
