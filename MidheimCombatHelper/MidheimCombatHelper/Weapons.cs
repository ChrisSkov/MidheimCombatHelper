using System;
using System.Collections.Generic;
using System.Text;

namespace MidheimCombatHelper
{
    class Weapons
    {
        int energiCost;
        int tempoCost;
    

        public Weapons(int energiCost, int tempoCost)
        {
            this.energiCost = energiCost;
            this.tempoCost = tempoCost;
        }

        public int GetEnergiCost()
        {
            return energiCost;
        }
        public int GetTempoCost()
        {
            return tempoCost;
        }

        public void SetEnergiCost(int e)
        {
            energiCost = e;
        }
        public void SetTempoCost(int t)
        {
            tempoCost = t;
        }
  
    }
}
