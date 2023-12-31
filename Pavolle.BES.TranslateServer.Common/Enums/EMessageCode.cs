﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TranslateServer.Common.Enums
{
    public enum EMessageCode
    {
        [Description("Unexpected error occured!")]
        UnexpectedExceptionOccured=1,

        [Description("Request Data Type Error!")]
        RequestDataTypeError,

        [Description("Unauthorized Exception!")]
        UnauthorizedException,

        [Description("Header")]
        Header,

        [Description("Record Not Found Exception!")]
        RecordNotFoundException,

        [Description("Data Saved Successfully")]
        DataSavedSuccessfully,

        [Description("Data Created Before")]
        DataCreatedBefore,

        [Description("Username or Password Not Correct!")]
        UsernameOrPasswordNotCorrect,

        [Description("Record Cannot Be Deleted!")]
        RecordCannotBeDeleted
    }
}
