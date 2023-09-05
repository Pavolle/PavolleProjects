﻿using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
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
    public class CountryManager:Singleton<CountryManager>
    {
        private CountryManager() { }

        public MessageServiceResponseBase Delete(long? oid, DeleteCountryCriteria request)
        {
            throw new NotImplementedException();
        }

        public object Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, EditCountryRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Add(AddCountryRequest request)
        {
            throw new NotImplementedException();
        }

        public object List(ListCountryCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public LookupResponse Lookup(LookupCountryCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
