using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business
{
    public class CommandHelperManager : Singleton<CommandHelperManager>
    {
        private CommandHelperManager() { }

        public void RunCommand(string command, string path)
        {

            Process p = new Process();
            p.StartInfo.FileName = "C:\\Windows\\system32\\cmd.exe";
            p.StartInfo.WorkingDirectory = @path;
            p.StartInfo.Arguments = command;
            p.Start();
        }

        public async Task<Version> GetVersion()
        {
            ProcessStartInfo startInfo = new()
            {
                FileName = "dotnet",
                Arguments = "--version",
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            var proc = Process.Start(startInfo);
            ArgumentNullException.ThrowIfNull(proc);
            string output = proc.StandardOutput.ReadToEnd();
            await proc.WaitForExitAsync();
            return Version.Parse(output);
        }

        public async Task<bool> RunDotnetCommand(string argument)
        {
            ProcessStartInfo startInfo = new()
            {
                FileName = "dotnet",
                Arguments = argument,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            var proc = Process.Start(startInfo);
            ArgumentNullException.ThrowIfNull(proc);
            string output = proc.StandardOutput.ReadToEnd();
            await proc.WaitForExitAsync();
            return true;
        }
    }
}
