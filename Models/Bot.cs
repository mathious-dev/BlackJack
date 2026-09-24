using BlackJack.Models;

namespace BlackJack.Models;

public class Bot : Player
{
    private int _level;
    public int Level
    {
        get{return _level;}
        set
        {
            if(value>0&&value<4)
                _level=value;
            else
                throw new ArgumentOutOfRangeException("Le niveau du bot doit être entre 1 et 3 compris");
        }
    }
    public Bot(int level)
    {
        this.Level=level;
    }
    public void BotAction(List<Card> cards,int numberMax,List<Card> generalCards)
    {
        switch(this.Level)
        {
            case 1:BotLevelEasy(cards,numberMax);break;
            case 2:BotLevelMiddle(cards,numberMax);break;
            case 3:BotLevelHard(cards,numberMax);break;
        }
    }
    public void BotLevelEasy(List<Card> cards,int numberMax)
    {
        switch(this.ScoreCards)
        {
            case <18: TakeCard();break;
        }
    }
    public void BotLevelMiddle(List<Card> cards,int numberMax)
    {
        
    }
    public void BotLevelHard(List<Card> cards,int numberMax)
    {
        
    }
}
