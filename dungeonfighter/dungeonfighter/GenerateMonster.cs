using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonfighter
{
    class GenerateMonster
    {
        private int monsterlevel;
        private int hpofmonster;
        private string nameofmonster;
        private int[] attackofmonster = { 0, 0 };
        private int defenseofmonster;
        private int xpofmonster;
        

        public GenerateMonster(int level)
        {
            monsterlevel = level;
            assignmonsterStats();
        }

        public int MonsterHP
        {
            get
            {
                return hpofmonster;
            }

            set
            {
                hpofmonster = value;
            }
        }
        
        public string MonsterName
        {
            get
            {
                return nameofmonster;
            }



        }   
        
       public int[] MonsterAttack
        {
            get
            {
                return attackofmonster;
            }


        }

        public int MonsterDefense
        {
            get
            {
                return defenseofmonster;
            }
        }

        public int MonsterXP
        {
            get
            {
                return xpofmonster;
            }
        }

        private void assignmonsterStats()
        {
            switch (monsterlevel)
            {

                case 1:
                    this.MonsterHP = 20;
                    nameofmonster = makemonstername(1);
                    attackofmonster = setmonsterattack(1);
                    defenseofmonster = 1;
                    xpofmonster = 25;
                    break;
                case 2:
                    this.MonsterHP = 50;
                    nameofmonster = makemonstername(2);
                    attackofmonster = setmonsterattack(2);
                    defenseofmonster = 5;
                    xpofmonster = 75;
                    break;
                case 3:
                    this.MonsterHP = 100;
                    nameofmonster = makemonstername(3);
                    attackofmonster = setmonsterattack(3);
                    defenseofmonster = 10;
                    xpofmonster = 250;
                     break;
                default:
                    break;
            }

        }

        private int[] setmonsterattack(int floor)
        {
            int[] attack = { floor, floor * 2 };
            return attack;
        }

        private string makemonstername(int monsterlevel)
        {
            string[] easynames = { "Slime", "Skeleton", "Wolf", "Bandit", "Giant Rat", "Zombie", "Goblin" };
            string[] mednames = {"Dire Wolf", "Skeleton Warrior", "Bandit Captain", "Large Slime", "Orc", "Brown Bear" };
            string[] hardnames = { "Alpha Wolf", "Lich", "Giant Slime", "Bandit Leader", "Orc Warcheif", "Wyrm" };

            Random rand = new Random();

            switch (monsterlevel)
            {
                case 1:
                    return easynames[rand.Next(7)];
                case 2:
                    return mednames[rand.Next(6)];
                case 3:
                    return hardnames[rand.Next(6)];
                default:
                    break;
            }
            return "ERROR SHOULD RETURN A VALUE";
        }

    }

}
