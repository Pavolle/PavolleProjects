using DevExpress.Xpo;
using log4net;
using Pavolle.BES.DYS.Common.Enums;
using Pavolle.BES.DYS.DbModels.Entities;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.Business.Manager
{
    public class FolderManager : Singleton<FolderManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(FolderManager));
        private FolderManager() { }

        public bool AddFolderIfNotCreate(Session session, string name, string basePath, EFolderType folderType, long parentFolderOid)
        {
            bool success = true;
            try
            {
                var folder = session.Query<Folder>().FirstOrDefault(t => t.ParentFolderOid == parentFolderOid && t.Name == name);
                if (folder == null)
                {

                }
            }
            catch (Exception ex)
            {
                success = false;
            }
            return success;
        }
    }
}
