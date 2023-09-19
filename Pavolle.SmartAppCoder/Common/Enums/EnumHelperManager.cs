using Pavolle.SmartAppCoder.Common.Utils;
using Pavolle.SmartAppCoder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Common.Enums
{
    public class EnumHelperManager : Singleton<EnumHelperManager>
    {
        private EnumHelperManager() { }

        public List<LookupViewData> GetWebAppTechnologyList()
        {
            return new List<LookupViewData>
            {
                new LookupViewData
                {
                    Key=(int)EWebAppTecnology.Angular,
                    Value="Angular"
                }
            };
        }

        public List<LookupViewData> GetSecurityLevel()
        {
            return new List<LookupViewData>
            {
                new LookupViewData
                {
                    Key=(int)ESecurityLevel.Low,
                    Value="Low"
                },
                new LookupViewData
                {
                    Key=(int)ESecurityLevel.Strong,
                    Value="Strong"
                },
                new LookupViewData
                {
                    Key=(int)ESecurityLevel.Master,
                    Value="Master"
                }
            };
        }

        public List<LookupViewData> GetMobileTechnologyList()
        {
            return new List<LookupViewData>
            {
                new LookupViewData
                {
                    Key=(int)EMobileTechnology.MAUI,
                    Value="MAUI"
                }
            };
        }

        public List<LookupViewData> GetDbTechnologyList()
        {
            return new List<LookupViewData>
            {
                new LookupViewData
                {
                    Key=(int)EDbTechnology.Sqlite,
                    Value="Sqlite"
                },
                new LookupViewData
                {
                    Key=(int)EDbTechnology.PostgreSQL,
                    Value="PostgreSQL"
                },
                new LookupViewData
                {
                    Key=(int)EDbTechnology.SQLServer,
                    Value="SQLServer"
                },
                new LookupViewData
                {
                    Key=(int)EDbTechnology.Oracle,
                    Value="Oracle"
                },
                new LookupViewData
                {
                    Key=(int)EDbTechnology.MySql,
                    Value="MySql"
                },
            };
        }
    }
}
