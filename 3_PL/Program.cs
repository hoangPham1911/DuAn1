using _3_PL.View;

namespace _3_PL
{
     static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
<<<<<<< HEAD
            Application.Run(new FrmSale());
=======
            Application.Run(new FrmDangNhap());
>>>>>>> 7f4bf252e30408d2facc690cadc4682486e97cbd

        }
    }
}