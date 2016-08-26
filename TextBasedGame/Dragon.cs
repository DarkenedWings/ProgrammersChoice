using System;


namespace TextBasedGame
{
    class Dragon
    {
        Random RNG = new Random();

        int hp;
        int crit;
        int bite;
        int claws;
        int fire;
        int tail;
        bool isAlive;

        public Dragon()
        {
            hp = RNG.Next(300, 500);
            bite = RNG.Next(20, 50);
            claws = RNG.Next(30, 40);
            fire = RNG.Next(40, 50);
            tail = RNG.Next(20, 30);
            crit = RNG.Next(1, 5);
            isAlive = true;
        }

        public int GetHp()
        {
            return hp;
        }

        public int GetCrit()
        {
            return crit;
        }

        public int GetBite()
        {
            return bite;
        }

        public int GetClaws()
        {
            return claws;
        }

        public int GetFire()
        {
            return fire;
        }

        public int GetTail()
        {
            return tail;
        }
    }
}
