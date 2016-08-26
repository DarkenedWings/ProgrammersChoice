using System;
using FSPG;

namespace TextBasedGame
{
    class Skeleton
    {

        int hp;
        int att;
        int crit;
        int gold;
        bool alive;

        Random RNG = new Random();

        public Skeleton()
        {
            hp = RNG.Next(20, 35);
            att = RNG.Next(5, 20);
            crit = RNG.Next(1, 5);
            gold = RNG.Next(20);
            alive = true;
        }

        public int GetHp()
        {
            return hp;
        }

        public int GetAtt()
        {
            return att;
        }

        public int GetCrit()
        {
            return crit;
        }

        public int GetGold()
        {
            return gold;
        }

        public void Kill()
        {
            alive = false;
        }
    }
}