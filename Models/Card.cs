namespace BlackJack.Models;

public enum TypeCard
{
    Carreau = 1,
    Pique,
    Coeur,
    Trefle
}
public enum FaceCard
{
    Valet = 11,
    Dame = 12,
    Roi = 13,
    As = 14
}
public class Card
{

    public TypeCard Type { get; set; }
    private int _number;
    public int Number
    {
        get { return _number; }
        set
        {
            if (value < 15 && value > 1)
                _number = value;
            else
                throw new ArgumentOutOfRangeException("Le nombre doit être entre 2 et 14 compris");
        }
    }
    public Card(int number)
    {
        this.Number = number;
    }
    public static List<Card> GeneralDeckCard()
    {
        var listCards = new List<Card>();
        for (int i = 2; i <= 14; i++)//car l'As va valoir à la fois 1 et 14
        {
            for (int j = 1; j < 5; j++)
            {
                listCards.Add(new Card(i) { Type = (TypeCard)j });
            }
        }
        return listCards;
    }
    public static int VerifValueCard(Card card)
    {
        if(card.Number>10&&card.Number<14)
            return 10;
        else if(card.Number==14)
            return 11;
        else
            return card.Number;
    }
    public static void ReplaceAsCard(List<Card> cards)
    {
        foreach(Card card in cards)
        {
            if(card.Number==11)
                card.Number=1;
        }
    }
}