using System;
using System.Data.SqlClient;
using System.Data;

namespace CSMasterADONET.Exercise
{
    class Exercise04
    {
        static void Main()
        {
            string uQuery = "UPDATE MyTable SET StringData = @p1 WHERE IntData = @p2";
            string sQuery = "SELECT * FROM MyTable WHERE IntData = @p2";

            Console.WriteLine("SQLServerに接続しました");
            Console.WriteLine("IntDataを入力してください。");
            int input = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("StringDataを入力してください。");
            string update = Console.ReadLine();

            runSql(input, sQuery, update);
            runSql(input,sQuery);
            
            ///connection(input, sQuery, update, uQuery);
            ///run

        }
        static void runSql(int input, string sQuery, string update)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionManager.ConnectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sQuery, ConnectionManager.ConnectionString);
                    dataAdapter.UpdateCommand = new SqlCommand();
                    DataTable datatable = new DataTable();
                    dataAdapter.Fill(datatable);


                    //SqlCommand sqlCommand = new SqlCommand();
                    //sqlCommand.Connection = new SqlConnection(ConnectionManager.ConnectionString);
                    //sqlCommand.CommandText = uQuery;
                    dataAdapter.UpdateCommand.Parameters.Add("@p1", SqlDbType.NVarChar).Value = update;

                    Console.WriteLine("ok1");
                    dataAdapter.SelectCommand.Parameters.Add("@p2", SqlDbType.Int).Value = input;

                    Console.WriteLine("ok2");
                    dataAdapter.Update(datatable);

                    Console.WriteLine("Rows after update.");


                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);


            }

                }
    
        static void runSql(int input, string sQuery)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionManager.ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sQuery, ConnectionManager.ConnectionString);
                DataTable datatable = new DataTable();
                dataAdapter.SelectCommand.Parameters.Add("@p2", SqlDbType.Int).Value = input;
                dataAdapter.Fill(datatable);
                int count = datatable.Rows.Count;
                if (count == 0)
                {
                    Console.WriteLine("レコードがありません");
                }
                else
                {
                    foreach (DataRow row in datatable.Rows)
                    {
                        int? intData = row[0] as int?;
                        double? doubleData = row[1] as double?;
                        decimal? decimalData = row[2] as decimal?;
                        string stringData = row[3] as string;
                        DateTime? datetimeData = row[4] as DateTime?;
                        bool? boolData = row[5] as bool?;

                        string record = intData + "," + doubleData + "," + decimalData + "," + stringData + "," + datetimeData + "," + boolData;
                        Console.WriteLine(record);
                    }
                }
            }
        } 
    }
}
