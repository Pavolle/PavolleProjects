using Pavolle.BES.Surrvey.ViewModels.Criteria;
using Pavolle.BES.Surrvey.ViewModels.Request;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.Surrvey.Business
{
    public class QuestionGroupManager : Singleton<QuestionGroupManager>
    {
        private QuestionGroupManager() { }

        public object Detail(long? oid, BesRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object Edit(long? oid, EditQuestionGroupRequest request)
        {
            throw new NotImplementedException();
        }

        public object Add(AddQuestionGroupRequest request)
        {
            throw new NotImplementedException();
        }

        public object List(ListQuestionGroupCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public object Lookup(LookupQuestionGroupCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
