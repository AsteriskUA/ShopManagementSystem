using System;
using System.Windows.Forms;

namespace ShopManagementSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Users.Initialize(); 

            var loginForm = new LoginForm();
            Application.Run(loginForm); 
        }
    }
}
