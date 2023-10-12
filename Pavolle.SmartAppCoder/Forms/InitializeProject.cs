using DevExpress.Xpo;
using Pavolle.SmartAppCoder.Business;
using Pavolle.SmartAppCoder.Business.Core.Enum;
using Pavolle.SmartAppCoder.Business.Core.Helper;
using Pavolle.SmartAppCoder.Business.Core.Utils;
using Pavolle.SmartAppCoder.Business.Core.ViewModels.Model;
using Pavolle.SmartAppCoder.Business.Core.ViewModels.Request;
using Pavolle.SmartAppCoder.Business.Core.ViewModels.Response;
using Pavolle.SmartAppCoder.Business.Core.ViewModels.ViewData;
using Pavolle.SmartAppCoder.Business.Projects.Common.Utils;
using Pavolle.SmartAppCoder.Business.Projects.Common.Enums;
using Pavolle.SmartAppCoder.Business.Security;
using Pavolle.SmartAppCoder.Business.Security.Hash;
using Pavolle.SmartAppCoder.Business.Security.Symmetric;
using Pavolle.SmartAppCoder.Models;
using Pavolle.SmartAppCoder.Business.Projects.WebSecurity;
using Pavolle.SmartAppCoder.Business.Projects.DbModels;
using Pavolle.SmartAppCoder.Business.Projects.ViewModels.Criteria;
using Pavolle.SmartAppCoder.Business.Projects.ViewModels.Model;
using Pavolle.SmartAppCoder.Business.Projects.ViewModels.Request;
using Pavolle.SmartAppCoder.Business.Projects.ViewModels.ViewData;
using Pavolle.SmartAppCoder.Business.Projects.ViewModels.Response;
using Pavolle.SmartAppCoder.Business.Projects.ProjectBusiness;

namespace Pavolle.SmartAppCoder.Forms
{
    public partial class InitializeProject : Form
    {
        long _projectOid;
        Project? _project;
        Thread thread;
        Thread writeThread;
        public InitializeProject(long projectOid)
        {
            _projectOid = projectOid;
            InitializeComponent();

            using (Session session = XpoManager.Instance.GetNewSession())
            {
                _project = session.Query<Project>().FirstOrDefault(t => t.Oid == projectOid);
            }

            labelProjectInfo.Text = _project.OrganizationName + "." + _project.ProjectName;
        }

