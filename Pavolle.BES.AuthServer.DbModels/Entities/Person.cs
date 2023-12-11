using DevExpress.Xpo;
using Pavolle.BES.AuthServer.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.DbModels.Entities
{
    [Persistent("as_people")]
    public class Person : BaseObject
    {
        public Person(Session session) : base(session)
        {
        }

        [Persistent("name")]
        [Size(255)]
        public string Name { get; set; }

        [Persistent("surname")]
        [Size(255)]
        public string Surname { get; set; }

        [Persistent("gender_type")]
        public EGenderType? GenderType { get; set; }

        [Persistent("base64_image_file_path")]
        public string Base64ImageFilePath { get; set; }
    }
}
