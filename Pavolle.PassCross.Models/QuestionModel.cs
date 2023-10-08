using Pavolle.PassCross.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.PassCross.Models
{
    public class QuestionModel
    {
        public EGameLevel Level { get; set; }
        public string Password { get; set; }
        public List<QuestionTipModel> Tips { get; set; }
    }
}
