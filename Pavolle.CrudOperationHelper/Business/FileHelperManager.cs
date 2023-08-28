using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business
{
    public class FileHelperManager:Singleton<FileHelperManager>
    {
        private FileHelperManager()
        {

        }

        public bool WriteFile(string projectPath, string projectFoldername, string fileName, string data)
        {
            bool response = true;

            try
            {
                if (!Directory.Exists(projectPath + "/" + projectFoldername))
                {
                    Directory.CreateDirectory(projectPath + "/" + projectFoldername);
                }

                if (!File.Exists(projectPath + "/" + projectFoldername + "/" + fileName))
                {
                    File.WriteAllText(projectPath + "/" + projectFoldername + "/" + fileName, data);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                response = false;
            }
            

            return response;
        }

        internal bool EditFile(string projectPath, string projectFoldername, string fileName, string data)
        {
            bool response = true;

            try
            {
                if (!Directory.Exists(projectPath + "/" + projectFoldername))
                {
                    Directory.CreateDirectory(projectPath + "/" + projectFoldername);
                }

                File.WriteAllText(projectPath + "/" + projectFoldername + "/" + fileName, data);
            }
            catch (Exception ex)
            {
                response = false;
            }


            return response;
        }
    }
}
