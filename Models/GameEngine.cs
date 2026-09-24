namespace BlackJack.Models;

public class GameEngine
{
    int numberMax=Rule.NumberMax;
    public void WhoWin()
    {

    }
    public void Round(List<Player> players,List<Card>generalCards)
    {
        foreach(Player player in players)
        {

            if(player is Bot bot)
            {
                bot.BotAction(bot.ListCards,numberMax,generalCards);
            }
            else
            {
                
            }
        }
    }
    public void Init(List<Bot> bots)
    {
        Random randomLevel = new Random();
        Bot bot1 = new Bot(randomLevel.Next(1, 4))
        { Name = "bot1", };
        Bot bot2 = new Bot(randomLevel.Next(1, 4))
        { Name = "bot2", };
        Bot bot3 = new Bot(randomLevel.Next(1, 4))
        { Name = "bot3", };
        bots.Add(bot1);
        bots.Add(bot2);
        bots.Add(bot3);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nCommencement de la partie.");
        foreach (Bot bot in bots)
        {
            Console.WriteLine($"\nLe bot {bot.Name} a rejoint la partie");
        }
        Console.ResetColor();
    }
    public (Card,Card) GiveCardsStart(List<Card> listCards)
    {
        var FirstCard=listCards[0];
        listCards.RemoveAt(0);
        var SecondCard=listCards[0];
        listCards.RemoveAt(0);
        return (FirstCard,SecondCard);
    }
}
