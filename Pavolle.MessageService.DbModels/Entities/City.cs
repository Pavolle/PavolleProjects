using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.DbModels.Entities
{
    public class City : BaseObject
    {
        public City(Session session) : base(session)
        {
        }

        public string Code { get; set; }
        public Country Country { get; set; }
    }
}
