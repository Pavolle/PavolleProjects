using Pavolle.BES.TranslateServer.ViewModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.ViewModels.Model
{
    public class CountryCacheModel
    {
        public long Oid { get; set; }
        public TranslateDataCacheModel NameTranslateModel { get; set; }
        public string IsoCode2 { get; set; }
        public string IsoCode3 { get; set; }
        public string PhoneCode { get; set; }
        public string Base64Flag { get; set; }
        public string FlagPath { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? DeletedTime { get; set; }
        public DateTime? LastUpdateTime { get; set; }
    }
}
