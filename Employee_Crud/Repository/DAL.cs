using System.Data;
using System.Data.SqlClient;
using Employee_Crud.Models;

namespace Employee_Crud.Repository
{
    public class DAL
    {
        private readonly IConfiguration _configuration;

        public DAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DAL()
        {
        }

        public SqlConnection con = new SqlConnection("Data Source=STPL-INT-ANUS;Initial Catalog=test_mvc;User ID=sa;Password = P@ssw0rd");

        public List<EmployeeModel> GetDataList()
        {
            List<EmployeeModel> lst = new List<EmployeeModel>();
            SqlCommand cmd = new SqlCommand("sp_select", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(new EmployeeModel
                {
                    id = Convert.ToInt32(dr[0]),
                    emailid = Convert.ToString(dr[1]),
                    Password = Convert.ToString(dr[2]),
                    name = Convert.ToString(dr[3]),
                });
            }
            con.Close();
            return lst;
        }
        public bool InsertData(EmployeeModel ur)
        {
            int i;
            SqlCommand cmd = new SqlCommand("sp_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ur.id);
            cmd.Parameters.AddWithValue("@email", ur.emailid);
            cmd.Parameters.AddWithValue("@pwd", ur.Password);
            cmd.Parameters.AddWithValue("@nitesh", ur.name);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateData(EmployeeModel ur)
        {
            int i;
            SqlCommand cmd = new SqlCommand("sp_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Employee_Id", ur.Employee_Id);
            cmd.Parameters.AddWithValue("@Email", ur.Email);
            cmd.Parameters.AddWithValue("@Salary", ur.Salary);
            cmd.Parameters.AddWithValue("@nitesh", ur.Employee_Name);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteData(EmployeeModel ur)
        {
            int i;
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Employee_id", ur.Employee_Id);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
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