using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using MySql.Connection;
using System.IO;

namespace TTC_Grading_System
{
    class Student
    {
        internal Student()
        {
            ID = 0;
            BatchID = 0;
            Number = "";
            Tuition = 0;
            Status = "IN-SCHOOL";
        }

        //PROPERTIES
        internal int ID { get; set; }
        internal int BatchID { get; set; }
        internal string Number { get; set; }
        internal string LastName { get; set; }
        internal string FirstName { get; set; }
        internal string MiddleName { get; set; }
        internal string ExtName { get; set; }
        internal decimal Tuition { get; set; }
        internal string Status { get; set; }

        /// <summary>
        /// Get all students by Batch
        /// </summary>
        /// <param name="BatchID">Batch ID</param>
        /// <returns>Student List</returns>
        internal static List<Student> getByBatch(int BatchID)
        {
            List<Student> students = new List<Student>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT students.id, students.number, students.lastname, students.firstname, students.middlename, students.extname FROM students WHERE batch_id = @batch_id";
                    cmd.Parameters.AddWithValue("batch_id", BatchID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Student student = new Student();
                            student.ID = rdr.GetInt32(0);
                            student.Number = rdr.GetString(1);
                            student.LastName = rdr.GetString(2);
                            student.FirstName = rdr.GetString(3);
                            student.MiddleName = rdr.GetString(4);
                            student.ExtName = rdr.GetString(5);
                            students.Add(student);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return students;
        }

        /// <summary>
        /// Get Student by Number
        /// </summary>
        /// <param name="number">Student Number</param>
        /// <returns>Student</returns>
        internal static Student getStudentByNumber(string number)
        {
            Student student = new Student();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM students WHERE number = @number";
                    cmd.Parameters.AddWithValue("number", number);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            student.ID = rdr.GetInt32(0);
                            student.BatchID = rdr.GetInt32(1);
                            student.Number = rdr.GetString(2);
                            student.LastName = rdr.GetString(3);
                            student.FirstName = rdr.GetString(4);
                            student.MiddleName = rdr.GetString(5);
                            student.ExtName = rdr.GetString(6);
                            student.Tuition = rdr.GetDecimal(7);
                            student.Status = rdr.GetString(8);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return student;
        }

        internal static Student getByID(int ID)
        {
            Student student = new Student();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM students WHERE id = @id";
                    cmd.Parameters.AddWithValue("id", ID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            student.ID = rdr.GetInt32(0);
                            student.BatchID = rdr.GetInt32(1);
                            student.Number = rdr.GetString(2);
                            student.LastName = rdr.GetString(3);
                            student.FirstName = rdr.GetString(4);
                            student.MiddleName = rdr.GetString(5);
                            student.ExtName = rdr.GetString(6);
                            student.Tuition = rdr.GetDecimal(7);
                            student.Status = rdr.GetString(8);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return student;
        }

        /// <summary>
        /// Find students by Name //TODO
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        internal static List<Student> Find(string query, int ProgramID, int BatchID)
        {
            List<Student> students = new List<Student>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    if (ProgramID > 0 && BatchID > 0)
                    {
                        cmd.CommandText = "SELECT students.id, students.batch_id, students.number, students.lastname, students.firstname, students.middlename, students.extname, students.tuition, students.status FROM students JOIN batches ON students.batch_id=batches.id JOIN programs ON batches.program_id=programs.id WHERE CONCAT_WS(' ', students.number, students.firstname, students.middlename, students.lastname) LIKE '%" + query + "%' AND programs.id=@program_id AND batches.id=@batch_id";
                        cmd.Parameters.AddWithValue("program_id", ProgramID);
                        cmd.Parameters.AddWithValue("batch_id", BatchID);
                    }
                    else
                    {
                        cmd.CommandText = "SELECT * FROM students WHERE CONCAT_WS(' ', number, firstname, middlename, lastname) LIKE '%" + query + "%'";
                    }
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Student student = new Student();
                            student.ID = rdr.GetInt32(0);
                            student.BatchID = rdr.GetInt32(1);
                            student.Number = rdr.GetString(2);
                            student.LastName = rdr.GetString(3);
                            student.FirstName = rdr.GetString(4);
                            student.MiddleName = rdr.GetString(5);
                            student.ExtName = rdr.GetString(6);
                            student.Tuition = rdr.GetDecimal(7);
                            student.Status = rdr.GetString(8);
                            students.Add(student);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return students;
        }

        /// <summary>
        /// Gets the Next Sequence for Student Number
        /// </summary>
        /// <returns>Student Number</returns>
        internal static string GetNextNumber()
        {
            int number = 1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT number FROM students ORDER BY id DESC LIMIT 1";
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string last = rdr.GetString(0);
                            number = Convert.ToInt32(last.Split('-').Last()) + 1;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return number.ToString("D4");
        }

        internal string GetFullName()
        {
            string fullname = FirstName + " ";
            if (!string.IsNullOrWhiteSpace(MiddleName))
            {
                var mis = MiddleName.Split(' ');
                foreach (var mi in mis)
                {
                    fullname += mi.Substring(0, 1) + ". ";
                }
            }
            fullname += LastName;
            if (!string.IsNullOrWhiteSpace(ExtName)) fullname += " " + ExtName;
            return fullname;
        }

        /// <summary>
        /// Saves student to DB
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
                        cmd.CommandText = "UPDATE students SET batch_id = @batch_id, number = @number, lastname = @lastname, firstname = @firstname, middlename = @middlename, tuition = @tuition, status = @status WHERE id = @id";
                        cmd.Parameters.AddWithValue("id", ID);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO students (batch_id, number, lastname, firstname, middlename, tuition, status) VALUES (@batch_id, @number, @lastname, @firstname, @middlename, @tuition, @status)";
                    }
                    cmd.Parameters.AddWithValue("batch_id", BatchID);
                    cmd.Parameters.AddWithValue("number", Number);
                    cmd.Parameters.AddWithValue("lastname", LastName);
                    cmd.Parameters.AddWithValue("firstname", FirstName);
                    cmd.Parameters.AddWithValue("middlename", MiddleName);
                    cmd.Parameters.AddWithValue("tuition", Tuition);
                    cmd.Parameters.AddWithValue("status", Tuition);
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