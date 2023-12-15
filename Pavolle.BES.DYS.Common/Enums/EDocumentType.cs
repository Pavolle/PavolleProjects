using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.Common.Enums
{
    //todo bu kısımları daha sonra zenginleştireceğiz.
    //ek olarak bu dosya tiplerine uygun olarak ayrı classlar da oluşturulacak.
    public enum EDocumentType
    {
        Organization=1,
        Dealer,
        Employee,
        Customer,
        Irsaliye,
        Fatura,
        XPerson
    }
}
