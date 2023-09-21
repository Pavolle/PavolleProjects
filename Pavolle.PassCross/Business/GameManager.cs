using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.PassCross.Common.Enums;
using Pavolle.PassCross.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.PassCross.Business
{
    public class GameManager : Singleton<GameManager>
    {
        private GameManager() { }

        public QuestionModel GenerateNewGame(EGameLevel gameLevel, ELanguage language)
        {
            switch (gameLevel)
            {
                case EGameLevel.Aday:
                    return AdayQuestionManager.Instance.GenerateAdayQuestion(language);
                case EGameLevel.Acemi:
                    return AcemiQuestionManager.Instance.GenerateAdayQuestion(language);
                case EGameLevel.Orta:
                    break;
                case EGameLevel.Tecrubeli:
                    break;
                case EGameLevel.Uzman:
                    break;
                case EGameLevel.Virtuoz:
                    break;
                case EGameLevel.Ustat:
                    break;
                case EGameLevel.Efsanevi:
                    break;
                case EGameLevel.UstunVarlik:
                    break;
                default:
                    break;
            }

            return null;
        }

       
    }
}
