using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonfighter
{
    class armor : item
    {
        public override string name
        {
            get
            {
                return armorName;
            }

            set
            {
                armorName = value;
            }
        }

        public override string type
        {
            get
            {
                return armorType;
            }

            set
            {
                armorType = value;
            }
        }
        public override bool isUnique
        {
            get
            {
                return armorUnique;
            }

            set
            {
                armorUnique = value;
            }

        }



        public override int quantity
        {

            get
            {
                return armorQty;
            }

            set
            {
                armorQty = value;
            }

        }

        private bool armorUnique;
        private int armorQty;
        private string armorName;
        private string armorType;
        private int armorDefense;


    }
}

