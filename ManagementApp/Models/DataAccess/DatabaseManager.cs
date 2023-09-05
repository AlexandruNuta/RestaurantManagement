using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApp.Models.DataAccess
{
    public static class DatabaseManager
    {
        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(@"Data Source=DESKTOP-Q7OK8A5\SQLEXPRESS;Initial Catalog=RestData;Database=RestData;Trusted_Connection=Yes;Integrated Security=SSPI;");
            }
        }
    }
}
