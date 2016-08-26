using System;


namespace TextBasedGame
{
    class Warrior
    {
        int hp;
        int mp;
        int att;
        int wiz;
        int crit;
        int luck;
        
        int mCost;

        Random RNG = new Random();
        Items weap = new Items();

        public Warrior ()
        {
            hp = RNG.Next(250, 1000);
            mp = RNG.Next(10, 100);
            att = RNG.Next(25, 75);
            wiz = RNG.Next(1, 10);
            crit = RNG.Next(6);
            luck = RNG.Next(-5, 5);
        }

        public void show()
        {
            Console.WriteLine("hp: " + hp);
            Console.WriteLine("mp: " + mp);
            Console.WriteLine("att: " + (att + weap.GetWar()));
            Console.WriteLine("wiz: " + wiz);
            Console.WriteLine("crit: " + crit);
            Console.WriteLine("luck: " + luck);
        }
        public int GetHp()
        {
            return hp;
        }
        public int GetMp()
        {
            return mp;
        }
        public int GetAtt()
        {
            return att;
        }
        public int GetWiz()
        {
            return wiz;
        }
        public int GetCrit()
        {
            return crit;
        }
        public int GetLuck()
        {
            return luck;
        }

        public void SetHp(int x)
        {
            hp += x;
        }
        public void SetMp(int x)
        {
            mp += x;
        }
    }
}
