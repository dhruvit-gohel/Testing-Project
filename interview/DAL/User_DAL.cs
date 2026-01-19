using interview.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace interview.DAL
{
    public class User_DAL
    {
        SqlConnection con = null;
        SqlCommand CMD = null;

        public static IConfiguration configuration { get; set; }
        private string Getconnectionstring()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            configuration = builder.Build();
            return configuration.GetConnectionString("DefaultConnection");
        }

        public List<User_Data> Get_All()
        {
            List<User_Data> lst = new List<User_Data>();
            using (con = new SqlConnection(Getconnectionstring()))
            {
                CMD = con.CreateCommand();
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.CommandText = "Get_All_Users";
                con.Open();
                SqlDataReader dr = CMD.ExecuteReader();
                while (dr.Read())
                {
                    User_Data um = new User_Data();
                    um.User_Id = Convert.ToInt32(dr["User_Id"]);
                    um.User_Name = dr["User_Name"].ToString();
                    um.User_password = dr["User_password"].ToString();
                    um.User_First_Name = dr["User_First_Name"].ToString();
                    um.User_Middle_Name = dr["User_Middle_Name"].ToString();
                    um.User_Last_Name = dr["User_Last_Name"].ToString();
                    um.User_Mobile_No = Convert.ToInt32(dr["User_Mobile_No"]);
                    lst.Add(um);
                }
                con.Close();
            }
            return lst;
        }

        public bool Insert_User(User_Data model)
        {
            int i = 0;
            using (con = new SqlConnection(Getconnectionstring()))
            {
                CMD = con.CreateCommand();
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.CommandText = "Insert_Registration_Form";
                CMD.Parameters.AddWithValue("@User_Name", model.User_Name);
                CMD.Parameters.AddWithValue("@User_password", model.User_password);
                CMD.Parameters.AddWithValue("@User_First_Name", model.User_First_Name);
                CMD.Parameters.AddWithValue("@User_Middle_Name", model.User_Middle_Name);
                CMD.Parameters.AddWithValue("@User_Last_Name", model.User_Last_Name);
                CMD.Parameters.AddWithValue("@User_Mobile_No", model.User_Mobile_No);
                con.Open();
                i = CMD.ExecuteNonQuery();
                con.Close();
            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
