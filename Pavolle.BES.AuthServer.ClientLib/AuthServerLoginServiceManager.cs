﻿using Newtonsoft.Json.Linq;
using Pavolle.BES.AuthServer.Common.Utils;
using Pavolle.BES.AuthServer.ViewModels.Request;
using Pavolle.BES.AuthServer.ViewModels.Response;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.ClientLib
{
    public class AuthServerLoginServiceManager : Singleton<AuthServerLoginServiceManager>
    {
        private AuthServerLoginServiceManager() { }

        public ForgotPasswordResponse ForgotPasword(ForgotPasswordRequest request)
        {
            throw new NotImplementedException();
        }

        public ResponseBase ResetPasword(ResetPasswordRequest request)
        {
            throw new NotImplementedException();
        }

        public SignInResponse SignIn(LoginRequest request)
        {
            var response = AuthServiceHelperManager.Instance.Post<SignInResponse>(AuthServerApiUrlConsts.LoginUrlConsts.BaseRoute + "/" + AuthServerApiUrlConsts.LoginUrlConsts.SignInRoutePrefix, request);
            return response;
        }

        public ResponseBase SignOut(BesRequestBase request)
        {
            throw new NotImplementedException();
        }
    }
}
