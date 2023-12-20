using Pavolle.BES.DYS.ViewModels.Criteria;
using Pavolle.BES.DYS.ViewModels.Request;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.Business.Manager
{
    public class DocumentManager : Singleton<DocumentManager>
    {
        private DocumentManager() { }

        public object Detail(long? oid, BesRequestBase request)
        {
            throw new NotImplementedException();
        }

        public object List(ListDocumentCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public object Add(AddDocumentRequest request)
        {
            throw new NotImplementedException();
        }

        public object Lookup(DocumentLookupCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public object Edit(long? oid, EditDocumentRequest request)
        {
            throw new NotImplementedException();
        }

        public object Move(MoveDocumentRequest request)
        {
            throw new NotImplementedException();
        }

        public object Delete(long? oid, BesRequestBase request)
        {
            throw new NotImplementedException();
        }
    }
}
