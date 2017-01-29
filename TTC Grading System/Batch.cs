using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using MySql.Connection;

namespace TTC_Grading_System
{
    class Batch
    {
        //PROPERTIES
        internal int ID { get; set; }
        internal int ProgramID { get; set; }
        internal short Number { get; set; }
        internal short StudentCount
        {
            get { return (ID>0)?  CountStudent(): (short) 0; }
        }
        //

        internal static List<Batch> GetAllByProgram(int ProgramID)
        {
            List<Batch> batches = new List<Batch>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM batches WHERE program_id = @program_id";
                    cmd.Parameters.AddWithValue("program_id", ProgramID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Batch batch = new Batch();
                            batch.ID = rdr.GetInt32(0);
                            batch.ProgramID = rdr.GetInt32(1);
                            batch.Number = rdr.GetInt16(2);
                            batches.Add(batch);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return batches;
        }

        internal static Batch GetByID(int ID)
        {
            Batch batch = new Batch();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM batches WHERE id = @id";
                    cmd.Parameters.AddWithValue("id", ID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            batch.ID = rdr.GetInt32(0);
                            batch.ProgramID = rdr.GetInt32(1);
                            batch.Number = rdr.GetInt16(2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return batch;
        }

        internal static Batch New(int ProgramID)
        {
            int ID = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO batches (program_id, number) VALUES (@program_id, @number)";
                    cmd.Parameters.AddWithValue("program_id", ProgramID);
                    cmd.Parameters.AddWithValue("number", GetNextNumber(ProgramID));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    if (ID == 0) ID = Convert.ToInt32(cmd.LastInsertedId);
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return GetByID(ID);
        }

        internal static Batch GetByProgramAndNumber(int ProgramID, short Number)
        {
            Batch batch = new Batch();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM batches WHERE program_id = @program_id AND number = @number";
                    cmd.Parameters.AddWithValue("program_id", ProgramID);
                    cmd.Parameters.AddWithValue("number", Number);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            batch.ID = rdr.GetInt32(0);
                            batch.ProgramID = rdr.GetInt32(1);
                            batch.Number = rdr.GetInt16(2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return batch;
        }

        private static short GetNextNumber(int ProgramID)
        {
            int number = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT MAX(number) FROM batches WHERE program_id = @program_id";
                    cmd.Parameters.AddWithValue("program_id", ProgramID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            number = rdr.GetInt16(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return Convert.ToInt16(number + 1);
        }

        private short CountStudent()
        {
            short count = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT COUNT(id) FROM students WHERE batch_id = @batch_id";
                    cmd.Parameters.AddWithValue("batch_id", ID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            count = rdr.GetInt16(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return count;
        }
    }
}
