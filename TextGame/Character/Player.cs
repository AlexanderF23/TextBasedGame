using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Character;

public class Player
{
    public static Random Rand = new Random();
    public int mods { get; set; } = 0;
    public int playerHealth { get; set; } = 20;
    public int playerAttac { get; set; } = 5;
    
    public int level { get; set; } = 1;
    public int xp { get; set; } = 0;
    
    public int GetExp()
    {
        int upper =(20 * mods + 50);
        int lower = (15 * mods + 10);
        return Rand.Next(lower, upper);
    }

    public int GetLevelUpValue()
    {
        return 10 * level;
    }
    
    public bool CanLevelUp()
    {
        if (xp >= GetLevelUpValue())
            return true;
        else
            return false;
    }
    
    public void LevelUp()
    {
        while (CanLevelUp())
        {
            xp -= GetLevelUpValue();
            level++;
        }
        Console.WriteLine("WOW du er nu i level " + level + "!");
    }
}