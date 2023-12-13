using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.StokDepo.DbModels.Entities
{
    [Persistent("sd_stock_transfers")]
    public class StockTransfer : BaseObject
    {
        public StockTransfer(Session session) : base(session)
        {
        }
    }
}
