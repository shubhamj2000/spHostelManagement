using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using spHostelManagement.Models;
using System.Data;

namespace spHostelManagement.DBOperations
{
    public class spStudentRepository
    {

        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["spStudentDBEntities"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Student details    
        public bool AddStudent(spStudentModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddNewStdDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FirstName", obj.FirstName);
            com.Parameters.AddWithValue("@LastName", obj.LastName);
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@Address", obj.Address);
            com.Parameters.AddWithValue("@DOB", obj.DOB);

            con.Open();
            int i = com.ExecuteNonQuery();
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
        //To view Student details with generic list     
        public List<spStudentModel> GetAllStudents()
        {
            connection();
            List<spStudentModel> StdList = new List<spStudentModel>();


            SqlCommand com = new SqlCommand("GetStudents", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                StdList.Add(

                    new spStudentModel()
                    {

                        Id = Convert.ToInt32(dr["Id"]),
                        FirstName = Convert.ToString(dr["FirstName"]),
                        LastName = Convert.ToString(dr["LastName"]),
                        Email = Convert.ToString(dr["Email"]),
                        Address = Convert.ToString(dr["Address"]),
                        DOB = Convert.ToDateTime(dr["DOB"])
                    }
                    );
            }

            return StdList;
        }
        //To Update Student details    
        public bool UpdateStudent(spStudentModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateStdDetails", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", obj.Id);
            com.Parameters.AddWithValue("@FirstName", obj.FirstName);
            com.Parameters.AddWithValue("@LastName", obj.LastName);
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@Address", obj.Address);
            com.Parameters.AddWithValue("@DOB", obj.DOB);
            con.Open();
            int i = com.ExecuteNonQuery();
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
        //To delete Student details    
        public bool DeleteStudent(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteStdById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
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