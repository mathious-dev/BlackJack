namespace BlackJack.Models;

public class GameEngine
{
    public void WhoWin()
    {

    }
    public void Round(List<Player> players)
    {
        foreach(Player player in players)
        {
            if(player is Bot)
            {
                
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
}
