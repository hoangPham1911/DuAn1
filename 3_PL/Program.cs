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
            Application.Run(new Frm_NSX());
=======
            Application.Run(new FrmHangHoa());
>>>>>>> 9bca4fa7f073b4ce8cfcf32a40c37830dc977ea3

        }
    }
}