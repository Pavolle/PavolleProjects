using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.ViewModels.Response
{
    public class BesResponseBase : ResponseBase
    {
        //Bu bilgi varsa token geçerlilik süresi bitmek üzere. 10 dakika kala tekrar üretilir.
        //Bir kullanıcı ile ilgili 1 den fazla token'a izin verecek miyiz? evet!

        public bool ValidSession { get; set; }
        public string RefreshToken { get; set; }
    }
}
