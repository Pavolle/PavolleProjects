using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pavolle.Supplera.Business.Jobs
{
    //public class JobManager:Singleton<JobManager>
    //{

    //    List<JobViewData> _jobs;
    //    private JobManager() 
    //    {
    //        LoadJobs();
    //    }

    //    public void LoadJobs()
    //    {
    //        using (Session session = XpoManager.Instance.GetNewSession())
    //        {
    //            _jobs = session.Query<Job>().Where(t => t.Active).Select(t => new JobViewData
    //            {
    //                Oid=t.Oid,
    //                Active = t.Active,
    //                JobType = t.JobType,
    //                Cron = t.Cron,
    //                ReadableName=t.ReadableName,
    //                LastRunTime=t.LastRunTime,
    //            }).ToList();
    //        }
    //    }

    //    public KecServerResponseBase Edit(long oid, JobRequest request)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public JobDetailResponse Detail(long oid, LoginRequest request)
    //    {
    //        var response = new JobDetailResponse();
    //        using (Session session = XpoManager.Instance.GetNewSession())
    //        {
    //            var job = session.Query<Job>().FirstOrDefault(t => t.Oid == oid);
    //            response.JobType = job.JobType;
    //            response.Cron = job.Cron;
    //            response.ReadableName = job.ReadableName;
    //            response.LastRunTime = job.LastRunTime;
    //            response.ReadableName = job.ReadableName;
    //            response.LastUpdateTime = job.LastUpdateTime;
    //            response.Oid = job.Oid;

    //            response.Log=session.Query<JobLog>().Where(t=>t.Job.Oid==oid).Select(m=>new JobLogViewData
    //            {
    //                Oid = m.Oid,
    //                CreatedTime = m.CreatedTime,
    //                LastUpdateTime = m.LastUpdateTime,
    //                Success=m.Success,
    //                Explanation = m.Explanation
    //            }).ToList();
    //        }
    //        return response;
    //    }

    //    public KecServerResponseBase Run(long oid, LoginRequest request)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public JobListResponse List(LoginRequest request)
    //    {
    //        try
    //        {
    //            return new JobListResponse
    //            {
    //                DataList = _jobs
    //            };
    //        }
    //        catch (Exception ex)
    //        {
    //            return null;
    //        }
    //    }

    //    internal JobListResponse GetList()
    //    {
    //        return new JobListResponse
    //        {
    //            DataList = _jobs
    //        };
    //    }
    //}
}
