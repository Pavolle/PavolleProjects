using DevExpress.Xpo;
using log4net;
using Pavolle.BES.DYS.Common.Enums;
using Pavolle.BES.DYS.DbModels.Entities;
using Pavolle.BES.DYS.ViewModels.Criteria;
using Pavolle.BES.DYS.ViewModels.Integration.Request;
using Pavolle.BES.DYS.ViewModels.Response;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
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

        public bool AddFolderIfNotCreate(Session session, string name, string basePath, EFolderType folderType, long? parentFolderOid, long organizationOid)
        {
            _log.Debug("Staring create " + name + " directory...");
            bool success = true;
            session.BeginTransaction();
            try
            {
                Folder? folder=null;
                if (parentFolderOid == null && folderType==EFolderType.RootFolder)
                {
                    folder = session.Query<Folder>().FirstOrDefault(t => t.Name == "root" && t.ParentFolderOid == null);
                }
                else
                {
                    folder = session.Query<Folder>().FirstOrDefault(t => t.ParentFolderOid == parentFolderOid && t.Name == name);
                }
                if (folder == null)
                {
                    folder = new Folder(session)
                    {
                        ParentFolderOid = parentFolderOid,
                        FullPath = basePath + "\\" + name,
                        FolderType = folderType,
                        Name = name,
                        OrganizationOid = organizationOid,
                    };
                    folder.Save();

                    string path = SettingServiceManager.Instance.GetSetting(ESettingType.DYSBaseFilePath) + "\\" + folder.FullPath;
                    if (Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                }
                session.CommitTransaction();
            }
            catch (Exception ex)
            {
                session.RollbackTransaction();
                success = false;

                _log.Debug("Started create " + name + " directory FAIL. Error Detail: " +ex);
            }
            _log.Debug("Started create " + name + " directory SUCCEDED");
            return success;
        }


        public ResponseBase Edit(long? oid, EditFolderRequest request)
        {
            throw new NotImplementedException();
        }

        public ResponseBase Add(AddFolderRequest request)
        {
            throw new NotImplementedException();
        }

        public FolderDetailResponse Detail(long? oid, BesRequestBase request)
        {
            throw new NotImplementedException();
        }

        public FolderListResponse List(ListFolderCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public LookupResponse Lookup(FolderLookupCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public ResponseBase Delete(long? oid, BesRequestBase request)
        {
            throw new NotImplementedException();
        }

        public ResponseBase Move(MoveFolderRequest request)
        {
            //TODO Transfer edilebilirliği kontrol edilecek.
            throw new NotImplementedException();
        }
    }
}
