using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.MembershipServer.Business.Manager
{
    public class MembershipServerRabbitMQManager : Singleton<MembershipServerRabbitMQManager>
    {
        private MembershipServerRabbitMQManager() { }

        //TODO şimdilik direk veritabanına yazacağız. Daha sonra burası RabbitMQ ile çalışır hale getirilecek. Bunu mükerrer kayıtların oluşmasını önlemek için yapıyoruz. Aynı zamanda request id client side tarafına gönderilip cache bilgisi olarak tutulacak. Bu da başvuru durumunun görüntülenebilmesini ve detayının sorgulanabilmesini sağlacak.
    }
}
