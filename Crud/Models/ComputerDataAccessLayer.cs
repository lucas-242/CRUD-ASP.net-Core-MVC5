using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Models
{
    public class ComputerDataAccessLayer
    {
        string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=CrudComputer;Data Source=LAPTOP-AN1NK0TS\\SQLEXPRESS";

        //To list all computers
        public IEnumerable<Computer> GetAllComputer()
        {
            try
            {
                List<Computer> list = new List<Computer>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllComputer", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Computer computer = new Computer();

                        computer.id = Convert.ToInt32(rdr["computerId"]);
                        computer.brand = rdr["brand"].ToString();
                        computer.model = rdr["model"].ToString();
                        computer.motherBoard = rdr["motherBoard"].ToString();
                        computer.ram = rdr["ram"].ToString();
                        computer.hd = rdr["hd"].ToString();
                        computer.cpu = Convert.ToDouble(rdr["cpu"]);
                        computer.image = rdr["image"].ToString();

                        list.Add(computer);
                    }
                    con.Close();
                }
                return list;
            }
            catch
            {
                throw;
            }
        }

        //To add a new computer
        public int NewComputer(Computer computer)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spNewComputer", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@brand", computer.brand);
                    cmd.Parameters.AddWithValue("@model", computer.model);
                    cmd.Parameters.AddWithValue("@motherBoard", computer.motherBoard);
                    cmd.Parameters.AddWithValue("@ram", computer.ram);
                    cmd.Parameters.AddWithValue("@hd", computer.hd);
                    cmd.Parameters.AddWithValue("@cpu", computer.cpu);
                    cmd.Parameters.AddWithValue("@image", computer.image);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To update a computer
        public int UpdateComputer(Computer computer)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateComputer", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@comId", computer.id);
                    cmd.Parameters.AddWithValue("@brand", computer.brand);
                    cmd.Parameters.AddWithValue("@model", computer.model);
                    cmd.Parameters.AddWithValue("@motherBoard", computer.motherBoard);
                    cmd.Parameters.AddWithValue("@ram", computer.ram);
                    cmd.Parameters.AddWithValue("@hd", computer.hd);
                    cmd.Parameters.AddWithValue("@cpu", computer.cpu);
                    cmd.Parameters.AddWithValue("@image", computer.image);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a computer
        public Computer GetComputerData(int id)
        {
            try
            {
                Computer computer = new Computer();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM computer WHERE computerId= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        computer.id = Convert.ToInt32(rdr["computerId"]);
                        computer.brand = rdr["brand"].ToString();
                        computer.model = rdr["model"].ToString();
                        computer.motherBoard = rdr["motherBoard"].ToString();
                        computer.ram = rdr["ram"].ToString();
                        computer.hd = rdr["hd"].ToString();
                        computer.cpu = Convert.ToDouble(rdr["cpu"]);
                        computer.image = rdr["image"].ToString();
                    }
                }
                return computer;
            }
            catch
            {
                throw;
            }
        }

        //To Delete a computer
        public int DeleteComputer(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteComputer", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@comId", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
