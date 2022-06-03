/*
課題1
接続型を使用して、IntDataを入力させて該当するレコードを出力しなさい。
*/
using System;
using System.Data.SqlClient;

namespace CSMasterADONET.Exercise
{
    class Exercise01
    {
        static void Main()
        {   
            string sql = "SELECT * FROM MyTable WHERE IntData = @p";
            SqlConnection connection = new SqlConnection(ConnectionManager.ConnectionString);
            connection.Open();
            Console.WriteLine("SQLServerに接続しました");

            Console.WriteLine("IntDataを入力してください。");
            int input = Convert.ToInt32(Console.ReadLine());

            

            

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@p", System.Data.SqlDbType.Int);
            cmd.Parameters["@p"].Value = input;

            SqlDataReader reader = cmd.ExecuteReader();
   
                if (reader.Read())
                {

                    int intData = (int)reader["IntData"];
                    double? doubleData = null;
                    if (reader["DoubleData"] != DBNull.Value)
                    {
                        doubleData = (double?)reader["DoubleData"];
                    }

                    decimal? decimalData = null;
                    if (reader["DecimalData"] != DBNull.Value)
                    {
                        decimalData = (decimal?)reader["DecimalData"];
                    }

                    string stringData = null;
                    if (reader["StringData"] != DBNull.Value)
                    {
                        stringData = (string)reader["StringData"];
                    }

                    DateTime? datetimeData = null;
                    if (reader["DatetimeData"] != DBNull.Value)
                    {
                        datetimeData = (DateTime?)reader["DatetimeData"];
                    }

                    bool? boolData = null;
                    if (reader["BoolData"] != DBNull.Value)
                    {
                        boolData = (bool?)reader["BoolData"];
                    }

                    string record = intData + "," + doubleData + ',' + decimalData + "," + stringData + "," + datetimeData + "," + boolData;
                    Console.WriteLine(record);
                }
                else
                {
                    Console.WriteLine("該当レコードはありません");
                }
 
            

            reader.Close();
            connection.Close();
        }
    }
}
