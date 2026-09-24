namespace BlackJack;

using BlackJack.Models;
public class Gestion
{
    List<Bot> bots=new List<Bot>();
    Player player = new Player();
    public Gestion()
    {
        Menu();
    }
    public void Menu()
    {
        int choice=1;
        
        while(choice!=3)
        {
            int i=1;
            string[] options={"Jouer","Tester","Quitter"};
            foreach(string option in options)
            {
                Console.WriteLine($"{i}.{option}");
                i++;
            }
            choice=IntEnter();
            switch(choice)
            {
                case 1: StartGame();break;
                case 2: Test();break;
                case 3: Console.WriteLine("Fin du jeu");break;
            }
        }
    }
    public void StartGame()
    {
        var allPlayers=new List<Player>();
        var newPlayer=new Player();
        string name="";
        while(string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("\nQuelle est votre nom? ");
            name=Console.ReadLine();
        }
        newPlayer.Name=name;
        player=newPlayer;
        var gameEngine=new GameEngine();
        gameEngine.Init(bots);
        allPlayers.Add(player);
        allPlayers.AddRange(bots);
        Game(allPlayers,player,gameEngine);
        bots.Clear();
    }
    public void Game(List<Player> allPlayers,Player humanPlayer,GameEngine gameEngine)
    {
        int countRound=1;
        while(allPlayers.Contains(humanPlayer))
        {
            Console.ForegroundColor=ConsoleColor.DarkBlue;    
            Console.WriteLine($"\n|||||||||||||||||||||||||||||||||||||||||||\nRound : {countRound}");
            Console.ResetColor();
            gameEngine.Round(allPlayers);
            countRound++;
            foreach(Player p in allPlayers)
            {
                p.BetOfTheRound=0;
            }
        }
        if(!allPlayers.Contains(player))
        {
            Console.ForegroundColor=ConsoleColor.Red;
            Console.WriteLine("Game Over. Vous avez perdu");
            Console.ResetColor();
        }
    }
    public void Test()
    {
        
    }
    public static int IntEnter()
    {
        int intChoice;
        string choice=Console.ReadLine();
        int.TryParse(choice,out intChoice);
        return intChoice;
        
    }
}
