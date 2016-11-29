using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSU_EPAM_Autumn_2016
{
    class Program
    {
        static void Main(string[] args)
        {
            List<LenNum> lenNumList = new List<LenNum>();
            string fileName = "5_Db.mdb";
            #region find file in working directory
            string substr = "bin\\debug";
            string filePatch = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                 .ToLower().Replace(substr, "")
                 + "\\" + fileName;
            #endregion

            string connectionString1 = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                                             "Data Source =" + filePatch + ";" +
                                             "Persist Security Info = True";

            string selectCommand = @"SELECT int( abs(x1-x2)+0.5) AS len, count(*) as num " +
                "FROM Coordinates " +
                "group by int( abs(x1-x2)+0.5) " +
                "order by int( abs(x1-x2)+0.5) ";
            string insertCommand = @"INSERT INTO Frequencies values ";

            string deleteCommand = @"DELETE * FROM Frequencies";

            string searchCommand = @"SELECT len, num " +
                "FROM Frequencies " +
                "WHERE ((len>num))";


            using (OleDbConnection conn = new OleDbConnection(connectionString1))
            {
                OleDbCommand command = new OleDbCommand(selectCommand, conn);
                conn.Open();
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lenNumList.Add(new LenNum(len: Convert.ToInt32(reader[0]),
                                              num: Convert.ToInt32(reader[1])));
                }
                reader.Close();

                command = new OleDbCommand(deleteCommand, conn);
                command.ExecuteScalar();
                foreach (var itemLenNum in lenNumList)
                {
                    Console.WriteLine(itemLenNum);
                    command = new OleDbCommand(insertCommand + itemLenNum.ToSqlInsert(), conn);
                    command.ExecuteScalar();
                }
                command = new OleDbCommand(searchCommand, conn);
                reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Console.WriteLine(new LenNum(len: Convert.ToInt32(reader[0]),
                                              num: Convert.ToInt32(reader[1])));
                }
            }





            Console.ReadKey();
        }
    }
}
