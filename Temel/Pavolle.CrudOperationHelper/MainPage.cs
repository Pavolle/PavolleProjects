﻿using Pavolle.CrudOperationHelper.Business;
using Pavolle.CrudOperationHelper.Business.Common.Enums;
using Pavolle.CrudOperationHelper.Business.DbModels;
using Pavolle.CrudOperationHelper.Business.ViewModels.Criteria;
using Pavolle.CrudOperationHelper.Business.ViewModels.Model;
using Pavolle.CrudOperationHelper.Business.ViewModels.Request;
using Pavolle.CrudOperationHelper.Business.ViewModels.ViewData;
using Pavolle.CrudOperationHelper.Business.WebApp.Controller;
using Pavolle.CrudOperationHelper.Business.WebSecurity;
using Pavolle.CrudOperationHelper.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Pavolle.CrudOperationHelper
{
    public partial class MainPage : Form
    {
        string _selectedProjectName = "";
        public MainPage()
        {
            InitializeComponent();

            try
            {
                string[] text = File.ReadAllLines("appsettings.ini");
                DbManager.Instance.Initialize(text[0]);
                RefreshProjectList();
            }
            catch (Exception)
            {
                MessageBox.Show("Veritabanı bağlantısı sağlanamadı!!!");
            }


            textBoxProjectMame.Enabled = false;
            textBoxProjectOrganization.Enabled = false;
            textBoxProjectsPath.Enabled = false;
            textBoxIssuer.Enabled = false;
            textBoxAudience.Enabled = false;
            textBoxTokenExpire.Enabled = false;
            textBoxLanguage.Enabled = false;
        }

        void RefreshProjectList()
        {
            listBoxProjects.Items.Clear();
            var projectList = DbManager.Instance.GetProjectList();
            foreach (var item in projectList)
            {
                listBoxProjects.Items.Add(item);
            }
        }

        private void buttonAddProject_Click(object sender, EventArgs e)
        {
            CreateProject createProject = new CreateProject();
            createProject.ShowDialog();
            RefreshProjectList();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        void GetProjectDetail(string name)
        {
            var detail = DbManager.Instance.GetProjectDetail(name);

            textBoxProjectMame.Text = detail.Name;
            textBoxProjectOrganization.Text = detail.Organization;
            textBoxProjectsPath.Text = detail.Path;
            textBoxIssuer.Text = detail.Issuer;
            textBoxAudience.Text = detail.Audience;
            textBoxTokenExpire.Text=detail.TokenExpireMinute.ToString();
            textBoxLanguage.Text = detail.Language;

            if (detail.Intialize)
            {
                butttonEditProjects.Enabled = false;
                buttonIntializeProject.Enabled = false;
            }
            else
            {
                butttonEditProjects.Enabled = true;
                buttonIntializeProject.Enabled = true;
            }



            var tableList = DbManager.Instance.GetTableList(name);
            listBoxTables.Items.Clear();

            if (tableList.Count == 0)
            {
                listBoxTables.Items.Add("Tablo Tanımlanmamış!");
                listBoxTables.Enabled = false;
            }
            else
            {
                foreach (var item in tableList)
                {
                    listBoxTables.Items.Add(item);
                }
                listBoxTables.Enabled = true;
            }

            _selectedProjectName = name;
        }

        private void listBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = (string)(((ListBox)sender).SelectedItem);
            GetProjectDetail(name);


        }

        private void butttonEditProjects_Click(object sender, EventArgs e)
        {
            string name = textBoxProjectMame.Text;
            var detail = DbManager.Instance.GetProjectDetail(name);
            EditProject editProject = new EditProject(detail.Name, detail.Organization, detail.Path, detail.UserType, detail.Issuer, detail.Audience, detail.TokenExpireMinute, detail.Language);
            editProject.ShowDialog();

            var detail1 = DbManager.Instance.GetProjectDetail(name);

            textBoxProjectMame.Text = detail1.Name;
            textBoxProjectOrganization.Text = detail1.Organization;
            textBoxProjectsPath.Text = detail1.Path;
            GetProjectDetail(name);
        }

        private void buttonIntializeProject_Click(object sender, EventArgs e)
        {
            //bool createUserTypeEnumClassResult = ProjectInitializeManager.Instance.Start(textBoxProjectMame.Text, textBoxProjectNameRoot.Text, textBoxProjectsPath.Text, textBoxUserTypes.Text, textBoxIssuer.Text, textBoxAudience.Text, Convert.ToInt32(textBoxTokenExpire.Text), textBoxLanguage.Text);

            ApiServiceMethodTypeCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            JobTypeCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            MessageCodeCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            SettingTypeCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            UserTypeCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);

            WebSecurityProjectCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text, Convert.ToInt32(textBoxTokenExpire.Text), textBoxIssuer.Text, textBoxAudience.Text);

            DbModelsCsProjectCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            BaseObjectCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            XpoManagerCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            TranslateDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text, textBoxLanguage.Text);
            ApiServiceCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            CountryCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            CityCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            JobCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            JobChangeLogCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            JobRunLogCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            OrganizationCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            SettingChangeLogCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            SettingCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            UserCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            UserGroupCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            UserPasswordHistoryCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            UserSessionCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);

            #region Criteria
            CriteriaBaseCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            DeleteCityCriteriaCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            DeleteCountryCriteriaCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            DeleteOrganizationCriteriaCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            DeleteUserCriteriaCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            DeleteUserGroupCriteriaCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            ListApiServiceCriteriaCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            ListCityCriteriaCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            ListCountryCriteriaCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            ListJobCriteriaCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            ListOrganizationCriteriaCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);

            ListSettingCriteriaCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            ListTranslateDataCriteriaCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            ListUserCriteriaCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            ListUserGroupCriteriaCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            LookupCityCriteriaCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            LookupCountryCriteriaCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            LookupOrganizationCriteriaCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            LookupUserCriteriaCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            LookupUserGroupCriteriaCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);

            #endregion

            #region Model
            ApiServiceAuthRequestModelCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            AuhtorizationCacheModelCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            CityCacheModelCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text, textBoxLanguage.Text);
            CountryCacheModelCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text, textBoxLanguage.Text);
            OrganizationCacheModelCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            SettingCacheModelCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            TranslateDataCacheModelCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text, textBoxLanguage.Text);
            UserCacheModelCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            UserGroupAuthRequestModelCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            UserGroupCacheModelCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            UserSessionCacheModelCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            #endregion

            #region Request
            RequestBaseCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            AddCityRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            AddCountryRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            AddOrganizationRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            AddUserGroupRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            AddUserRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            ChangePasswordRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            EditApiServiceRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            EditCityRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            EditCountryRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            EditMyInfoRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            EditOrganizationRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            EditSettingRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            EditTranslateDataRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text, textBoxLanguage.Text);
            EditUserRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            EditUserGroupRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            ForgotPasswordRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            LoginRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            ResetPasswordRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            RunJobRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            SendVerificationCodeRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            VerifyCodeRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            VerifyEmailRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            VerifyPhoneRequestCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            #endregion

            #region ViewData
            ApiServiceAuthViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            ApiServiceDetailViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            ApiServiceViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            CityDetailViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            CityViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            CountryDetailViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            CountryViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            JobDetailViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            JobLogViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            JobViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            MyInfoViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            OrganizationDetailViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            OrganizationViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            SettingChangeLogViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            SettingDetailViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            TranslateDataChangeLogViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            TranslateDataDetailViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            TranslateDataViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text, textBoxLanguage.Text);
            UserAuthViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            UserDetailViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            UserGroupAuthViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            UserGroupViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            UserInfoViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            UserViewDataCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            ViewDataBaseCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            #endregion

            #region Business
            #endregion

            #region Controller
            ApiServiceConrollerCreatorManager.Instance.Write(textBoxProjectOrganization.Text, textBoxProjectMame.Text, textBoxProjectsPath.Text);
            #endregion
        }



        private void buttonEditTable_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddTable_Click(object sender, EventArgs e)
        {
            AddTable addTable = new AddTable(_selectedProjectName);
            addTable.ShowDialog();
            GetProjectDetail(_selectedProjectName);
        }

        private void listBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
