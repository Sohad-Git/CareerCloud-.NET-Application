using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyProfileRepository : IDataRepository<CompanyProfilePoco>
    {
        public void Add(params CompanyProfilePoco[] items)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand()
            {
                Connection = conn,
            };
            conn.Open();
            foreach (CompanyProfilePoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Company_Profiles]
                                           ([Id]
                                           ,[Registration_Date]
                                           ,[Company_Website]
                                           ,[Contact_Phone]
                                           ,[Contact_Name]
                                           ,[Company_Logo])
                                     VALUES
                                           (@Id
                                           ,@Registration_Date
                                           ,@Company_Website
                                           ,@Contact_Phone
                                           ,@Contact_Name
                                           ,@Company_Logo)";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Registration_Date", poco.RegistrationDate);
                cmd.Parameters.AddWithValue("@Company_Website", poco.CompanyWebsite);
                cmd.Parameters.AddWithValue("@Contact_Phone", poco.ContactPhone);
                cmd.Parameters.AddWithValue("@Contact_Name", poco.ContactName);
                cmd.Parameters.AddWithValue("@Company_Logo", poco.CompanyLogo);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT * FROM [dbo].[Company_Profiles]";
            cmd.Connection = conn;
            conn.Open();
            int x = 0;
            SqlDataReader rdr = cmd.ExecuteReader();
            CompanyProfilePoco[] pocos = new CompanyProfilePoco[1000];
            while (rdr.Read())
            {
                CompanyProfilePoco poco = new CompanyProfilePoco();
                poco.Id = rdr.GetGuid(0);
                poco.RegistrationDate = rdr.GetDateTime(1);
                poco.CompanyWebsite = rdr.IsDBNull(2) ? null : rdr.GetString(2);
                poco.ContactPhone = rdr.GetString(3);
                poco.ContactName = rdr.IsDBNull(4) ? null : rdr.GetString(4);
                poco.CompanyLogo = rdr.IsDBNull(5) ? null : (byte[])rdr[5];
                poco.TimeStamp = rdr.IsDBNull(6) ? null : (byte[])rdr[6];

                pocos[x] = poco;
                x++;
            };
            conn.Close();
            return pocos.Where(x => x != null).ToList();
        }

        public IList<CompanyProfilePoco> GetList(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyProfilePoco GetSingle(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyProfilePoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyProfilePoco[] items)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand()
            {
                Connection = conn,
            };
            conn.Open();
            foreach (CompanyProfilePoco poco in items)
            {
                cmd.CommandText = @"DELETE FROM [dbo].[Company_Profiles]
                                      WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Update(params CompanyProfilePoco[] items)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand()
            {
                Connection = conn,
            };
            conn.Open();
            foreach (CompanyProfilePoco poco in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Company_Profiles]
                                        SET [Id] = @Id
                                           ,[Registration_Date] = @Registration_Date
                                           ,[Company_Website] = @Company_Website
                                           ,[Contact_Phone] = @Contact_Phone
                                           ,[Contact_Name] = @Contact_Name
                                           ,[Company_Logo] = @Company_Logo
                                      WHERE [Id] = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Registration_Date", poco.RegistrationDate);
                cmd.Parameters.AddWithValue("@Company_Website", poco.CompanyWebsite);
                cmd.Parameters.AddWithValue("@Contact_Phone", poco.ContactPhone);
                cmd.Parameters.AddWithValue("@Contact_Name", poco.ContactName);
                cmd.Parameters.AddWithValue("@Company_Logo", poco.CompanyLogo);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
