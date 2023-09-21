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
    public class AcemiQuestionManager : Singleton<AcemiQuestionManager>
    {
        private AcemiQuestionManager() { }

        private QuestionModel _question;
        ELanguage _language;

        internal QuestionModel GenerateAdayQuestion(ELanguage language)
        {
            _language = language;
            var question = new QuestionModel()
            {
                Tips = new List<QuestionTipModel>()
            };


            /* 1ci rakamla başladığında
             şifre => 432
             Kural 1 546 => 4 var yeri yanlış
             Kural 2 690 => hiç bir rakam doğru değil!
             Kural 3 735 => 3 var ve yeri doğru
             Kural 4 258 => 2 var ve yeri yanlış
             */

            /* 2ci rakamla başladığında
             şifre => 432
             Kural 1 386 => 3 var yeri yanlış
             Kural 2 758 => hiç bir rakam doğru değil!
             Kural 3 465 => 4 var ve yeri doğru
             Kural 4 528 => 2 var ve yeri yanlış
             */

            /* 3ci rakamla başladığında
             şifre => 432
             Kural 1 286 => 2 var yeri yanlış
             Kural 2 910 => hiç bir rakam doğru değil!
             Kural 3 465 => 4  var ve yeri doğru
             Kural 4 563 => 3  var ve yeri yanlış
             */

            Random random = new Random();
            int baslangicIndexi = random.Next(0, 3);

            BirinciKuraliOlustur(baslangicIndexi);
            IkinciKuraliOlustur();
            UcuncuKuraliOlustur(baslangicIndexi);
            DorduncuKuraliOlustur(baslangicIndexi);

            return question;
        }

        private void BirinciKuraliOlustur(int baslangicIndexi)
        {
            if (baslangicIndexi == 0)
            {

            }
            if(baslangicIndexi == 1)
            {

            }
            if(baslangicIndexi == 2)
            {

            }
        }

        private void IkinciKuraliOlustur()
        {
            throw new NotImplementedException();
        }

        private void UcuncuKuraliOlustur(int baslangicIndexi)
        {
            if (baslangicIndexi == 0)
            {

            }
            if (baslangicIndexi == 1)
            {

            }
            if (baslangicIndexi == 2)
            {

            }
        }

        private void DorduncuKuraliOlustur(int baslangicIndexi)
        {
            if (baslangicIndexi == 0)
            {

            }
            if (baslangicIndexi == 1)
            {

            }
            if (baslangicIndexi == 2)
            {

            }
        }
    }
}
