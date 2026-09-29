namespace BlackJack.Models;

public class GameEngine
{
    int numberMax=Rule.NumberMax;
    public void Round(List<Player> players,List<Card>generalCards)
    {
        var winnersSameScore=new List<Player>();
        var potentialWinners=new List<Player>();

        foreach(Player player in players)
        {
            player.CheckCard();
            if(player is Bot bot)
            {
                bot.BotAction(bot.ListCards,numberMax,generalCards);
            }
            else
            {
                Console.Write("\n Que voulez-vous faire?");
                UserChoice(player,generalCards);
            }
        }
        potentialWinners=players.Where(p=>p.ScoreCards<22).ToList();
        (potentialWinners,winnersSameScore)=Rule.WhoWinBlackjack(potentialWinners,generalCards);
        Player.ShowWinnersOrWinnersWithSameScore(potentialWinners,winnersSameScore);
        
    }
    public void UserChoice(Player humanPlayer,List<Card>generalCards)
    {
        int choice=0;
        string[] tab={"Prendre une carte","Suivre","Consulter vos informations"};
        while(choice!=2&&Rule.VerifValueNumbers(humanPlayer.ScoreCards))
        {
            int i=1;
            foreach(string sentence in tab)
            {
                Console.WriteLine($"\n{i}.{sentence}");
                i++;
            }
            choice=Gestion.IntEnter();
            switch(choice)
            {
                case 1:humanPlayer.TakeCard(generalCards);break;
                case 2:humanPlayer.StopTakingCardsFunction();break;
                case 3:humanPlayer.CheckBet();humanPlayer.CheckCard();break;
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
