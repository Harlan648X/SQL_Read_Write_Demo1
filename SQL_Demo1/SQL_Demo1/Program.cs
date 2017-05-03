using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CONNECTIONSTRING=@"Data Source =.\SQLEXPRESS; Initial Catalog = simple_sql;
            User ID = te_student; Password = sqlserver1";


            Read_Write2Sql writer = new Read_Write2Sql(CONNECTIONSTRING);
            writer.WriteIt();
            writer.ReadIt();

        }
    }
}
