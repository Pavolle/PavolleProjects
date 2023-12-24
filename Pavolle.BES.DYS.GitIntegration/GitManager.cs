using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.GitIntegration
{
    public class GitManager : Singleton<GitManager>
    {
        private GitManager() { }
    }

    //Her doküman için ayrı git projesi oluşturacağız.
    //Doküman değişikliklerini git üzerinden takip edebilir durumda olacağız.
}