        private void StartGenerating()
        {
            Output("Proje oluşturma başlatılıyor...");

            #region Core
            Output("Core projesi kontrol ediliyor...");

            bool coreProjesiOlusturulmus = FileHelperManager.Instance.CheckFolderExisting(_project.ProjectPath + "/" + _project.OrganizationName + ".Core");
            if (!coreProjesiOlusturulmus)
            {
                Output("Core projesi oluşturulmamış! Proje oluşturma başlatıldı");
                //CommandHelperManager.Instance.RunCommand("dotnet , _project.ProjectPath");

                bool result = CommandHelperManager.Instance.RunDotnetCommand("new classlib --framework \"net7.0\" -o " + _project.ProjectPath + "/" + _project.OrganizationName + ".Core").Result;
                if (result)
                {
                    Output("Core projesi oluşturuldu. Proje eklemesi yapılıyor...");
                }

                bool addResult = CommandHelperManager.Instance.RunDotnetCommand("sln " + _project.ProjectPath + "\\" + _project.OrganizationName + "Projects.sln add " + _project.ProjectPath + "\\" + _project.OrganizationName + ".Core\\" + _project.OrganizationName + ".Core.csproj  --solution-folder Core").Result;
                if (addResult)
                {
                    Output("Core projesi proje dosyasına eklendi.");
                }

                Output("Core class1 dosyası siliniyor...");
                FileHelperManager.Instance.RemoveFile(_project.ProjectPath + "\\" + _project.OrganizationName + ".Core\\" + "Class1.cs");
                Output("Core projesi temizlendi. Proje sınıfları kontrol ediliyor...");
            }

            if (EnumExtensionsCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create EnumExtensions Class => ok");
            if (SingletonCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create Singleton Class => ok");

            if (CommunicationTypeCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create ECommunicationType Class => ok");
            if (JobStatusCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create EJobStatus Class => ok");
            if (LanguageCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create ELanguage Class => ok");
            if (SecurityLevelCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create ESecurityLevel Class => ok");


            if(!FileHelperManager.Instance.CheckFolderExisting(_project.ProjectPath + "/" + _project.OrganizationName + ".Core" + "/ViewModels"))
            {
                Output("Create Core\\ViewModels directory => ok");
                Directory.CreateDirectory(_project.ProjectPath + "/" + _project.OrganizationName + ".Core" + "/ViewModels");
            }

            if (LanguageNameModelCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create LanguageNameModel Class => ok");
            if (LanguageModelCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create LanguageModel Class => ok");


            if (IRequestCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create IRequest Class => ok");
            if (RequestBaseCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create RequestBase Class => ok");


            if (ViewDataBaseCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create ViewDataBase Class => ok");
            if (LookupViewDataCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create LookupViewData Class => ok");
            if (ImageLookupViewDataCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create ImageLookupViewData Class => ok");


            if (IResponseCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create IResponse Class => ok");
            if (ResponseBaseCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create ResponseBase Class => ok");
            if (LookupResponsCreatorManagere.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create LookupRespons Class => ok");
            if (ImageLookupResponseCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create ImageLookupResponse Class => ok");

            if (LanguageHelperManagerCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create LanguageHelperManager Class => ok");

            Output("Core projesi kontroller tamamlandı. Eksik dosyalar tekrar eklendi!");
            #endregion

            #region Security
            Output("Security projesi kontrol ediliyor...");
            bool securityProjesiOlusturulmus = FileHelperManager.Instance.CheckFolderExisting(_project.ProjectPath + "/" + _project.OrganizationName + ".Security");
            if (!securityProjesiOlusturulmus)
            {
                Output("Security projesi oluşturulmamış! Proje oluşturma başlatıldı");
                //CommandHelperManager.Instance.RunCommand("dotnet , _project.ProjectPath");

                bool result = CommandHelperManager.Instance.RunDotnetCommand("new classlib --framework \"net7.0\" -o " + _project.ProjectPath + "/" + _project.OrganizationName + ".Security").Result;
                if (result)
                {
                    Output("Security projesi oluşturuldu. Proje eklemesi yapılıyor...");
                }

                bool addResult = CommandHelperManager.Instance.RunDotnetCommand("sln " + _project.ProjectPath + "\\" + _project.OrganizationName + "Projects.sln add " + _project.ProjectPath + "\\" + _project.OrganizationName + ".Security\\" + _project.OrganizationName + ".Security.csproj  --solution-folder Core").Result;
                if (addResult)
                {
                    Output("Security projesi proje dosyasına eklendi.");
                }

                Output("Security kütüphanesine Core uygulama referansı ekleniyor...");

                bool addCoreReferanceResult = CommandHelperManager.Instance.RunDotnetCommand("add " + _project.ProjectPath + "\\" + _project.OrganizationName + ".Security\\" + _project.OrganizationName + ".Security.csproj  reference " + _project.ProjectPath + "\\" + _project.OrganizationName + ".Core\\" + _project.OrganizationName + ".Core.csproj").Result;

                Output("Security class1 dosyası siliniyor...");
                FileHelperManager.Instance.RemoveFile(_project.ProjectPath + "\\" + _project.OrganizationName + ".Security\\" + "Class1.cs");
                Output("Security projesi temizlendi. Proje sınıfları kontrol ediliyor...");
            }

            if (SecurityHelperCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create SecurityHelper Class => ok");
            if (PasswordGeneratorManagerCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create PasswordGeneratorManager Class => ok");
            if (SecurityHelperManagerCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create SecurityHelperManager Class => ok");

            if (IHashAlgorithmCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create IHashAlgorithm Class => ok");
            if (AbstractHashAlgorithmCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create AbstarctHashAlgorithm Class => ok");
            if (SHA1HashAlgorithmCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create SHA1HashAlgorithm Class => ok");
            if (SHA256HashAlgorithmCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create SHA256HashAlgorithm Class => ok");
            if (SHA384HashAlgorithmCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create SHA384HashAlgorithm Class => ok");
            if (SHA512HashAlgorithmCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create SHA512HashAlgorithm Class => ok");

            if (ISymmetricCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create ISymmetric Class => ok");
            if (AESAlgorithmCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create AESAlgorithm Class => ok");
            if (RC2AlgorithmCreatorManager.Instance.Create(_project.ProjectPath, _project.OrganizationName)) Output("Create RC2Algorithm Class => ok");



            Output("Security projesi oluşturma/güncelleme süreci tamamlandı.");
            #endregion

            #region Project

            string projectRoot = _project.OrganizationName + "." + _project.ProjectName;

            #region Project Common
            Output("Common projesi kontrol ediliyor...");

            bool commonProjesiOlusturulmus = FileHelperManager.Instance.CheckFolderExisting(_project.ProjectPath + "/" + projectRoot + ".Common");
            if (!commonProjesiOlusturulmus)
            {
                Output("Common projesi oluşturulmamış! Proje oluşturma başlatıldı");
                //CommandHelperManager.Instance.RunCommand("dotnet , _project.ProjectPath");

                bool result = CommandHelperManager.Instance.RunDotnetCommand("new classlib --framework \"net7.0\" -o " + _project.ProjectPath + "/" + projectRoot + ".Common").Result;
                if (result)
                {
                    Output("Common projesi oluşturuldu. Proje eklemesi yapılıyor...");
                }

                bool addResult = CommandHelperManager.Instance.RunDotnetCommand("sln " + _project.ProjectPath + "\\" + _project.OrganizationName + "Projects.sln add " + _project.ProjectPath + "\\" + projectRoot + ".Common\\" + projectRoot + ".Common.csproj  --solution-folder " + _project.ProjectName).Result;
                if (addResult)
                {
                    Output("Common projesi proje dosyasına eklendi.");
                }

                Output("Common class1 dosyası siliniyor...");
                FileHelperManager.Instance.RemoveFile(_project.ProjectPath + "\\" +projectRoot + ".Common\\" + "Class1.cs");
                Output("Common projesi temizlendi. Proje sınıfları kontrol ediliyor...");
            }

            if(ApiServiceMethodTypeCreatorManager.Instance.Create(_project.OrganizationName, _project.ProjectName, _project.ProjectPath))
            {
                Output("Create EApiServiceMethodType Class => ok");
            }

            if (JobTypeCreatorManager.Instance.Create(_project.OrganizationName, _project.ProjectName, _project.ProjectPath))
            {
                Output("Create EJobType Class => ok");
            }

            if (MessageCodeCreatorManager.Instance.Create(_project.OrganizationName, _project.ProjectName, _project.ProjectPath))
            {
                Output("Create EMessageCode Class => ok");
            }

            if (SettingTypeCreatorManager.Instance.Create(_project.OrganizationName, _project.ProjectName, _project.ProjectPath))
            {
                Output("Create ESettingType Class => ok");
            }

            if (UserTypeCreatorManager.Instance.Create(_project.OrganizationName, _project.ProjectName, _project.ProjectPath))
            {
                Output("Create EUserType Class => ok");
            }

            if(ApiUrlConstsCreatorManager.Instance.Create(_project.OrganizationName, _project.ProjectName, _project.ProjectPath))
            {
                Output("Create ApiUrlConsts Class => ok");
            }
            Output("Common projesi oluşturma ve kontrol tamamlandı.");

            #endregion

            #region Web Security

            Output("WebSecurity projesi kontrol ediliyor...");
            bool webSecurityProjesiOlusturulmus = FileHelperManager.Instance.CheckFolderExisting(_project.ProjectPath + "/" + projectRoot + ".WebSecurity");
            if (!webSecurityProjesiOlusturulmus)
            {
                Output("WebSecurity projesi oluşturulmamış! Proje oluşturma başlatıldı");
                //CommandHelperManager.Instance.RunCommand("dotnet , _project.ProjectPath");

                bool result = CommandHelperManager.Instance.RunDotnetCommand("new classlib --framework \"net7.0\" -o " + _project.ProjectPath + "/" + projectRoot + ".WebSecurity").Result;
                if (result)
                {
                    Output("WebSecurity projesi oluşturuldu. Proje eklemesi yapılıyor...");
                }

                bool addResult = CommandHelperManager.Instance.RunDotnetCommand("sln " + _project.ProjectPath + "\\" + _project.OrganizationName + "Projects.sln add " + _project.ProjectPath + "\\" + projectRoot + ".WebSecurity\\" + projectRoot + ".WebSecurity.csproj  --solution-folder " + _project.ProjectName).Result;
                if (addResult)
                {
                    Output("WebSecurity projesi proje dosyasına eklendi.");
                }

                bool addCoreReferanceResult = CommandHelperManager.Instance.RunDotnetCommand("add " + _project.ProjectPath + "\\" + projectRoot + ".WebSecurity\\" + projectRoot + ".WebSecurity.csproj  reference " + _project.ProjectPath + "\\" + _project.OrganizationName + ".Core\\" + _project.OrganizationName + ".Core.csproj").Result;
                if (addCoreReferanceResult)
                {
                    Output("WebSecurity Projesine Core referansı eklendi.");
                }

                bool addCommonReferanceResult = CommandHelperManager.Instance.RunDotnetCommand("add " + _project.ProjectPath + "\\" + projectRoot + ".WebSecurity\\" + projectRoot + ".WebSecurity.csproj  reference " + _project.ProjectPath + "\\" + projectRoot + ".Common\\" + projectRoot + ".Common.csproj").Result;
                if (addCoreReferanceResult)
                {
                    Output("WebSecurity Projesine Common referansı eklendi.");
                }

                bool addPackageIdentityModelTokens = CommandHelperManager.Instance.RunDotnetCommand("add " + _project.ProjectPath + "\\" + projectRoot + ".WebSecurity\\" + projectRoot + ".WebSecurity.csproj  package Microsoft.IdentityModel.Tokens -v 6.32.0").Result;
                if(addPackageIdentityModelTokens)
                {
                    Output("WebSecurity Projesine Microsoft.IdentityModel.Tokens kütüphanesi eklendi.");
                }

                bool addPackageIdentityJWTTokens = CommandHelperManager.Instance.RunDotnetCommand("add " + _project.ProjectPath + "\\" + projectRoot + ".WebSecurity\\" + projectRoot + ".WebSecurity.csproj  package System.IdentityModel.Tokens.Jwt -v 6.32.0").Result;
                if (addPackageIdentityJWTTokens)
                {
                    Output("WebSecurity Projesine System.IdentityModel.Tokens.Jwt kütüphanesi eklendi.");
                }

                Output("WebSecurity class1 dosyası siliniyor...");
                FileHelperManager.Instance.RemoveFile(_project.ProjectPath + "\\" + projectRoot + ".WebSecurity\\" + "Class1.cs");
                Output("WebSecurity projesi temizlendi. Proje sınıfları kontrol ediliyor...");
            }


            if (IdentityCreatorManager.Instance.Create(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create Identity Class => ok");
            if (PrincipalCreatorManager.Instance.Create(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create Principal Class => ok");
            if (JwtTokenManagerCreatorManager.Instance.Create(_project.OrganizationName, _project.ProjectName, _project.ProjectPath, _project.TokenExpireMinute.ToString())) Output("Create JwtTokenManager Class => ok");
            if (SecurityConstsManagerCreatorManager.Instance.Create(_project.OrganizationName, _project.ProjectName, _project.ProjectPath, _project.Issuer, _project.Audience, "73{0}4df+5gdgaq@@&&www-3421-3-ff!dsfwwwd{1}fb34g7ugfdsfvfv-PAVOLLE-34sde-w!we3e!7/r34r@w*wefd{2}ssd5ww4545zss")) Output("Create SecurityConstsManager Class => ok");
            Output("WebSecurity projesi oluşturma ve kontrol tamamlandı.");

            #endregion

            #region DbModels
            Output("DbModels projesi kontrol ediliyor...");
            bool dbModelsProjesiOlusturulmus = FileHelperManager.Instance.CheckFolderExisting(_project.ProjectPath + "/" + projectRoot + ".DbModels");
            if (!dbModelsProjesiOlusturulmus)
            {
                Output("DbModels projesi oluşturulmamış! Proje oluşturma başlatıldı");
                //CommandHelperManager.Instance.RunCommand("dotnet , _project.ProjectPath");

                bool result = CommandHelperManager.Instance.RunDotnetCommand("new classlib --framework \"net7.0\" -o " + _project.ProjectPath + "/" + projectRoot + ".DbModels").Result;
                if (result)
                {
                    Output("DbModels projesi oluşturuldu. Proje eklemesi yapılıyor...");
                }

                bool addResult = CommandHelperManager.Instance.RunDotnetCommand("sln " + _project.ProjectPath + "\\" + _project.OrganizationName + "Projects.sln add " + _project.ProjectPath + "\\" + projectRoot + ".DbModels\\" + projectRoot + ".DbModels.csproj  --solution-folder " + _project.ProjectName).Result;
                if (addResult)
                {
                    Output("DbModels projesi proje dosyasına eklendi.");
                }

                bool addCoreReferanceResult = CommandHelperManager.Instance.RunDotnetCommand("add " + _project.ProjectPath + "\\" + projectRoot + ".DbModels\\" + projectRoot + ".DbModels.csproj  reference " + _project.ProjectPath + "\\" + _project.OrganizationName + ".Core\\" + _project.OrganizationName + ".Core.csproj").Result;
                if (addCoreReferanceResult)
                {
                    Output("DbModels Projesine Core referansı eklendi.");
                }

                bool addCommonReferanceResult = CommandHelperManager.Instance.RunDotnetCommand("add " + _project.ProjectPath + "\\" + projectRoot + ".DbModels\\" + projectRoot + ".DbModels.csproj  reference " + _project.ProjectPath + "\\" + projectRoot + ".Common\\" + projectRoot + ".Common.csproj").Result;
                if (addCoreReferanceResult)
                {
                    Output("DbModels Projesine Common referansı eklendi.");
                }

                bool addPackageIdentityModelTokens = CommandHelperManager.Instance.RunDotnetCommand("add " + _project.ProjectPath + "\\" + projectRoot + ".DbModels\\" + projectRoot + ".DbModels.csproj  package DevExpress.Xpo -v 23.1.3").Result;
                if (addPackageIdentityModelTokens)
                {
                    Output("DbModels Projesine DevExpress.Xpo kütüphanesi eklendi.");
                }

                Output("DbModels class1 dosyası siliniyor...");
                FileHelperManager.Instance.RemoveFile(_project.ProjectPath + "\\" + projectRoot + ".DbModels\\" + "Class1.cs");
                Output("DbModels projesi temizlendi. Proje sınıfları kontrol ediliyor...");
            }



            Output("DbModels projesi oluşturma ve kontrol tamamlandı.");
            if (ApiServiceCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ApiService Class => ok");
            if (AuthCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create Auth Class => ok");
            if (BaseObjectCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create BaseObject Class => ok");
            if (CityCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create City Class => ok");
            if (CountryCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create Country Class => ok");
            if (JobChangeLogCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create JobChnageLog Class => ok");
            if (JobCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create Job Class => ok");
            if (JobRunLogCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create JobRunLog Class => ok");
            if (OrganizationCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create Organization Class => ok");
            if (SettingChangeLogCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create SettingChangeLog Class => ok");
            if (SettingCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create Setting Class => ok");
            if (TranslateDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath, _project.Languages)) Output("Create TranslateData Class => ok");
            if (UserCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create User Class => ok");
            if (UserGroupCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create UserGroup Class => ok");
            if (UserPasswordHistoryCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create UserPasswordHistory Class => ok");
            if (UserSessionCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create UserSession Class => ok");
            if (XpoManagerCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create XpoManager Class => ok");
            #endregion

            #region ViewModels
            Output("ViewModels projesi kontrol ediliyor...");
            bool viewModelsProjesiOlusturulmus = FileHelperManager.Instance.CheckFolderExisting(_project.ProjectPath + "/" + projectRoot + ".ViewModels");
            if (!viewModelsProjesiOlusturulmus)
            {
                Output("ViewModels projesi oluşturulmamış! Proje oluşturma başlatıldı");
                //CommandHelperManager.Instance.RunCommand("dotnet , _project.ProjectPath");

                bool result = CommandHelperManager.Instance.RunDotnetCommand("new classlib --framework \"net7.0\" -o " + _project.ProjectPath + "/" + projectRoot + ".ViewModels").Result;
                if (result)
                {
                    Output("ViewModels projesi oluşturuldu. Proje eklemesi yapılıyor...");
                }

                bool addResult = CommandHelperManager.Instance.RunDotnetCommand("sln " + _project.ProjectPath + "\\" + _project.OrganizationName + "Projects.sln add " + _project.ProjectPath + "\\" + projectRoot + ".ViewModels\\" + projectRoot + ".ViewModels.csproj  --solution-folder " + _project.ProjectName).Result;
                if (addResult)
                {
                    Output("ViewModels projesi proje dosyasına eklendi.");
                }

                bool addCoreReferanceResult = CommandHelperManager.Instance.RunDotnetCommand("add " + _project.ProjectPath + "\\" + projectRoot + ".ViewModels\\" + projectRoot + ".ViewModels.csproj  reference " + _project.ProjectPath + "\\" + _project.OrganizationName + ".Core\\" + _project.OrganizationName + ".Core.csproj").Result;
                if (addCoreReferanceResult)
                {
                    Output("ViewModels Projesine Core referansı eklendi.");
                }

                bool addCommonReferanceResult = CommandHelperManager.Instance.RunDotnetCommand("add " + _project.ProjectPath + "\\" + projectRoot + ".ViewModels\\" + projectRoot + ".ViewModels.csproj  reference " + _project.ProjectPath + "\\" + projectRoot + ".Common\\" + projectRoot + ".Common.csproj").Result;
                if (addCoreReferanceResult)
                {
                    Output("ViewModels Projesine Common referansı eklendi.");
                }

                Output("ViewModels class1 dosyası siliniyor...");
                FileHelperManager.Instance.RemoveFile(_project.ProjectPath + "\\" + projectRoot + ".ViewModels\\" + "Class1.cs");
                Output("ViewModels projesi temizlendi. Proje sınıfları kontrol ediliyor...");
            }

            #region Criteria
            Output("Criteria classları kontrol ediliyor...");
            if (CriteriaBaseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create CriteriaBase Class => ok");
            if (DeleteCityCriteriaCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create DeleteCity Class => ok");
            if (DeleteCountryCriteriaCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create DeleteCountry Class => ok");
            if (DeleteOrganizationCriteriaCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create DeleteOrganization Class => ok");
            if (DeleteUserCriteriaCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create DeleteUser Class => ok");
            if (DeleteUserGroupCriteriaCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create DeleteUserGroup Class => ok");
            if (ListApiServiceCriteriaCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ListApiService Class => ok");
            if (ListCityCriteriaCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ListCityCriteria Class => ok");
            if (ListCountryCriteriaCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ListCountryCriteria Class => ok");
            if (ListJobCriteriaCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ListJobCriteria Class => ok");
            if (ListOrganizationCriteriaCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ListOrganizationCriteria Class => ok");
            if (ListSettingCriteriaCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ListSettingCriteria Class => ok");
            if (ListTranslateDataCriteriaCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ListTranslateDataCriteria Class => ok");
            if (ListUserCriteriaCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ListUserCriteria Class => ok");
            if (ListUserGroupCriteriaCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ListUserGroupCriteria Class => ok");
            if (LookupCityCriteriaCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create LookupCityCriteria Class => ok");
            if (LookupCountryCriteriaCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create LookupCountryCriteria Class => ok");
            if (LookupOrganizationCriteriaCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create LookupOrganizationCriteria Class => ok");
            if (LookupUserCriteriaCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create LookupUserCriteria Class => ok");
            if (LookupUserGroupCriteriaCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create LookupUserGroupCriteria Class => ok");
            Output("Criteria tamamlandı.");
            #endregion

            #region Model
            Output("Model classları kontrol ediliyor...");
            if (ApiServiceAuthRequestModelCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ApiServiceAuthRequestModel Class => ok");
            if (AuhtorizationCacheModelCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create AuhtorizationCacheModel Class => ok");
            if (CityCacheModelCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath, _project.Languages)) Output("Create CityCacheModel Class => ok");
            if (CountryCacheModelCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath, _project.Languages)) Output("Create CountryCacheModel Class => ok");
            if (OrganizationCacheModelCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create OrganizationCacheModel Class => ok");
            if (SettingCacheModelCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create SettingCacheModel Class => ok");
            if (TranslateDataCacheModelCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath, _project.Languages)) Output("Create TranslateDataCacheModel Class => ok");
            if (UserCacheModelCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create UserCacheModel Class => ok");
            if (UserGroupAuthRequestModelCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ApiServiceAuthRequestModel Class => ok");
            if (UserGroupCacheModelCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create UserGroupCacheModel Class => ok");
            if (UserSessionCacheModelCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create UserSessionCacheModel Class => ok");

            Output("Model tamamlandı.");
            #endregion

            #region Request
            Output("Request classları kontrol ediliyor...");

            if (AddCityRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create AddCityRequest Class => ok");
            if (AddCountryRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create AddCountryRequest Class => ok");
            if (AddOrganizationRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create UserSessionCacheModel Class => ok");
            if (AddOrganizationRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create AddOrganizationRequest Class => ok");
            if (AddUserGroupRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create AddUserGroupRequest Class => ok");
            if (AddUserRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create AddUserRequest Class => ok");
            if (ChangePasswordRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ChangePasswordRequest Class => ok");
            if (EditApiServiceRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create EditApiServiceRequest Class => ok");
            if (EditCityRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create EditCityRequest Class => ok");
            if (EditCountryRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create EditCountryRequest Class => ok");
            if (EditJobRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create EditJobRequest Class => ok");
            if (EditMyInfoRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create EditMyInfoRequest Class => ok");
            if (EditOrganizationRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create EditOrganizationRequest Class => ok");
            if (EditSettingRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create EditSettingRequest Class => ok");
            if (EditTranslateDataRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath, _project.Languages)) Output("Create UserSessionCacheModel Class => ok");
            if (EditUserGroupRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create EditUserGroupRequest Class => ok");
            if (EditUserRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create EditUserRequest Class => ok");
            if (ForgotPasswordRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ForgotPasswordRequest Class => ok");
            if (LoginRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create LoginRequest Class => ok");
            if (ProjectRequestBaseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ProjectRequestBase Class => ok");
            if (ResetPasswordRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ResetPassword Class => ok");
            if (RunJobRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create RunJobRequest Class => ok");
            if (SendVerificationCodeRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create SendVerificationCodeRequest Class => ok");
            if (VerifyCodeRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create VerifyCodeRequest Class => ok");
            if (VerifyEmailRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create VerifyEmailRequest Class => ok");
            if (VerifyPhoneRequestCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create VerifyPhoneRequest Class => ok");


            Output("Request tamamlandı.");
            #endregion

            #region View Data

            Output("ViewData classları kontrol ediliyor...");
            if (ApiServiceAuthViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ApiServiceAuthViewData Class => ok");
            if (ApiServiceDetailViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ApiServiceDetailViewData Class => ok");
            if (ApiServiceViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ApiServiceViewData Class => ok");
            if (CityDetailViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create CityDetailViewData Class => ok");
            if (CityViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create CityViewData Class => ok");
            if (CountryDetailViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create CountryDetailViewData Class => ok");
            if (CountryViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create CountryViewData Class => ok");

            if (JobDetailViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create JobDetailViewData Class => ok");
            if (JobLogViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create JobLogViewData Class => ok");
            if (JobViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create JobViewData Class => ok");
            if (MyInfoViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create MyInfoViewData Class => ok");
            if (OrganizationDetailViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create OrganizationDetailViewData Class => ok");
            if (OrganizationViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create OrganizationViewData Class => ok");
            if (SettingChangeLogViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create SettingChangeLog Class => ok");
            if (SettingDetailViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create SettingDetailViewData Class => ok");
            if (SettingViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create VerifyPhoneRequest Class => ok");
            if (TranslateDataChangeLogViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath, _project.Languages)) Output("Create TranslateDataChangeLogView Class => ok");
            if (TranslateDataDetailViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath,  _project.Languages)) Output("Create TranslateDataDetailViewData Class => ok");
            if (TranslateDataViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath, _project.Languages)) Output("Create TranslateDataViewData Class => ok");
            if (UserAuthViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create UserAuthViewData Class => ok");
            if (UserGroupAuthViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create UserGroupAuthViewData Class => ok");
            if (UserGroupDetailViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create UserGroupDetailViewData Class => ok");
            if (UserGroupViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create UserGroupViewData Class => ok");
            if (UserInfoViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create UserInfoViewData Class => ok");
            if (UserViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create UserViewData Class => ok");
            if (UserDetailViewDataCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create UserDetailViewData Class => ok");
            if (ProjectViewDataBaseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ProjectViewDataBase Class => ok");

            Output("ViewData tamamlandı.");
            #endregion

            #region Response

            Output("Response classları kontrol ediliyor...");

            if (ApiServiceDetailResponseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ApiServiceDetailResponse Class => ok");
            if (ApiServiceListResponseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ApiServiceListResponse Class => ok");
            if (CityDetailResponseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create CityDetailResponse Class => ok");
            if (CityListResponseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create CityListResponse Class => ok");
            if (CountryDetailResponseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create CountryDetailResponse Class => ok");
            if (CountryListResponseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create CountryListResponse Class => ok");
            if (JobDetailResponseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create JobDetailResponse Class => ok");
            if (JobListResponseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create JobListResponse Class => ok");
            if (ProjectResponseBaseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create ProjectResponseBase Class => ok");
            if (MyInfoResponseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create MyInfoResponse Class => ok");
            if (OrganizationDetailResponseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create OrganizationDetailResponse Class => ok");
            if (OrganizationListResponseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create OrganizationListResponse Class => ok");
            if (SettingDetailResponseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create SettingDetailResponse Class => ok");
            if (SettingListResponseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create SettingListResponse Class => ok");
            if (TokenResponseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create TokenResponse Class => ok");
            if (TranslateDataDetailResponseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create TranslateDataDetailResponse Class => ok");
            if (TranslateDataListResponseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create TranslateDataListResponse Class => ok");
            if (UserDetailResponseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create UserDetailResponse Class => ok");
            if (UserGroupDetailResponseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create UserGroupDetailResponse Class => ok");
            if (UserGroupListResponseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create UserGroupListResponse Class => ok");
            if (UserListResponseCreatorManager.Instance.Write(_project.OrganizationName, _project.ProjectName, _project.ProjectPath)) Output("Create UserListResponse Class => ok");
            Output("Response tamamlandı.");
            #endregion

            #endregion


            #region Business
            Output("Business projesi kontrol ediliyor...");
            bool businessProjesiOlusturulmus = FileHelperManager.Instance.CheckFolderExisting(_project.ProjectPath + "/" + projectRoot + ".Business");
            if (!businessProjesiOlusturulmus)
            {
                Output("DbModels projesi oluşturulmamış! Proje oluşturma başlatıldı");
                //CommandHelperManager.Instance.RunCommand("dotnet , _project.ProjectPath");

                bool result = CommandHelperManager.Instance.RunDotnetCommand("new classlib --framework \"net7.0\" -o " + _project.ProjectPath + "/" + projectRoot + ".Business").Result;
                if (result)
                {
                    Output("Business projesi oluşturuldu. Proje eklemesi yapılıyor...");
                }

                bool addResult = CommandHelperManager.Instance.RunDotnetCommand("sln " + _project.ProjectPath + "\\" + _project.OrganizationName + "Projects.sln add " + _project.ProjectPath + "\\" + projectRoot + ".Business\\" + projectRoot + ".Business.csproj  --solution-folder " + _project.ProjectName).Result;
                if (addResult)
                {
                    Output("DbModels projesi proje dosyasına eklendi.");
                }

                bool addCoreReferanceResult = CommandHelperManager.Instance.RunDotnetCommand("add " + _project.ProjectPath + "\\" + projectRoot + ".Business\\" + projectRoot + ".Business.csproj  reference " + _project.ProjectPath + "\\" + _project.OrganizationName + ".Core\\" + _project.OrganizationName + ".Core.csproj").Result;
                if (addCoreReferanceResult)
                {
                    Output("Business Projesine Core referansı eklendi.");
                }

                bool addCoreSecurityeReferanceResult = CommandHelperManager.Instance.RunDotnetCommand("add " + _project.ProjectPath + "\\" + projectRoot + ".Business\\" + projectRoot + ".Business.csproj  reference " + _project.ProjectPath + "\\" + _project.OrganizationName + ".Security\\" + _project.OrganizationName + ".Security.csproj").Result;
                if (addCoreSecurityeReferanceResult)
                {
                    Output("Business Projesine Security referansı eklendi.");
                }

                bool addCommonReferanceResult = CommandHelperManager.Instance.RunDotnetCommand("add " + _project.ProjectPath + "\\" + projectRoot + ".Business\\" + projectRoot + ".Business.csproj  reference " + _project.ProjectPath + "\\" + projectRoot + ".Common\\" + projectRoot + ".Common.csproj").Result;
                if (addCommonReferanceResult)
                {
                    Output("Business Projesine Common referansı eklendi.");
                }

                bool adddbModelsReferanceResult = CommandHelperManager.Instance.RunDotnetCommand("add " + _project.ProjectPath + "\\" + projectRoot + ".Business\\" + projectRoot + ".Business.csproj  reference " + _project.ProjectPath + "\\" + projectRoot + ".DbModels\\" + projectRoot + ".DbModels.csproj").Result;
                if (adddbModelsReferanceResult)
                {
                    Output("Business Projesine DbModels referansı eklendi.");
                }

                bool addViewModelsReferanceResult = CommandHelperManager.Instance.RunDotnetCommand("add " + _project.ProjectPath + "\\" + projectRoot + ".Business\\" + projectRoot + ".Business.csproj  reference " + _project.ProjectPath + "\\" + projectRoot + ".ViewModels\\" + projectRoot + ".ViewModels.csproj").Result;
                if (addViewModelsReferanceResult)
                {
                    Output("Business Projesine ViewModels referansı eklendi.");
                }

                bool addWebSecurirtReferanceResult = CommandHelperManager.Instance.RunDotnetCommand("add " + _project.ProjectPath + "\\" + projectRoot + ".Business\\" + projectRoot + ".Business.csproj  reference " + _project.ProjectPath + "\\" + projectRoot + ".WebSecurity\\" + projectRoot + ".WebSecurity.csproj").Result;
                if (addWebSecurirtReferanceResult)
                {
                    Output("Business Projesine WebSecurity referansı eklendi.");
                }

                bool addXpoReferance = CommandHelperManager.Instance.RunDotnetCommand("add " + _project.ProjectPath + "\\" + projectRoot + ".Business\\" + projectRoot + ".Business.csproj  package DevExpress.Xpo -v 23.1.3").Result;
                if (addXpoReferance)
                {
                    Output("Business Projesine DevExpress.Xpo kütüphanesi eklendi.");
                }
                bool log4netReferance = CommandHelperManager.Instance.RunDotnetCommand("add " + _project.ProjectPath + "\\" + projectRoot + ".Business\\" + projectRoot + ".Business.csproj  package log4net -v 2.0.15").Result;
                if (log4netReferance)
                {
                    Output("Business Projesine log4net kütüphanesi eklendi.");
                }
                bool quartzReferance = CommandHelperManager.Instance.RunDotnetCommand("add " + _project.ProjectPath + "\\" + projectRoot + ".Business\\" + projectRoot + ".Business.csproj  package Quartz -v 3.6.3").Result;
                if (quartzReferance)
                {
                    Output("Business Projesine Quartz kütüphanesi eklendi.");
                }

                Output("Business class1 dosyası siliniyor...");
                FileHelperManager.Instance.RemoveFile(_project.ProjectPath + "\\" + projectRoot + ".Business\\" + "Class1.cs");
                Output("Business projesi temizlendi. Proje sınıfları kontrol ediliyor...");
            }


            if (TranslateManagerCreatorManager.Instance.Create(_project.OrganizationName, _project.ProjectName, _project.ProjectPath, _project.Languages)) Output("Create TranslateManager Class => ok");
            if (SettingManagerCreatorManager.Instance.Create(_project.OrganizationName, _project.ProjectName, _project.ProjectPath, _project.Languages)) Output("Create SettingManager Class => ok");
            if (ValidationManagerCreatorManager.Instance.Create(_project.OrganizationName, _project.ProjectName, _project.ProjectPath, _project.Languages)) Output("Create ValidationManager Class => ok");
            if (DbManagerCreatorManager.Instance.Create(_project.OrganizationName, _project.ProjectName, _project.ProjectPath, _project.Languages)) Output("Create DbManager Class => ok");

            Output("Business Tamamlandı.");
            #endregion
            #endregion

            Output("Proje oluşturma tamamlandı!");
        }



        private void buttonStart_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(StartGenerating));
            thread.Start();
        }

        void Output(string message)
        {
            writeThread = new Thread(new ParameterizedThreadStart(WriteMessage));
            writeThread.Start(message);
        }

        private void WriteMessage(object state)
        {
            try
            {
                string message = (string)state;
                textBoxOutput.BeginInvoke((MethodInvoker)(() =>
                {
                    textBoxOutput.AppendText(message + Environment.NewLine);

                }));
            }
            catch (Exception)
            {

            }
        }
    }
}
