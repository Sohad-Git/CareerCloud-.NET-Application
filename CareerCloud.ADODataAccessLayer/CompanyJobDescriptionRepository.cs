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
    public class CompanyJobDescriptionRepository : IDataRepository<CompanyJobDescriptionPoco>
    {
        public void Add(params CompanyJobDescriptionPoco[] items)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand()
            {
                Connection = conn,
            };
            conn.Open();
            foreach (CompanyJobDescriptionPoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Company_Jobs_Descriptions]
                                           ([Id]
                                           ,[Job]
                                           ,[Job_Name]
                                           ,[Job_Descriptions])
                                     VALUES
                                           (@Id
                                           ,@Job
                                           ,@Job_Name
                                           ,@Job_Descriptions)";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Job", poco.Job);
                cmd.Parameters.AddWithValue("@Job_Name", poco.JobName);
                cmd.Parameters.AddWithValue("@Job_Descriptions", poco.JobDescriptions);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobDescriptionPoco> GetAll(params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT * FROM [dbo].[Company_Jobs_Descriptions]";
            cmd.Connection = conn;
            conn.Open();
            int x = 0;
            SqlDataReader rdr = cmd.ExecuteReader();
            CompanyJobDescriptionPoco[] pocos = new CompanyJobDescriptionPoco[1500];
            while (rdr.Read())
            {
                CompanyJobDescriptionPoco poco = new CompanyJobDescriptionPoco();
                poco.Id = rdr.GetGuid(0);
                poco.Job = rdr.GetGuid(1);
                poco.JobName = rdr.IsDBNull(2) ? null : rdr.GetString(2);
                poco.JobDescriptions = rdr.IsDBNull(3) ? null : rdr.GetString(3);
                poco.TimeStamp = rdr.IsDBNull(4) ? null : (byte[])rdr[4];

                pocos[x] = poco;
                x++;
            };
            conn.Close();
            return pocos.Where(x => x != null).ToList();
        }

        public IList<CompanyJobDescriptionPoco> GetList(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobDescriptionPoco GetSingle(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobDescriptionPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobDescriptionPoco[] items)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand()
            {
                Connection = conn,
            };
            conn.Open();
            foreach (CompanyJobDescriptionPoco poco in items)
            {
                cmd.CommandText = @"DELETE [dbo].[Company_Jobs_Descriptions]
                                      WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Update(params CompanyJobDescriptionPoco[] items)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand()
            {
                Connection = conn,
            };
            conn.Open();
            foreach (CompanyJobDescriptionPoco poco in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Company_Jobs_Descriptions]
                                        SET [Id] = @Id
                                           ,[Job] = @Job
                                           ,[Job_Name] = @Job_Name
                                           ,[Job_Descriptions] = @Job_Descriptions
                                      WHERE [Id] = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Job", poco.Job);
                cmd.Parameters.AddWithValue("@Job_Name", poco.JobName);
                cmd.Parameters.AddWithValue("@Job_Descriptions", poco.JobDescriptions);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
