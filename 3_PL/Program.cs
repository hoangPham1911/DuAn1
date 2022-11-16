using _3_PL.View;

namespace _3_PL
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
<<<<<<< HEAD
            Application.Run(new FormBanHang());
=======
            Application.Run(new FormMain());
>>>>>>> 4e7de052c30ef91cc7b8ddb9f34a5d83a617da7a
        }
    }
}