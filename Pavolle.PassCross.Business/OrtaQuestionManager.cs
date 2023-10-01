using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.PassCross.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.PassCross.Business
{
    internal class OrtaQuestionManager : Singleton<OrtaQuestionManager>
    {
        private OrtaQuestionManager() { }

        private QuestionModel _question;
        ELanguage _language;
    }
}
