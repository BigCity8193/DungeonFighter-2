using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonfighter
{
    class playerstats
    {
        private string nameofplayer;
        private int hpofplayer;
        private int[] attackofplayer = { 0, 0 };
        private int defenseofplayer;
        private int xpgained=0;
        private int levelofplayer = 1;
        private int nextlevelXP = 100;
        private int maxhpofplayer;
        private int numberofpotions;

        public playerstats(string inputname)
        {
            nameofplayer = inputname;
            assignplayerstats();
        }

        public int PlayerHP
        {
            get
            {
                return hpofplayer;
            }

            set
            {
                hpofplayer = value;
            }
        }

        public int PlayerMaxHP
        {
            get
            {
                return maxhpofplayer;
            }
            set
            {
                maxhpofplayer = value;
            }
        }

        public string PlayerName
        {
            get
            {
                return nameofplayer;
            }



        }

        public int[] PlayerAttack
        {
            get
            {
                return attackofplayer;
            }
            set
            {
                attackofplayer = value;
            }


        }

        public int PlayerDefense
        {
            get
            {
                return defenseofplayer;
            }
            set
            {
                defenseofplayer = value;
            }
        }

        public int PlayerTotalXP
        {
            get
            {
                return xpgained;
            }

            set
            {
                xpgained = value;
            }
        }

        public int PlayerLevel
        {
            get
            {
                return levelofplayer;
            }

            set
            {
                levelofplayer = value;
            }
        }

        public int XPtoLevelUP
        {
            get
            {
                return nextlevelXP;
            }

            set
            {
                nextlevelXP = value;
            }
        }

        public int PlayerPotions
        {
            get
            {
                return numberofpotions;
            }
            set
            {
                numberofpotions = value;
            }
        }

        private void assignplayerstats()
        {
            this.PlayerHP = 100;
            attackofplayer = setplayerattack(this.PlayerLevel);
            defenseofplayer = 1;
            maxhpofplayer = 100;
            numberofpotions = 1;

        }

        public int[] setplayerattack(int floor)
        {
            int[] attack = { floor, floor * 2 };
            return attack;
        }
    }
}
