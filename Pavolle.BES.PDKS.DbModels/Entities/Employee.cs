using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.PDKS.DbModels.Entities
{
    public class Employee : BaseObject
    {
        public Employee(Session session) : base(session)
        {
        }

        [Persistent("person_oid")]
        public long PersoneOid { get; set; }

        [Persistent("identification_number")]
        public string IdentificationNumber { get; set; }

        [Persistent("identification_file_oid")]
        public long IdentificationFileOid {  get; set; } //dys den sorgulanabilecek

        [Persistent("passport_number")]
        public string PassportNumber { get; set; }

        [Persistent("passport_file_oid")]
        public long? PassportFileOid { get; set; } //dys den sorgulanabilecek
    }
}
