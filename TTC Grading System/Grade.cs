using MySql.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace TTC_Grading_System
{
    class Grade
    {

        internal int ID { get; set; }
        internal int SubjectID { get; set; }
        internal int StudentID { get; set; }
        internal decimal Score { get; set; }
        internal string Remarks { get; set; }

        internal static List<Grade> getBySubjectAndBatch(int SubjectID, int BatchID)
        {
            List<Grade> grades = new List<Grade>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT grades.id, grades.subject_id, grades.student_id, grades.grade, grades.remarks FROM grades JOIN students ON grades.student_id = students.id WHERE grades.subject_id = @subject_id AND students.batch_id = @batch_id";
                    cmd.Parameters.AddWithValue("subject_id", SubjectID);
                    cmd.Parameters.AddWithValue("batch_id", BatchID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Grade grade = new Grade();
                            grade.ID = rdr.GetInt32(0);
                            grade.SubjectID = rdr.GetInt32(1);
                            grade.StudentID = rdr.GetInt32(2);
                            grade.Score = rdr.GetDecimal(3);
                            grade.Remarks = rdr.GetString(4);
                            grades.Add(grade);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return grades;
        }

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
                        cmd.CommandText = "UPDATE grades SET grade = @grade, remarks = @remarks WHERE subject_id = @subject_id AND student_id = @student_id";
                        cmd.Parameters.AddWithValue("subject_id", SubjectID);
                        cmd.Parameters.AddWithValue("student_id", StudentID);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO grades (subject_id, student_id, grade, remarks) VALUES (@subject_id, @student_id, @grade, @remarks)";
                        cmd.Parameters.AddWithValue("subject_id", SubjectID);
                        cmd.Parameters.AddWithValue("student_id", StudentID);
                    }
                    cmd.Parameters.AddWithValue("grade", Score);
                    cmd.Parameters.AddWithValue("remarks", Remarks);
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
