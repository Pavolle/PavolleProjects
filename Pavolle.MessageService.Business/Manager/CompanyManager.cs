using DevExpress.Xpo;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.DbModels;
using Pavolle.MessageService.DbModels.Entities;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.MessageService.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class CompanyManager:Singleton<CompanyManager>
    {
        private CompanyManager() { }

        public MessageServiceResponseBase Delete(long oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public CompanyDetailResponse Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, CompanyEditRequest request)
        {
            var response = new MessageServiceResponseBase();
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                var company = session.Query<Company>().FirstOrDefault(t => t.Oid == oid);
                if(company == null)
                {
                    response.Success = false;
                    return response;
                }

                company.Name = request.Name;
                company.Address = request.Address;
                company.LastUpdateTime = DateTime.Now;
                company.Save();
               
            }
            return response;
        }

        public MessageServiceResponseBase Add(CompanyRequest request)
        {
            var response=new MessageServiceResponseBase();
            using (Session session=XpoManager.Instance.GetNewSession())
            {
                //Kontroller eklenecek

                session.BeginTransaction();
                var company = new Company(session)
                {
                    Name = request.Name,
                    Code = request.Code,
                    Address = request.Address,
                };
                company.Save();

                User user = UserManager.Instance.CreateNewUser(session, company, EUserType.CompanyAdmin, request.AdminUsername, request.AdminName, request.AdminSurname, request.AdminPassword, request.AdminPhoneNumber, request.AdminEmail);

                if(user != null)
                {
                    company.AdminUser = user;
                    session.CommitTransaction();
                    response.Success = false;
                }
                else
                {
                    session.RollbackTransaction();
                }

            }
            return response;
        }

        public CompanyListResponse List(MessageServiceCriteriaBase criteria)
        {
            var response=new CompanyListResponse();
            return response;
        }

        public LookupResponse Lookup(MessageServiceCriteriaBase criteria)
        {
            throw new NotImplementedException();
        }
    }
}
