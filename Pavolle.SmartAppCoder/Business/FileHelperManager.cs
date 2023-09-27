using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business
{
    public class FileHelperManager : Singleton<FileHelperManager>
    {
        private FileHelperManager()
        {

        }

        public bool RemoveFile(string path)
        {
            try
            {
                File.Delete(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool WriteFile(string projectPath, string projectFoldername, string fileName, string data)
        {
            bool response = false;

            try
            {
                if (!string.IsNullOrWhiteSpace(projectFoldername))
                {
                    if (!Directory.Exists(projectPath + "/" + projectFoldername))
                    {
                        Directory.CreateDirectory(projectPath + "/" + projectFoldername);
                    }
                }

                if (!string.IsNullOrWhiteSpace(projectFoldername))
                {
                    if (!File.Exists(projectPath + "/" + projectFoldername + "/" + fileName))
                    {
                        File.WriteAllText(projectPath + "/" + projectFoldername + "/" + fileName, data);
                        response = true;
                    }
                }
                else
                {
                    if (!File.Exists(projectPath + "/" + fileName))
                    {
                        File.WriteAllText(projectPath + "/" + fileName, data);
                        response = true;
                    }
                }
            }
            catch (Exception ex)
            {
                response = false;
            }


            return response;
        }

        public bool EditFile(string projectPath, string projectFoldername, string fileName, string data)
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

        public bool CheckFolderExisting(string path)
        {
            return Directory.Exists(path);
        }
    }
}
