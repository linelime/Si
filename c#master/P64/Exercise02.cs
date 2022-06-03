using System;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

namespace CSMasterADONET.Exercise
{
    class Exercise02
    {
        static void Main()
        {
            ///sql command
            string updateSql = "UPDATE MyTable SET StringData = @p1 WHERE IntData = @p2";
            string selectSql = "SELECT * FROM MyTable WHERE IntData = @p2";

            Console.WriteLine("SQLServerに接続しました");
            Console.WriteLine("IntDataを入力してください。");
            int input = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("StringDataを入力してください。");
            String inputString = Console.ReadLine();

            ///run
            SqlSelect(input, inputString, updateSql);
            SqlSelect(input, selectSql);

        }
        static void SqlSelect(int input, string inputString, string sqlQuarry)
        {
            try
            {
                //接続型の更新系処理
                using (SqlConnection connection = new SqlConnection(ConnectionManager.ConnectionString))
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlQuarry, connection);
                        command.Parameters.Add("@p1", SqlDbType.NVarChar).Value = inputString;
                        command.Parameters.Add("@p2", SqlDbType.Int).Value = input;
                        if (command.ExecuteNonQuery() == 0)
                        {
                            Console.WriteLine("該当レコードはありません。");
                        }
                        else
                        {
                            Console.WriteLine("更新しました。");
                        }
                        transaction.Complete();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        static void SqlSelect(int input, string sqlQuarry)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionManager.ConnectionString))
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = sqlQuarry;
                        cmd.Parameters.Add("@p2", System.Data.SqlDbType.Int);
                        cmd.Parameters["@p2"].Value = input;

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

                        transaction.Complete();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
