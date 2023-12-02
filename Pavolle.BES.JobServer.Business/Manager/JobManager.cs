using DevExpress.Xpo;
using Pavolle.BES.JobServer.DbModels;
using Pavolle.BES.JobServer.DbModels.Entities;
using Pavolle.BES.JobServer.ViewModels.Criteria;
using Pavolle.BES.JobServer.ViewModels.Request;
using Pavolle.BES.JobServer.ViewModels.Response;
using Pavolle.BES.JobServer.ViewModels.ViewData;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.JobServer.Business.Manager
{
    public class JobManager : Singleton<JobManager>
    {
        private JobManager() { }


        public ResponseBase Add(AddJobRequest request)
        {
            throw new NotImplementedException();
        }

        public ResponseBase Detail(long? oid, IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public ResponseBase Edit(long? oid, EditJobRequest request)
        {
            throw new NotImplementedException();
        }

        public JobListResponse List(ListJobCriteria criteria)
        {
            var response=new JobListResponse();
            using(Session session = JobServerXpoManager.Instance.GetNewSession())
            {
                IQueryable<Job> query= session.Query<Job>();
                if(criteria != null)
                {
                    if(criteria.BesAppType.HasValue)
                    {
                        query=query.Where(t=>t.BesAppType == criteria.BesAppType);
                    }
                }

                response.DataList=query.Select(t=> new JobViewData
                {
                    Oid=t.Oid,
                    CreatedTime=t.CreatedTime,
                    LastUpdateTime=t.LastUpdateTime,
                    LastRunTime=t.LastRunTime,
                    Active=t.Active,
                    ReadableName=t.ReadableName,
                    BesAppType=t.BesAppType,
                    Cron=t.Cron,
                    JobType=t.JobType,
                    RunServiceUrl=t.RunServiceUrl,
                    SendMailAfterRun=t.SendMailAfterRun,
                    MailTo = t.MailTo,
                    SendSMSAfterRun =t.SendSMSAfterRun,
                    SMSTo = t.SMSTo
                }).ToList();
            }
            return response;
        }

        public ResponseBase Run(long? oid, RunJobRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
