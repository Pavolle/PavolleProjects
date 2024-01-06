using Pavolle.BES.TranslateServer.ViewModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.ViewModels.Model
{
    public class DistrictCacheModel
    {
        public DateTime? DeletedTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public long Oid { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public TranslateDataCacheModel? NameTranslateModel { get; set; }
        public long CityOid { get; set; }
    }
}
