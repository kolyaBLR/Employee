using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayDisability
{
    class ConnectionString
    {
        public ConnectionString()
        {
            getFile();
        }
        public void getFile()
        {
            try
            {
                StreamReader sr = new StreamReader(@"connect.txt");
                con = sr.ReadLine();
            }
            catch
            {
                con =  @"Data Source=.\SQLEXPRESS;Initial Catalog=job;Integrated Security=True";
            }
        }

        private string con;
        public string connect { get { return con; } set { con = value; } }
    }
}
