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
    public class SystemLanguageCodeRepository : IDataRepository<SystemLanguageCodePoco>
    {
        public void Add(params SystemLanguageCodePoco[] items)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand()
            {
                Connection = conn,
            };
            conn.Open();
            foreach (SystemLanguageCodePoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[System_Language_Codes]
                                           ([LanguageID]
                                           ,[Name]
                                           ,[Native_Name])
                                     VALUES
                                           (@LanguageID
                                           ,@Name
                                           ,@Native_Name)";
                cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageID);
                cmd.Parameters.AddWithValue("@Name", poco.Name);
                cmd.Parameters.AddWithValue("@Native_Name", poco.NativeName);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SystemLanguageCodePoco> GetAll(params System.Linq.Expressions.Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT * FROM [dbo].[System_Language_Codes]";
            cmd.Connection = conn;
            conn.Open();
            int x = 0;
            SqlDataReader rdr = cmd.ExecuteReader();
            SystemLanguageCodePoco[] pocos = new SystemLanguageCodePoco[1000];
            while (rdr.Read())
            {
                SystemLanguageCodePoco poco = new SystemLanguageCodePoco();
                poco.LanguageID = rdr.GetString(0);
                poco.Name = rdr.GetString(1);
                poco.NativeName = rdr.GetString(2);

                pocos[x] = poco;
                x++;
            };
            conn.Close();
            return pocos.Where(x => x != null).ToList();
        }

        public IList<SystemLanguageCodePoco> GetList(System.Linq.Expressions.Expression<Func<SystemLanguageCodePoco, bool>> where, params System.Linq.Expressions.Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemLanguageCodePoco GetSingle(System.Linq.Expressions.Expression<Func<SystemLanguageCodePoco, bool>> where, params System.Linq.Expressions.Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemLanguageCodePoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SystemLanguageCodePoco[] items)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand()
            {
                Connection = conn,
            };
            conn.Open();
            foreach (SystemLanguageCodePoco poco in items)
            {
                cmd.CommandText = @"DELETE FROM [dbo].[System_Language_Codes]
                                     WHERE LanguageID = @LanguageID";
                cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageID);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Update(params SystemLanguageCodePoco[] items)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand()
            {
                Connection = conn,
            };
            conn.Open();
            foreach (SystemLanguageCodePoco poco in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[System_Language_Codes]
                                        SET [LanguageID] = @LanguageID
                                           ,[Name] = @Name
                                           ,[Native_Name] = @Native_Name
                                     WHERE [LanguageID] = @LanguageID";
                cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageID);
                cmd.Parameters.AddWithValue("@Name", poco.Name);
                cmd.Parameters.AddWithValue("@Native_Name", poco.NativeName);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
