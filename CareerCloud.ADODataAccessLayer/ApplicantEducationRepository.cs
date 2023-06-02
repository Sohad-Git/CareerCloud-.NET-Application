using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository : IDataRepository<ApplicantEducationPoco>
    {
        public void Add(params ApplicantEducationPoco[] items)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand()
            {
                Connection = conn,
            };
            conn.Open();
            foreach (ApplicantEducationPoco poco in items) 
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Educations]
                                           ([Id]
                                           ,[Applicant]
                                           ,[Major]
                                           ,[Certificate_Diploma]
                                           ,[Start_Date]
                                           ,[Completion_Date]
                                           ,[Completion_Percent])
                                     VALUES
                                           (@Id
                                           ,@Applicant
                                           ,@Major
                                           ,@Certificate_Diploma
                                           ,@Start_Date
                                           ,@Completion_Date
                                           ,@Completion_Percent)";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                cmd.Parameters.AddWithValue("@Major", poco.Major);
                cmd.Parameters.AddWithValue("@Certificate_Diploma", poco.CertificateDiploma);
                cmd.Parameters.AddWithValue("@Start_Date", poco.StartDate);
                cmd.Parameters.AddWithValue("@Completion_Date", poco.CompletionDate);
                cmd.Parameters.AddWithValue("@Completion_Percent", poco.CompletionPercent);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT * FROM [dbo].[Applicant_Educations]";
            cmd.Connection = conn;
            conn.Open();
            int x = 0;
            SqlDataReader rdr = cmd.ExecuteReader();
            ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[1000];
            while (rdr.Read())
            {
                ApplicantEducationPoco poco = new ApplicantEducationPoco();
                poco.Id = rdr.GetGuid(0);
                poco.Applicant = rdr.GetGuid(1);
                poco.Major = rdr.GetString(2);
                poco.CertificateDiploma = rdr.IsDBNull(3) ? null : rdr.GetString(3);
                poco.StartDate = rdr.IsDBNull(4) ? null : rdr.GetDateTime(4);
                poco.CompletionDate = rdr.IsDBNull(5) ? null : rdr.GetDateTime(5);
                poco.CompletionPercent = rdr.IsDBNull(6) ? null : rdr.GetByte(6);
                poco.TimeStamp = (byte[])rdr[7];

                pocos[x] = poco;
                x++;
            };
            conn.Close();
            return pocos.Where(x => x != null).ToList();
        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantEducationPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand()
            {
                Connection = conn,
            };
            conn.Open();
            foreach (ApplicantEducationPoco poco in items)
            {
                cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Educations]
                                    WHERE  Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand()
            {
                Connection = conn,
            };
            conn.Open();
            foreach (ApplicantEducationPoco poco in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Applicant_Educations]
                                   SET [Id] = @Id
                                      ,[Applicant] = @Applicant
                                      ,[Major] = @Major
                                      ,[Certificate_Diploma] = @Certificate_Diploma
                                      ,[Start_Date] = @Start_Date
                                      ,[Completion_Date] = @Completion_Date
                                      ,[Completion_Percent] = @Completion_Percent
                                 WHERE [Id] = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                cmd.Parameters.AddWithValue("@Major", poco.Major);
                cmd.Parameters.AddWithValue("@Certificate_Diploma", poco.CertificateDiploma);
                cmd.Parameters.AddWithValue("@Start_Date", poco.StartDate);
                cmd.Parameters.AddWithValue("@Completion_Date", poco.CompletionDate);
                cmd.Parameters.AddWithValue("@Completion_Percent", poco.CompletionPercent);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
