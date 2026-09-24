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
        int chanceToTakeCardInt=0;
        Random chanceToTakeCard=new Random();
        switch(this.Level)
        {
            case 1:this.BotLevelEasy(cards,numberMax,generalCards,ref chanceToTakeCardInt,chanceToTakeCard);break;
            case 2:this.BotLevelMiddle(cards,numberMax,generalCards,ref chanceToTakeCardInt,chanceToTakeCard);break;
            case 3:this.BotLevelHard(cards,numberMax,generalCards,ref chanceToTakeCardInt,chanceToTakeCard);break;
        }
        if(chanceToTakeCardInt==1)
            this.TakeCard(generalCards);
        else
            this.StopTakingCards=true;
    }
    public void BotLevelEasy(List<Card> cards,int numberMax,List<Card> generalCards,ref int chance,Random chanceToTakeCard)
    {
        switch(this.ScoreCards)
        {
            case <12:chance=chanceToTakeCard.Next(1,2);break;
            case <17:chance=chanceToTakeCard.Next(1,3);break;
            case 20:chance=chanceToTakeCard.Next(1,7);break;
            case >17:chance=chanceToTakeCard.Next(1,4);break;
        }
    }
    public void BotLevelMiddle(List<Card> cards,int numberMax,List<Card> generalCards,ref int chance,Random chanceToTakeCard)
    {
        switch(this.ScoreCards)
        {
            case <12:chance=1;break;
            case <17:chance=chanceToTakeCard.Next(1,3);break;
            case 20:chance=chanceToTakeCard.Next(1,14);break;
            case >17:chance=chanceToTakeCard.Next(1,8);break;
        }
    }
    public void BotLevelHard(List<Card> cards,int numberMax,List<Card> generalCards,ref int chance,Random chanceToTakeCard)
    {
        switch(this.ScoreCards)
        {
            case <12:chance=1;break;
            case <17:chance=chanceToTakeCard.Next(1,5);break;
            case 20:chance=chanceToTakeCard.Next(1,50);break;
            case >17:chance=chanceToTakeCard.Next(1,10);break;
        }
    }
}
