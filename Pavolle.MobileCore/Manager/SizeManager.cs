using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MobileCore.Manager
{
    public class SizeManager : Singleton<SizeManager>
    {
        double _sizeEffectValue  = 1;
        private SizeManager() { }

        public void Initialize(int heigth, int weight)
        {

        }

        public double GetRealSize(int size)
        {
            return size*_sizeEffectValue;
        }

    }
}
