using System;
using System.Windows.Forms;

namespace OnlineStoreProject
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try 
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Помилка при запуску: {ex.Message}\n\nДеталі: {ex.InnerException?.Message}", 
                                "Критична помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                
                Console.WriteLine(ex.ToString());
            }
        }
    }
}