using Pavolle.PassCross.Business;

namespace Pavolle.PassCross.UnitTests
{
    public class AcemiQuestionTests
    {
        [Fact]
        public void SoruOlustur()
        {
            AcemiQuestionManager.Instance.GenerateQuestion(Core.Enums.ELanguage.Turkish);
        }
    }
}