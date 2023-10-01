using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.PassCross.Models
{
    public class QuestionModel
    {
        public string Password { get; set; }
        public List<QuestionTipModel> Tips { get; set; }
    }
}
