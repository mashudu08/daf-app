using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ST10115884_MashuduLuvhengo_POE_TASK1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ST10115884_MashuduLuvhengo_POE_TASK1.Data
{
    public class DataManager
    {
        static string connStr = "Server=tcp:daf-ngo-server.database.windows.net,1433;Initial Catalog=DAF-DB;Persist Security Info=False;User ID=dafadmin;Password=Lemoncream@2017;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private static SqlConnection conn = new SqlConnection(connStr);
        private static SqlCommand cmd;

        public DataManager()
        {

        }

        public bool openConnection()
        {
            conn.Open();
            return true;
            //try
            //{
            //    conn.Open();
            //    return true;
            //} catch(Exception err)
            //{
            //    throw err;
            //}
        }

        public List<Users> loginUser(Users user)
        {
            //TODO: If you're going to continue with this then we need to start making these db queries asynchronous

            //cmd = new SqlCommand("SELECT * Users WHERE password=@pwd AND email=@email", conn);
            List<Users> users = new List<Users>();
            conn.Open();
            string sqlstring = "SELECT * FROM Users WHERE password=@pwd AND email=@email";
            cmd = new SqlCommand(sqlstring, conn);

            cmd.Parameters.Add("@pwd", System.Data.SqlDbType.VarChar, 250).Value = user.password;
            cmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 250).Value = user.email;

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new Users
                        {
                            email = reader["email"].ToString(),
                            password = reader["password"].ToString()
                        });
                    }
                }
            }
            //SqlDataAdapter sda = new SqlDataAdapter(cmd.CommandText, conn);
            //DataTable dt = new DataTable();
            //    try
            //    {

            //        sda.Fill(dt);

            //        foreach (DataRow item in dt.Rows)
            //        {
            //        users.Add(
            //            new Users
            //            {
            //                email = Convert.ToString(item["email"]),
            //                password = Convert.ToString(item["password"]),
            //            }
            //        );
            //        }
            //    }
            //catch (SqlException se)
            //{
            //    throw;
            //}
            catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            return users;
        }


        public bool donateGoods(Goods goods)
        {
            //TODO: If you're going to continue with this then we need to start making these db queries asynchronous
            try
            {
                cmd = new SqlCommand("INSERT INTO Goods(donationDate, quantity, category, description, donor) VALUES (@date, @quant,@category,@desc, @donor)", conn);
                cmd.Parameters.Add("@date", System.Data.SqlDbType.Date).Value = goods.donationDate;
                cmd.Parameters.Add("@quant", System.Data.SqlDbType.Int).Value = goods.quantity;
                cmd.Parameters.Add("@category", System.Data.SqlDbType.VarChar, 250).Value = goods.category;
                cmd.Parameters.Add("@desc", System.Data.SqlDbType.VarChar, 250).Value = goods.description;
                cmd.Parameters.Add("@donor", System.Data.SqlDbType.VarChar, 250).Value = goods.donor;

                int res = cmd.ExecuteNonQuery();
                conn.Close();

                return res == 1 ? true : false;
            }
            catch (Exception)
            {
                conn.Close();

                throw;
            }

        }

        public bool donateMoney(Monetary money)
        {
            //TODO: If you're going to continue with this then we need to start making these db queries asynchronous
            try
            {
                cmd = new SqlCommand("INSERT INTO Monetary(amount, donationDate, donor) VALUES (@amt, @date, @donor)", conn);
                cmd.Parameters.Add("@amt", System.Data.SqlDbType.Int).Value = money.amount;
                cmd.Parameters.Add("@date", System.Data.SqlDbType.Date).Value = money.donationDate;
                cmd.Parameters.Add("@donor", System.Data.SqlDbType.VarChar, 250).Value = money.donor;

                int res = cmd.ExecuteNonQuery();
                conn.Close();

                return res == 1 ? true : false;
            }
            catch (Exception)
            {
                conn.Close();

                throw;
            }

        }
    }
}

