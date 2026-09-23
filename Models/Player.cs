namespace BlackJack.Models;
public class Player
{
    public string Name{get;set;}
    public int Coin{get;set;}=1000;
    public int BetOfTheRound{get;set;}=0;
    public List<Card>ListCards{get;set;}=new List<Card>();
    public int ScoreCards{get;set;}=0;
    public void TakeCard(Card generalCard)
    {
        this.ListCards.Add(generalCard);
        var cardValue=Card.VerifValueCard(generalCard);
        this.ScoreCards+=cardValue;
        if(!Rule.VerifValueNumbers(ScoreCards))
            Card.ReplaceAsCard(this.ListCards);
    }
}
