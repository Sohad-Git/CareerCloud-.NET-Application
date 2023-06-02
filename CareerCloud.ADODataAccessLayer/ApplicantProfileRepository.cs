using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantProfileRepository : IDataRepository<ApplicantProfilePoco>
    {
        public void Add(params ApplicantProfilePoco[] items)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand()
            {
                Connection = conn,
            };
            conn.Open();
            foreach (ApplicantProfilePoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Profiles]
                                           ([Id]
                                           ,[Login]
                                           ,[Current_Salary]
                                           ,[Current_Rate]
                                           ,[Currency]
                                           ,[Country_Code]
                                           ,[State_Province_Code]
                                           ,[Street_Address]
                                           ,[City_Town]
                                           ,[Zip_Postal_Code])
                                     VALUES
                                           (@Id
                                           ,@Login
                                           ,@Current_Salary
                                           ,@Current_Rate
                                           ,@Currency
                                           ,@Country_Code
                                           ,@State_Province_Code
                                           ,@Street_Address
                                           ,@City_Town
                                           ,@Zip_Postal_Code)";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Login", poco.Login);
                cmd.Parameters.AddWithValue("@Current_Salary", poco.CurrentSalary);
                cmd.Parameters.AddWithValue("@Current_Rate", poco.CurrentRate);
                cmd.Parameters.AddWithValue("@Currency", poco.Currency);
                cmd.Parameters.AddWithValue("@Country_Code", poco.Country);
                cmd.Parameters.AddWithValue("@State_Province_Code", poco.Province);
                cmd.Parameters.AddWithValue("@Street_Address", poco.Street);
                cmd.Parameters.AddWithValue("@City_Town", poco.City);
                cmd.Parameters.AddWithValue("@Zip_Postal_Code", poco.PostalCode);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantProfilePoco> GetAll(params System.Linq.Expressions.Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT * FROM [dbo].[Applicant_Profiles]";
            cmd.Connection = conn;
            conn.Open();
            int x = 0;
            SqlDataReader rdr = cmd.ExecuteReader();
            ApplicantProfilePoco[] pocos = new ApplicantProfilePoco[1000];
            while (rdr.Read())
            {
                ApplicantProfilePoco poco = new ApplicantProfilePoco();
                poco.Id = rdr.GetGuid(0);
                poco.Login = rdr.GetGuid(1);
                poco.CurrentSalary = rdr.IsDBNull(2) ? null : rdr.GetDecimal(2);
                poco.CurrentRate = rdr.IsDBNull(3) ? null : rdr.GetDecimal(3);
                poco.Currency = rdr.IsDBNull(4) ? null : rdr.GetString(4);
                poco.Country = rdr.IsDBNull(5) ? null : rdr.GetString(5);
                poco.Province = rdr.IsDBNull(6) ? null : rdr.GetString(6);
                poco.Street = rdr.IsDBNull(7) ? null : rdr.GetString(7);
                poco.City = rdr.IsDBNull(8) ? null : rdr.GetString(8);
                poco.PostalCode = rdr.IsDBNull(9) ? null : rdr.GetString(9);
                poco.TimeStamp = (byte[])rdr[10];

                pocos[x] = poco;
                x++;
            };
            conn.Close();
            return pocos.Where(x => x != null).ToList();
        }

        public IList<ApplicantProfilePoco> GetList(System.Linq.Expressions.Expression<Func<ApplicantProfilePoco, bool>> where, params System.Linq.Expressions.Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantProfilePoco GetSingle(System.Linq.Expressions.Expression<Func<ApplicantProfilePoco, bool>> where, params System.Linq.Expressions.Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantProfilePoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantProfilePoco[] items)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand()
            {
                Connection = conn,
            };
            conn.Open();
            foreach (ApplicantProfilePoco poco in items)
            {
                cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Profiles]
                                     WHERE  Id = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Update(params ApplicantProfilePoco[] items)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand()
            {
                Connection = conn,
            };
            conn.Open();
            foreach (ApplicantProfilePoco poco in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Applicant_Profiles]
                                        SET [Id] = @Id
                                           ,[Login] = @Login
                                           ,[Current_Salary] = @Current_Salary
                                           ,[Current_Rate] = @Current_Rate
                                           ,[Currency] = @Currency
                                           ,[Country_Code] = @Country_Code
                                           ,[State_Province_Code] = @State_Province_Code
                                           ,[Street_Address] = @Street_Address
                                           ,[City_Town] = @City_Town
                                           ,[Zip_Postal_Code] = @Zip_Postal_Code
                                     WHERE [Id] = @Id";
                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Login", poco.Login);
                cmd.Parameters.AddWithValue("@Current_Salary", poco.CurrentSalary);
                cmd.Parameters.AddWithValue("@Current_Rate", poco.CurrentRate);
                cmd.Parameters.AddWithValue("@Currency", poco.Currency);
                cmd.Parameters.AddWithValue("@Country_Code", poco.Country);
                cmd.Parameters.AddWithValue("@State_Province_Code", poco.Province);
                cmd.Parameters.AddWithValue("@Street_Address", poco.Street);
                cmd.Parameters.AddWithValue("@City_Town", poco.City);
                cmd.Parameters.AddWithValue("@Zip_Postal_Code", poco.PostalCode);
                cmd.ExecuteNonQuery();
            }
            conn.Close();

        }

    }
}
