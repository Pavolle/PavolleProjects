using DevExpress.Xpo;
using log4net;
using Pavolle.BES.JobServer.DbModels;
using Pavolle.BES.JobServer.DbModels.Entities;
using Pavolle.BES.JobServer.ViewModels.Criteria;
using Pavolle.BES.JobServer.ViewModels.Request;
using Pavolle.BES.JobServer.ViewModels.Response;
using Pavolle.BES.JobServer.ViewModels.ViewData;
using Pavolle.BES.TranslateServer.ClientLib;
using Pavolle.BES.TranslateServer.Common.Enums;
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
        static readonly ILog _log = LogManager.GetLogger(typeof(JobManager));
        private JobManager() { }


        public ResponseBase Add(AddJobRequest request)
        {
            var response=new ResponseBase();
            //TODO Request Kontrolleri
            try
            {
                using (Session session = JobServerXpoManager.Instance.GetNewSession())
                {
                    if (session.Query<Job>().Any(t => t.JobType == request.JobType))
                    {
                        response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.DataCreatedBefore, request.Language.Value);
                        response.StatusCode = 400;
                    }
                    else
                    {
                        var job = new Job(session)
                        {
                            BesAppType = request.BesAppType.Value,
                            Active = request.Active.Value,
                            ReadableName = request.ReadableName,
                            Cron = request.Cron,
                            RunServiceUrl = request.RunServiceUrl,
                            JobType = request.JobType.Value,
                            LastRunTime = null,
                            MailTo = request.MailTo,
                            SendMailAfterRun = request.SendMailAfterRun.Value,
                            SendSMSAfterRun = request.SendSMSAfterRun.Value,
                            SMSTo = request.SMSTo
                        };
                        job.Save();
                        _log.Info("New job createad. Job Type => " + request.JobType.Value.ToString());
                        response.SuccessMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.DataSavedSuccessfully, request.Language.Value);
                    }
            }
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value);
                response.StatusCode = 500;
            }
            

            return response;
        }

        public JobDetailResponse Detail(long? oid, IntegrationAppRequestBase request)
        {
            var response = new JobDetailResponse();
            //TODO Request Kontrolleri
            try
            {
                using (Session session = JobServerXpoManager.Instance.GetNewSession())
                {
                    var job = session.Query<Job>().FirstOrDefault(t => t.Oid == oid);
                    if (job == null)
                    {
                        response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RecordNotFoundException, request.Language.Value);
                        response.StatusCode = 400;
                    }
                    else
                    {
                        response.Detail = new JobDetailViewData
                        {
                            Active = job.Active,
                            BesAppType = job.BesAppType,
                            CreatedTime = job.CreatedTime,
                            LastRunTime = job.LastRunTime,
                            Cron = job.Cron,
                            JobType = job.JobType,
                            LastUpdateTime = job.LastUpdateTime,
                            MailTo = job.MailTo,
                            Oid = job.Oid,
                            ReadableName = job.ReadableName,
                            RunServiceUrl = job.RunServiceUrl,
                            SendMailAfterRun = job.SendMailAfterRun,
                            SendSMSAfterRun = job.SendSMSAfterRun,
                            SMSTo = job.SMSTo
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value);
                response.StatusCode = 500;
            }

            return response;



            
        }

        public ResponseBase Edit(long? oid, EditJobRequest request)
        {
            var response = new ResponseBase();
            //TODO Request Kontrolleri
            try
            {
                using (Session session = JobServerXpoManager.Instance.GetNewSession())
                {
                    var job = session.Query<Job>().FirstOrDefault(t => t.Oid == oid);
                    if (job == null)
                    {
                        response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RecordNotFoundException, request.Language.Value);
                        response.StatusCode = 400;
                    }
                    else
                    {
                        //todo değişikliklerle ilgili log oluşturulacak.
                        job.Active = request.Active.Value;
                        job.ReadableName = request.ReadableName;
                        job.Cron = request.Cron;
                        job.RunServiceUrl = request.RunServiceUrl;
                        job.SendMailAfterRun = request.SendMailAfterRun.Value;
                        job.MailTo = request.MailTo;
                        job.SendSMSAfterRun = request.SendSMSAfterRun.Value;
                        job.SMSTo = request.SMSTo;
                        job.Save();
                        _log.Info("Job data updated. Job Type => " + job.JobType.ToString());
                        response.SuccessMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.DataSavedSuccessfully, request.Language.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value);
                response.StatusCode = 500;
            }

            return response;
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
            var response = new JobDetailResponse();
            //TODO Request Kontrolleri
            try
            {
                using (Session session = JobServerXpoManager.Instance.GetNewSession())
                {
                    var job = session.Query<Job>().FirstOrDefault(t => t.Oid == oid);
                    if (job == null)
                    {
                        response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RecordNotFoundException, request.Language.Value);
                        response.StatusCode = 400;
                    }
                    else
                    {
                        //todo manuel çalıştırma yönlendirme. Belki aktif olup olmadığı gibi sürelere bakıp bu süreye göre kararlar verebiliriz.
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value);
                response.StatusCode = 500;
            }

            return response;
        }
    }
}
