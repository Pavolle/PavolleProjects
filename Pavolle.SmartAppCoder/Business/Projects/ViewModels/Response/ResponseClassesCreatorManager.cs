using Pavolle.SmartAppCoder.Business;
using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.Response
{
    public class ApiServiceDetailResponseCreatorManager : Singleton<ApiServiceDetailResponseCreatorManager>
    {
        private ApiServiceDetailResponseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public ApiServiceDetailViewData Detail { get; set; }" + Environment.NewLine;
            properties += "        public List<ApiServiceAuthViewData> Authorization { get; set; }" + Environment.NewLine;
            var creator = new ResponseCreatorManager(companyName, projectName, projectPath, properties, "ApiServiceDetailResponse", projectName + "ResponseBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }


    public class ApiServiceListResponseCreatorManager : Singleton<ApiServiceListResponseCreatorManager>
    {
        private ApiServiceListResponseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public List<ApiServiceViewData> DataList { get; set; }" + Environment.NewLine;
            var creator = new ResponseCreatorManager(companyName, projectName, projectPath, properties, "ApiServiceListResponse", projectName + "ResponseBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }


    public class CityDetailResponseCreatorManager : Singleton<CityDetailResponseCreatorManager>
    {
        private CityDetailResponseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public CityDetailViewData Detail { get; set; }" + Environment.NewLine;
            var creator = new ResponseCreatorManager(companyName, projectName, projectPath, properties, "CityDetailResponse", projectName + "ResponseBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }


    public class CityListResponseCreatorManager : Singleton<CityListResponseCreatorManager>
    {
        private CityListResponseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public List<CityViewData> DataList { get; set; }" + Environment.NewLine;
            var creator = new ResponseCreatorManager(companyName, projectName, projectPath, properties, "CityListResponse", projectName + "ResponseBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }


    public class CountryDetailResponseCreatorManager : Singleton<CountryDetailResponseCreatorManager>
    {
        private CountryDetailResponseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public CountryDetailViewData Detail { get; set; }" + Environment.NewLine;
            properties += "        public List<CityViewData> CityList { get; set; }" + Environment.NewLine;
            var creator = new ResponseCreatorManager(companyName, projectName, projectPath, properties, "CountryDetailResponse", projectName + "ResponseBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }


    public class CountryListResponseCreatorManager : Singleton<CountryListResponseCreatorManager>
    {
        private CountryListResponseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public List<CountryViewData> DataList { get; set; }" + Environment.NewLine;
            var creator = new ResponseCreatorManager(companyName, projectName, projectPath, properties, "CountryListResponse", projectName + "ResponseBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }

    public class JobDetailResponseCreatorManager : Singleton<JobDetailResponseCreatorManager>
    {
        private JobDetailResponseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public JobDetailViewData Detail { get; set; }" + Environment.NewLine;
            properties += "        public List<JobLogViewData> JobLogs { get; set; }" + Environment.NewLine;
            var creator = new ResponseCreatorManager(companyName, projectName, projectPath, properties, "JobDetailResponse", projectName + "ResponseBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }


    public class JobListResponseCreatorManager : Singleton<JobListResponseCreatorManager>
    {
        private JobListResponseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public List<JobViewData> DataList { get; set; }" + Environment.NewLine;
            var creator = new ResponseCreatorManager(companyName, projectName, projectPath, properties, "JobListResponse", projectName + "ResponseBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }


    public class ProjectResponseBaseCreatorManager : Singleton<ProjectResponseBaseCreatorManager>
    {
        private ProjectResponseBaseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            var creator = new ResponseCreatorManager(companyName, projectName, projectPath, properties, projectName+ "ResponseBase", "ResponseBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }

    public class MyInfoResponseCreatorManager : Singleton<MyInfoResponseCreatorManager>
    {
        private MyInfoResponseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public MyInfoViewData Data { get; set; }" + Environment.NewLine;
            var creator = new ResponseCreatorManager(companyName, projectName, projectPath, properties, "MyInfoResponse", projectName + "ResponseBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }

    public class OrganizationDetailResponseCreatorManager : Singleton<OrganizationDetailResponseCreatorManager>
    {
        private OrganizationDetailResponseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public OrganizationDetailViewData Detail { get; set; }" + Environment.NewLine;
            var creator = new ResponseCreatorManager(companyName, projectName, projectPath, properties, "OrganizationDetailResponse", projectName + "ResponseBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }

    public class OrganizationListResponseCreatorManager : Singleton<OrganizationListResponseCreatorManager>
    {
        private OrganizationListResponseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public List<OrganizationViewData> DataList { get; set; }" + Environment.NewLine;
            var creator = new ResponseCreatorManager(companyName, projectName, projectPath, properties, "OrganizationListResponse", projectName + "ResponseBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }

    public class SettingDetailResponseCreatorManager : Singleton<SettingDetailResponseCreatorManager>
    {
        private SettingDetailResponseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public SettingDetailViewData Detail { get; set; }" + Environment.NewLine;
            properties += "        public List<SettingChangeLogViewData> ChangeLogs { get; set; }" + Environment.NewLine;
            var creator = new ResponseCreatorManager(companyName, projectName, projectPath, properties, "SettingDetailResponse", projectName + "ResponseBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }

    public class SettingListResponseCreatorManager : Singleton<SettingListResponseCreatorManager>
    {
        private SettingListResponseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public List<SettingViewData> DataList { get; set; }" + Environment.NewLine;
            var creator = new ResponseCreatorManager(companyName, projectName, projectPath, properties, "SettingListResponse", projectName + "ResponseBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }

    public class TokenResponseCreatorManager : Singleton<SettingListResponseCreatorManager>
    {
        private TokenResponseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public int WrongTryCount { get; set; }" + Environment.NewLine;
            properties += "        public bool IsLocked { get; set; }" + Environment.NewLine;
            properties += "        public string Token { get; set; }" + Environment.NewLine;
            properties += "        public List<UserAuthViewData> Authorizations { get; set; }" + Environment.NewLine;
            properties += "        public UserInfoViewData UserInfo { get; set; }" + Environment.NewLine;
            var creator = new ResponseCreatorManager(companyName, projectName, projectPath, properties, "TokenResponse", projectName + "ResponseBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }

    public class TranslateDataDetailResponseCreatorManager : Singleton<TranslateDataDetailResponseCreatorManager>
    {
        private TranslateDataDetailResponseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public TranslateDataDetailViewData Detail { get; set; }" + Environment.NewLine;
            properties += "        public List<TranslateDataChangeLogViewData> ChangeLogViewData { get; set; }" + Environment.NewLine;
            var creator = new ResponseCreatorManager(companyName, projectName, projectPath, properties, "TranslateDataDetailResponse", projectName + "ResponseBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }

    public class TranslateDataListResponseCreatorManager : Singleton<TranslateDataListResponseCreatorManager>
    {

        private TranslateDataListResponseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public List<TranslateDataViewData> DataList { get; set; }" + Environment.NewLine;
            var creator = new ResponseCreatorManager(companyName, projectName, projectPath, properties, "TranslateDataListResponse", projectName + "ResponseBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }

    public class UserDetailResponseCreatorManager : Singleton<UserDetailResponseCreatorManager>
    {

        private UserDetailResponseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public UserDetailViewData Detail { get; set; }" + Environment.NewLine;
            var creator = new ResponseCreatorManager(companyName, projectName, projectPath, properties, "UserDetailResponse", projectName + "ResponseBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }

    public class UserGroupDetailResponseCreatorManager : Singleton<UserGroupDetailResponseCreatorManager>
    {

        private UserGroupDetailResponseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public UserGroupDetailViewData Detail { get; set; }" + Environment.NewLine;
            properties += "        public List<UserGroupAuthViewData> Authorizations { get; set; }" + Environment.NewLine;
            var creator = new ResponseCreatorManager(companyName, projectName, projectPath, properties, "UserGroupDetailResponse", projectName + "ResponseBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }

    public class UserGroupListResponseCreatorManager : Singleton<UserGroupListResponseCreatorManager>
    {

        private UserGroupListResponseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public List<UserGroupViewData> DataList { get; set; }" + Environment.NewLine;
            var creator = new ResponseCreatorManager(companyName, projectName, projectPath, properties, "UserGroupListResponse", projectName + "ResponseBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }

    public class UserListResponseCreatorManager : Singleton<UserListResponseCreatorManager>
    {

        private UserListResponseCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public List<UserViewData> DataList { get; set; }" + Environment.NewLine;
            var creator = new ResponseCreatorManager(companyName, projectName, projectPath, properties, "UserListResponse", projectName + "ResponseBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
