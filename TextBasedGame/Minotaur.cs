using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedGame
{
    class Minotaur
    {
        int hp;
        int att;
        int crit;
        int gold;
        bool alive;

        Random RNG = new Random();

        public Minotaur()
        {
            hp = RNG.Next(100, 200);
            att = RNG.Next(10, 35);
            crit = RNG.Next(0, 2);
            gold = RNG.Next(30, 50);
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
