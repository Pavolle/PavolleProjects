using DevExpress.Xpo;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pavolle.CrudOperationHelper.Db
{
    public class DbManager : Singleton<DbManager>
    {
        private DbManager()
        {

        }

        public void Initialize(string connectionString)
        {
            try
            {
                XpoManager.Instance.InitXpo(connectionString);
            }
            catch (Exception ex)
            {
                //TODO Burda info mesajı üretebiliriz. Onu daha sonraya bırakıyoruz.
            }
        }

        public List<string> GetProjectList()
        {
            var response=new List<string>();
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                response= session.Query<Project>().Select(t => t.Name).ToList();
            }
            return response;
        }

        public ProjectViewData? GetProjectDetal(string name)
        {
            var response=new ProjectViewData();
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                response = session.Query<Project>().Where(t => t.Name == name).Select(t => new ProjectViewData
                {
                    Name = t.Name,
                    Root = t.Root,
                    Path = t.Path,
                    Intialize=t.Intialize,
                    UserType=t.UserType
                }).FirstOrDefault();
            }
            return response;
        }

        public bool SaveProject(string name, string root, string path, string userTypes)
        {
            bool response = true;
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                if (session.Query<Project>().Any(t => t.Name == name))
                {
                    response = false;
                }
                else
                {
                    new Project(session)
                    {
                        Name = name,
                        Root = root,
                        Path = path,
                        UserType= userTypes
                    }.Save();
                    response = true;
                }
            }
            return response;
        }

        internal bool EditProject(string name, string root, string path, string userType)
        {
            bool response = true;
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                var project = session.Query<Project>().Where(t => t.Name == name).FirstOrDefault();

                project.Root=root;
                project.Path = path;
                project.LastUpdateTime = DateTime.Now;
                project.UserType= userType;
                project.Save();
            }
            return response;
        }

        internal List<string> GetTableList(string name)
        {
            var response =new List<string>();
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                response = session.Query<Table>().Where(t => t.Project.Name == name).Select(t => t.ClassName).ToList();
            }
            return response;
        }

        internal bool CreateTable(string projectName, string name, string dbname, bool list, bool lookup, bool add, bool edit, bool detail, bool delete)
        {
            var response = true;
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                var project = session.Query<Project>().FirstOrDefault(t => t.Name == projectName);
                if(project == null)
                {
                    response=false;
                }
                else
                {
                    if(session.Query<Table>().Any(t => t.ClassName == name && t.Project.Oid == project.Oid))
                    {
                        response = false;
                    }
                    else
                    {
                        new Table(session)
                        {
                            Project = project,
                            ClassName = name,
                            DbName = dbname,
                            ListService = list,
                            AddService = add,
                            DeleteService = delete,
                            EditService = edit,
                            DetailService = detail,
                            LookupService = lookup
                        }.Save();
                        response=true;
                    }
                }
            }
            return response;
        }
    }

    public class ProjectViewData
    {
        public string Name { get; internal set; }
        public string Root { get; internal set; }
        public string Path { get; internal set; }
        public bool Intialize { get; internal set; }
        public string UserType { get; internal set; }
    }

    public class TableViewData
    {

    }
}
