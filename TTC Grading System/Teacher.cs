using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySql.Connection;


namespace TTC_Grading_System
{
    class Teacher
    {
        //PROPERTIES
        internal int ID { get; set; }
        internal string Number { get; set; }
        internal string Name { get; set; }

        internal static Teacher getByNumber(string Number)
        {
            Teacher teacher = new Teacher();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM teachers WHERE number = @number";
                    cmd.Parameters.AddWithValue("number", Number);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            teacher.ID = rdr.GetInt32(0);
                            teacher.Number = rdr.GetString(1);
                            teacher.Name = rdr.GetString(2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return teacher;
        }

        /// <summary>
        /// Gets all teachers
        /// </summary>
        /// <returns>Teacher List</returns>
        internal static List<Teacher> getAll()
        {
            List<Teacher> teachers = new List<Teacher>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM teachers";
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Teacher teacher = new Teacher();
                            teacher.ID = rdr.GetInt32(0);
                            teacher.Number = rdr.GetString(1);
                            teacher.Name = rdr.GetString(2);
                            teachers.Add(teacher);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return teachers;
        }

        /// <summary>
        /// Saves teacher to DB
        /// </summary>
        internal void Save()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    if (ID > 0)
                    {
                        cmd.CommandText = "UPDATE teachers SET number = @number, name = @name WHERE id = @id";
                        cmd.Parameters.AddWithValue("id", ID);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO teachers (number, name) VALUES (@number, @name)";
                    }
                    cmd.Parameters.AddWithValue("number", Number);
                    cmd.Parameters.AddWithValue("name", Name);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    if (ID == 0) ID = Convert.ToInt32(cmd.LastInsertedId);
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
        }
    }
}
