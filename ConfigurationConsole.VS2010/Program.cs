using System;
using System.Security.Principal;
using System.Windows.Forms;
using SourcePro.Csharp.Lab.Forms;

namespace SourcePro.Csharp.Lab
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ValidateCurrentUserRole();
        }

        #region GetFormInstanceWithCommandLine
        static private Form GetFormInstanceWithCommandLine()
        {
            string[] clArgs = Environment.GetCommandLineArgs();
            if (clArgs.Length > 1)
            {
                if (clArgs[1].ToLower().Equals("/nonestart")) return new OperatingForm();
                else return new StartupForm();
            }
            else return new StartupForm();
        }
        #endregion

        #region ValidateCurrentUserRole
        static private void ValidateCurrentUserRole()
        {
            try
            {
                WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
                WindowsPrincipal currentPrin = new WindowsPrincipal(currentUser);
                if (!currentPrin.IsInRole(WindowsBuiltInRole.Administrator))
                {
                    MessageBox.Show("Because you are not in the system administrator role, the tool will exit !", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
                else
                {
                    Application.Run(GetFormInstanceWithCommandLine());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
