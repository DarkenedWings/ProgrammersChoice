using System;


namespace TextBasedGame
{
    class Tank
    {
        int hp;
        int mp;
        int att;
        int wiz;
        int crit;
        int luck;

        Random RNG = new Random();
        Items weap = new Items();

        public Tank ()
        {
            hp = RNG.Next(1000, 2500);
            mp = RNG.Next(0, 10);
            att = RNG.Next(10, 25);
            wiz = RNG.Next(5, 15);
            crit = RNG.Next(10);
            luck = RNG.Next(-10, 10);
        }

        public void show()
        {
            Console.WriteLine("hp: " + hp);
            Console.WriteLine("mp: " + mp);
            Console.WriteLine("att: " + (att + weap.GetTank()));
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
