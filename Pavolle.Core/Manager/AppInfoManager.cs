using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Core.Manager
{
    public class AppInfoManager : Singleton<AppInfoManager>
    {
        private AppInfoManager() { }

        private string _name = "";
        private string _version = "";
        public string _id { get; set; }
        DateTime _versionReleaseDate;

        public void Initialize(string name, string version, string id, DateTime versionRealeseDate)
        {
            _name = name;
            _version = version;
            _id = id;
            _versionReleaseDate = versionRealeseDate;
        }

        public string GetAppCode()
        {
            return _name + " - v" + _version;
        }

        public string GetId()
        {
            return _id;
        }

        public string GetReleaseDate()
        {
            return _versionReleaseDate.ToShortDateString();
        }

    }
}
