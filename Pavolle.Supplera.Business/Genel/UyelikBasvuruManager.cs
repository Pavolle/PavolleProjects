using DevExpress.Xpo;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Supplera.DbModels;
using Pavolle.Supplera.ViewModels.Request;
using Pavolle.Supplera.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Supplera.Business.Genel
{
    public class UyelikBasvuruManager:Singleton<UyelikBasvuruManager>
    {
        public List<string> _uyelikBasvuruReferansNumaralari;
        private UyelikBasvuruManager() { }

        //Bunu sistemi DDOS ataklarına karşı korumak için tasarlıyoruz.
        private void UpdateUyelikBasvuruReferansList()
        {

        }

        public UyelikBasvuruDetayResponse Detail(string referansNumarasi, RequestBase request)
        {
            throw new NotImplementedException();
        }

        public UyelikBasvuruResponse Add(UyelikBasvuruRequest request)
        {
            var response=new UyelikBasvuruResponse();
            //Request Kontrolleri

            
            using (Session session=XpoManager.Instance.GetNewSession())
            {
                string referansNumarasi = "";

                //oid*17 +3256 SU000003273
                
            }

            return response;
        }

        public object? UyelikBasvuruMesaj(UyelikBasvuruMesajRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
