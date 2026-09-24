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
    public void BotAction()
    {
        
    }
}
