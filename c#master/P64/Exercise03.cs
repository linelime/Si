using System;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

namespace CSMasterADONET.Exercise
{
    class Exercise03
    {
        static void Main()
        {   
            string selectSql = "SELECT * FROM MyTable WHERE IntData = @p";
            Console.WriteLine("SQLServerに接続しました");
            Console.WriteLine("IntDataを入力してください。");
            int input = Convert.ToInt32(Console.ReadLine());

            select(input, selectSql);





        }
        static void select(int input,string sql)
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, ConnectionManager.ConnectionString);
                DataTable datatable = new DataTable();
                dataAdapter.SelectCommand.Parameters.Add("@p", SqlDbType.Int).Value = input;
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
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
