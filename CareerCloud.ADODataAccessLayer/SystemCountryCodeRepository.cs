﻿using CareerCloud.DataAccessLayer;
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
    public class SystemCountryCodeRepository : IDataRepository<SystemCountryCodePoco>
    {
        public void Add(params SystemCountryCodePoco[] items)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand()
            {
                Connection = conn,
            };
            conn.Open();
            foreach (SystemCountryCodePoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[System_Country_Codes]
                                           ([Code]
                                           ,[Name])
                                     VALUES
                                           (@Code
                                           ,@Name)";
                cmd.Parameters.AddWithValue("@Code", poco.Code);
                cmd.Parameters.AddWithValue("@Name", poco.Name);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SystemCountryCodePoco> GetAll(params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT * FROM [dbo].[System_Country_Codes]";
            cmd.Connection = conn;
            conn.Open();
            int x = 0;
            SqlDataReader rdr = cmd.ExecuteReader();
            SystemCountryCodePoco[] pocos = new SystemCountryCodePoco[1000];
            while (rdr.Read())
            {
                SystemCountryCodePoco poco = new SystemCountryCodePoco();
                poco.Code = rdr.GetString(0);
                poco.Name = rdr.GetString(1);

                pocos[x] = poco;
                x++;
            };
            conn.Close();
            return pocos.Where(x => x != null).ToList();
        }

        public IList<SystemCountryCodePoco> GetList(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemCountryCodePoco GetSingle(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemCountryCodePoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SystemCountryCodePoco[] items)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand()
            {
                Connection = conn,
            };
            conn.Open();
            foreach (SystemCountryCodePoco poco in items)
            {
                cmd.CommandText = @"DELETE FROM [dbo].[System_Country_Codes]
                                      WHERE Code = @Code";
                cmd.Parameters.AddWithValue("@Code", poco.Code);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Update(params SystemCountryCodePoco[] items)
        {
            SqlConnection conn = new SqlConnection(Constants.connectionString);
            SqlCommand cmd = new SqlCommand()
            {
                Connection = conn,
            };
            conn.Open();
            foreach (SystemCountryCodePoco poco in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[System_Country_Codes]
                                        SET [Code] = @Code
                                           ,[Name] = @Name
                                      WHERE [Code] = @Code";
                cmd.Parameters.AddWithValue("@Code", poco.Code);
                cmd.Parameters.AddWithValue("@Name", poco.Name);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
