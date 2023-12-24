using Pavolle.BES.DYS.ViewModels.Criteria;
using Pavolle.BES.DYS.ViewModels.Request;
using Pavolle.BES.DYS.ViewModels.Response;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
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

        public DocumentDetailResponse Detail(long? oid, BesRequestBase request)
        {
            throw new NotImplementedException();
        }

        public DocumentListResponse List(ListDocumentCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public ResponseBase Add(AddDocumentRequest request)
        {
            throw new NotImplementedException();
        }

        public LookupResponse Lookup(DocumentLookupCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public ResponseBase Edit(long? oid, EditDocumentRequest request)
        {
            throw new NotImplementedException();
        }

        public ResponseBase Move(MoveDocumentRequest request)
        {
            throw new NotImplementedException();
        }

        public object Delete(long? oid, BesRequestBase request)
        {
            throw new NotImplementedException();
        }
    }
}
