using Pavolle.Core.Enums;
using Pavolle.MessageService.Business.Manager;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.UnitTests
{
    public class ValidationTests
    {
        [SetUp]
        public void Setup()
        {
            XpoManager.Instance.InitXpo("XpoProvider=Postgres;Server=127.0.0.1;User ID=postgres;Password=pavollebilisim;Database=messageservice;Encoding=UNICODE");
            TranslateManager.Instance.LoadTranslateData();
        }

        [Test]
        public void StringTestNullableNullValueSuccess()
        {
            var checkResult = ValidationManager.Instance.CheckString(null, true, 0, 100, true, EMessageCode.ApiService, ELanguage.English);
            Assert.IsNull(checkResult);
        }

        [Test]
        public void StringTestNullableNotNullValueSuccess()
        {
            var checkResult = ValidationManager.Instance.CheckString("Test", true, 0, 100, true, EMessageCode.ApiService, ELanguage.English);
            Assert.IsNull(checkResult);
        }

        [Test]
        public void StringTestNullableNotNullValueMinLengthFail()
        {
            var checkResult = ValidationManager.Instance.CheckString("Test", true, 5, 100, true, EMessageCode.ApiService, ELanguage.English);
            Assert.IsNotNull(checkResult);
        }
    }
}
