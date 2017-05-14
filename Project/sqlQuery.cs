using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayDisability
{
    class sqlQuery
    {
        public void deleteUser(string name)
        {
            try
            {
                ConnectionString connect = new ConnectionString();
                using (SqlConnection con = new SqlConnection(connect.connect))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("delete from [Employes] where name = @name", con))
                    {
                        com.Parameters.AddWithValue("@name", name);
                        com.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Работник успешно удалён.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void addUser(Employes emp)
        {
            try
            {
                ConnectionString connect = new ConnectionString();
                using (SqlConnection con = new SqlConnection(connect.connect))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("insert into [Employes]([name], [salary], [experience]) values(@name, @salary, @experience)", con))
                    {
                        com.Parameters.AddWithValue("@name", emp.name);
                        com.Parameters.AddWithValue("@salary", emp.salary);
                        com.Parameters.AddWithValue("@experience", emp.experience);
                        com.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Пользователь успешно добавлен.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Employes> getEmployes()
        {
            try
            {
                ConnectionString connect = new ConnectionString();
                List<Employes> list = new List<Employes>();
                using (SqlConnection con = new SqlConnection(connect.connect))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("select * from [Employes]", con))
                    {
                        SqlDataReader r = com.ExecuteReader();
                        while (r.Read())
                        {
                            Employes emp = new Employes(r.GetString(0), r.GetDouble(1), r.GetInt32(2));
                            list.Add(emp);
                        }
                        r.Close();
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public void addEmployes(Employes emp)
        {
            try
            {
                ConnectionString connect = new ConnectionString();
                using (SqlConnection con = new SqlConnection(connect.connect))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("insert into [Employes]([name], [salary], [experience]) values(@name, @salary, @experience)", con))
                    {
                        com.Parameters.AddWithValue("@name", emp.name);
                        com.Parameters.AddWithValue("@salary", emp.salary);
                        com.Parameters.AddWithValue("@experience", emp.experience);
                        com.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Пользователь успешно добавлен.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}