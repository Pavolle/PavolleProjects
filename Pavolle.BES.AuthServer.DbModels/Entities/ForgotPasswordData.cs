using DevExpress.Xpo;
using Pavolle.BES.AuthServer.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.DbModels.Entities
{
    [Persistent("forgot_password_data")]
    public class ForgotPasswordData : BaseObject
    {
        public ForgotPasswordData(Session session) : base(session)
        {
        }

        [Persistent("user_oid")]
        public User User { get; set; }


        [Persistent("communication_value")]
        public string CommunicationValue { get; set; }


        [Persistent("verification_code")]
        public string VerificationCode { get; set; }


        [Persistent("reset_password_status")]
        public EResetPasswordStatus ResetPasswordStatus { get; set; }
    }
}
