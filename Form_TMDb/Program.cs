using System;
using Form_TMDb.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TMDbFormApp;

namespace Form_TMDb
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static async Task Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}