using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonfighter
{
    class weapon : item
    {
        public override string name
        {
            get

            {
                return weaponName;
            }
            set
            {
                weaponName = value;
            }
        }
        public override string type
        {
            get
            {
                return weaponType;
            }

            set
            {
                weaponType = value;
            }
                
        }

        public override bool isUnique
        {
            get
            {
                return weaponUnique;
            }

            set
            {
                weaponUnique = value;
            }
        }

        public override int quantity
        {
            get
            {
                return weaponQty;
            }

            set
            {
                weaponQty = value;
            }
        }

        public bool isEquipped
        {
            get
            {
                return weaponEquipped;
            }
            set
            {
                weaponEquipped = value;
            }
        }

        public int[] attackPower
        {
            get
            {
                return weaponAttackPower;
            }

            set
            {
                weaponAttackPower = value;
            } 
               
         } 

        private string weaponName;
        private string weaponType;
        private bool weaponUnique;
        private int weaponQty;
        private bool weaponEquipped;
        private int[] weaponAttackPower = { 0, 0 };
    }
}
