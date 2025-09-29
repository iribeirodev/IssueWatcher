using IssueWatcher.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IssueWatcher
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConfigReader reader = new ConfigReader();
            if (!reader.DatabaseFileExists())
            {
                MessageBox.Show(
                    "Parece que não existe o database no caminho especificado no arquivo de configuração. Você será redirecionado para a tela de settings.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Application.Run(new FormSettings());
                return;
            }

            Application.Run(new FormMain());
        }
    }
}
