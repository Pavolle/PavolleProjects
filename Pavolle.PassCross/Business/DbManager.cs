using Pavolle.Core.Utils;
using Pavolle.PassCross.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.PassCross.Business
{
    public class DbManager:Singleton<DbManager>
    {
        private DbManager()
        {

        }

        public void OyunBilgileriniKaydet(int puan, int cansayisi, ELevel currentLevel)
        {
            //oid 1 olan var mı? oyun tamamlandı mı?
        }
    }
}
