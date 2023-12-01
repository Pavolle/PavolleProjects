using log4net;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.JobServer.Business
{
    public class JobServerSettingsManager :Singleton<JobServerSettingsManager>
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(JobServerManager));
        string _prodCrlUrl;
        string _testCrlUrl;
        string _prodCrlPath;
        string _testCrlPath;
        private JobServerSettingsManager() { }

        public void SetProdCrlUrl(string prodCrlUrl)
        {
            _log.Info("ProdCrlUrl is " + prodCrlUrl);
            _prodCrlUrl = prodCrlUrl;
        }

        public void SetTestCrlUrl(string testCrlUrl)
        {
            _log.Info("TestCrlUrl is " + testCrlUrl);
            _testCrlUrl = testCrlUrl;
        }

        public void SetProdCrlPath(string prodCrlPath)
        {
            _log.Info("ProdCrlPath is " + prodCrlPath);
            _prodCrlPath = prodCrlPath;
        }

        public void SetTestCrlPath(string testCrlPath)
        {
            _log.Info("TestCrlPath is " + testCrlPath);
            _testCrlPath = testCrlPath;
        }

        public string GetProdCrlUrl()
        {
            return _prodCrlUrl;
        }

        public string GetTestCrlUrl()
        {
            return _testCrlUrl;
        }

        public string GetProdCrlPath()
        {
            return _prodCrlPath;
        }

        public string GetTestCrlPath()
        {
            return _testCrlPath;
        }
    }
}
