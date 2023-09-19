using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MobileCore.Common
{
    public class SizeManager:Singleton<SizeManager>
    {
        private SizeManager()
        {

        }
        double _carpan = 1;
        public void Initialize()
        {
            //Yükseklik ve genişlik al. Bunlardan hangisinin büyük olşduğunu çıkar. Bu değere göre ölçekle
        }

        public double GetRealSize(double size)
        {
            return _carpan * size;
        }
    }
}
