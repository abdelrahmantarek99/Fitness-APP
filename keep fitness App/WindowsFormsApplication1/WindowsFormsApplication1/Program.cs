using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace WindowsFormsApplication1
{
    static class Program
    {
       // public static string User_cont;
        public static   bool status,yes=false;
        public static string usrname;
        public static  string gend;
        public static int ID;
       /// public static int v1, v2, v3;
       public static Form1 frm = new Form1();
        public static Uc_reg reg = new Uc_reg();
        public static forget_pass forget = new forget_pass();
        public static Uc_log log = new Uc_log();
       // public static start2 s = new start2();
  
        // public static start st = new start();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
           // Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
