using DevExpress.Xpo;
using Pavolle.BES.DYS.Common.Enums;
using Pavolle.BES.DYS.DbModels;
using Pavolle.BES.DYS.DbModels.Entities;
using Pavolle.BES.DYS.ViewModels.Integration.Request;
using Pavolle.BES.DYS.ViewModels.Response;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.Business.Integration
{
    public class SuppleraIntegrationManager : Singleton<SuppleraIntegrationManager>
    {
        private SuppleraIntegrationManager() { }

        public DYSIntegrationResponseBase SaveBomFile(SuppleraIntegrationBomFileRequest request)
        {
            bool success = false;
            try
            {

                string baseRoute = SettingServiceManager.Instance.GetSetting(ESettingType.DYSBaseFilePath);

                using (Session session = DYSXpoManager.Instance.GetNewSession())
                {
                    //root
                    //organization
                    //supplera
                    //product
                    //version
                    var rootFolder = session.Query<Folder>().FirstOrDefault(t => t.Name == "root");
                    if (rootFolder == null)
                    {
                        rootFolder = new Folder(session)
                        {
                            Name = "root",
                            ParentFolderOid = null,
                            OrganizationOid = null,
                            FolderType=EFolderType.RootFolder,
                            FullPath="root"
                        };
                        rootFolder.Save();

                        if(!Directory.Exists(baseRoute +" \\root"))
                        {
                            Directory.CreateDirectory(baseRoute + " \\root");
                        }
                    }

                    var organizationFolder = session.Query<Folder>().FirstOrDefault(t => t.Name == request.OrganizationOid.Value.ToString() && t.ParentFolderOid == rootFolder.Oid && t.FolderType == EFolderType.OrganizationRootFolder);
                    if(organizationFolder == null)
                    {
                        organizationFolder = new Folder(session)
                        {
                            Name = request.OrganizationOid.Value.ToString(),
                            ParentFolderOid = rootFolder.Oid,
                            OrganizationOid = request.OrganizationOid.Value,
                            FolderType = EFolderType.OrganizationRootFolder,
                            FullPath = "root\\" + request.OrganizationOid.Value.ToString()
                        };
                        organizationFolder.Save();
                    }

                    //supplera folder
                    var suppleraFolder = session.Query<Folder>().FirstOrDefault(t => t.Name == "supplera" && t.ParentFolderOid == organizationFolder.Oid);
                    if(suppleraFolder == null)
                    {
                        suppleraFolder = new Folder(session)
                        {
                            Name = "supplera",
                            ParentFolderOid = organizationFolder.Oid,
                            OrganizationOid = request.OrganizationOid.Value,
                            FolderType = EFolderType.ProjectFolder,
                            FullPath = "root\\" + organizationFolder.Name + "\\supplera"
                        };
                    }
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
            return new DYSIntegrationResponseBase
            {
                Success = success
            };
        }
    }
}
