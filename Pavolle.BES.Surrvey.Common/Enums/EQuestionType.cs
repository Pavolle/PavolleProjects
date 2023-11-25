using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.Surrvey.Common.Enums
{
    public enum EQuestionType
    {
        //İşaretli cevap 
        SingleCheckbox = 1,

        //Çoklu seçmeli soru
        MultipleChoiceCheckBox,

        //Tek seçmeli soru
        RadioGroup,

        //Doğru veya Yanlış
        TrueFalse,

        //Aralıklı cevaplar
        NumberRanges,

        //Seviyeli soru. Örneğin 1 den 5 kadar klasik derecelendirme
        ClassicLevels,

        EntryText,

        EntryNumber
    }
}
