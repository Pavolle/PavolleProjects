using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.Business.Manager
{
    public class FileDocumentManager : Singleton<FileDocumentManager>
    {
        private FileDocumentManager() 
        {

        }

        //TODO BU kısım yazılacak. Dosyayı klasörden okuyan kod. Önemli bu kısım.
        public string GetBase64FileFromPath(string flagPath)
        {
            return string.Empty;
        }
    }
}
