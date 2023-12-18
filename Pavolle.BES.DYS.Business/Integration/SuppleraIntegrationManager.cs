using DevExpress.Xpo;
using log4net;
using Pavolle.BES.DYS.Business.Manager;
using Pavolle.BES.DYS.Common.Enums;
using Pavolle.BES.DYS.DbModels;
using Pavolle.BES.DYS.DbModels.Entities;
using Pavolle.BES.DYS.ViewModels.Integration.Request;
using Pavolle.BES.DYS.ViewModels.Response;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.Core.Manager;
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
        static readonly ILog _log = LogManager.GetLogger(typeof(SuppleraIntegrationManager));
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

                        if (!Directory.Exists(baseRoute + "\\root"))
                        {
                            Directory.CreateDirectory(baseRoute + "\\root");
                        }
                    }

                    var organizationFolder = session.Query<Folder>().FirstOrDefault(t => t.Name == request.OrganizationOid.Value.ToString() && t.ParentFolderOid == rootFolder.Oid && t.FolderType == EFolderType.OrganizationRootFolder);
                    if(organizationFolder == null)
                    {
                        string organizationFolderDirectory = rootFolder.FullPath + "\\" + request.OrganizationOid.Value.ToString();
                        organizationFolder = new Folder(session)
                        {
                            Name = request.OrganizationOid.Value.ToString(),
                            ParentFolderOid = rootFolder.Oid,
                            OrganizationOid = request.OrganizationOid.Value,
                            FolderType = EFolderType.OrganizationRootFolder,
                            FullPath = organizationFolderDirectory
                        };
                        organizationFolder.Save();

                        if (!Directory.Exists(baseRoute + "\\"+ organizationFolderDirectory))
                        {
                            Directory.CreateDirectory(baseRoute + "\\" + organizationFolderDirectory);
                        }
                    }

                    //supplera folder
                    var suppleraFolder = session.Query<Folder>().FirstOrDefault(t => t.Name == "supplera" && t.ParentFolderOid == organizationFolder.Oid);
                    if(suppleraFolder == null)
                    {
                        string suppleraFolderDirectory = organizationFolder.FullPath + "\\supplera";
                        suppleraFolder = new Folder(session)
                        {
                            Name = "supplera",
                            ParentFolderOid = organizationFolder.Oid,
                            OrganizationOid = request.OrganizationOid.Value,
                            FolderType = EFolderType.ProjectFolder,
                            FullPath = "root\\" + organizationFolder.Name + "\\supplera"
                        };
                        suppleraFolder.Save();

                        if (!Directory.Exists(baseRoute + "\\" + suppleraFolderDirectory))
                        {
                            Directory.CreateDirectory(baseRoute + "\\" + suppleraFolderDirectory);
                        }
                    }

                    //product

                    var productFolder=session.Query<Folder>().FirstOrDefault(t=>t.Name ==request.ProductOid.Value.ToString() && t.ParentFolderOid==suppleraFolder.Oid);
                    if(productFolder == null)
                    {
                        string productFolderDirectory = suppleraFolder.FullPath + "\\"+ request.ProductOid.Value.ToString();
                        productFolder = new Folder(session)
                        {
                            Name = request.ProductOid.Value.ToString(),
                            ParentFolderOid = suppleraFolder.Oid,
                            OrganizationOid = request.OrganizationOid.Value,
                            FolderType = EFolderType.DocumentFolder,
                            FullPath = productFolderDirectory
                        };
                        productFolder.Save();

                        if (!Directory.Exists(baseRoute + "\\" + productFolderDirectory))
                        {
                            Directory.CreateDirectory(baseRoute + "\\" + productFolderDirectory);
                        }
                    }

                    //version

                    var versionFolder=session.Query<Folder>().FirstOrDefault(t=>t.Name==request.VersionOid.Value.ToString() && t.ParentFolderOid==productFolder.Oid);
                    if(versionFolder == null)
                    {
                        string versionFolderDirectory = productFolder.FullPath + "\\" + request.VersionOid.Value.ToString();
                        versionFolder = new Folder(session)
                        {
                            Name = request.VersionOid.Value.ToString(),
                            ParentFolderOid = productFolder.Oid,
                            OrganizationOid = request.OrganizationOid.Value,
                            FolderType = EFolderType.DocumentFolder,
                            FullPath = productFolder + "\\" + request.VersionOid.Value.ToString()
                        };
                        versionFolder.Save();

                        if (!Directory.Exists(baseRoute + "\\" + versionFolderDirectory))
                        {
                            Directory.CreateDirectory(baseRoute + "\\" + versionFolderDirectory);
                        }
                    }

                    //Doküman şifrelenerek eklenecek.
                    string filename=Guid.NewGuid().ToString();
                    string secureKey = Guid.NewGuid().ToString().Substring(3, 8);
                    //document
                    var document = new Document(session)
                    {
                        CanTransfer = false,
                        DocumentType = EDocumentType.SuppleraBomFile,
                        Folder = versionFolder,
                        Name = request.FileName,
                        OrganizationOid = request.OrganizationOid.Value,
                    };
                    document.Save();
                    
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
