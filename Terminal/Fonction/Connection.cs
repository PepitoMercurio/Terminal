using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    class Connection
    {
        private static string Host = "db.whffwzstzzsuzaogqwtx.supabase.co";
        private static string User = "postgres";
        private static string DBname = "postgres";
        private static string Password = "@ButterDog@123@";
        private static string Port = "5432";

        public static string Setup()
        {
            string connString =
                String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);

            return connString;
        }
    }
}
