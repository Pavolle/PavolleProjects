using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.MailServer.Business.Manager
{
    public class MailServerHelperManager : Singleton<MailServerHelperManager>
    {
        private MailServerHelperManager() { }

        internal string GetMailToString(List<string> mailList)
        {
            var result = "";
            if (mailList.Count == 0)
            {
                result = "agha.alizade@pavolle.com";
            }
            else if (mailList.Count == 1)
            {
                result = mailList.FirstOrDefault();
            }
            else
            {
                for (int i = 0; i < mailList.Count; i++)
                {
                    if (i == mailList.Count - 1)
                    {
                        result += mailList[i];
                    }
                    else
                    {
                        result += mailList[i]+";";
                    }
                }
            }
            return result;
        }

        internal string GetMailInfoString(List<string> mailList)
        {
            var result = "";
            if (mailList.Count == 0)
            {
                return result;
            }
            else if (mailList.Count == 1)
            {
                result = mailList.FirstOrDefault();
            }
            else
            {
                for (int i = 0; i < mailList.Count; i++)
                {
                    if (i == mailList.Count - 1)
                    {
                        result += mailList[i];
                    }
                    else
                    {
                        result += mailList[i] + ";";
                    }
                }
            }
            return result;
        }
    }
}
