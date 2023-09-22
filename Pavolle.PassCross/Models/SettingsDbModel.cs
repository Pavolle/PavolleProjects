using Pavolle.MobileCore.Models;
using Pavolle.Core.Enums;
using Pavolle.PassCross.Common.Enums;

namespace Pavolle.PassCross.Models
{
    public class SettingsDbModel :BaseDbObject
    {
        public string Username { get; set; }
        public long? CountryOid { get; set; }
        public ELanguage Language { get; set; }
        public long TotalScore { get; set; }
        public EGameLevel CurrentLevel { get; set; }
    }
}
