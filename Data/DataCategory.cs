using Microsoft.Data.SqlClient;
using StarFood.Models;
using System;
using System.Collections.Generic;

namespace StarFood.Data
{
    public class DataCategory
    {
        private readonly string _connectionString;

        public DataCategory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Categoria> CategoryList()
        {
            List<Categoria> categoriaList = new List<Categoria>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    string sqlGetCategorias = "SELECT [IDCategoria], [Nombre] FROM [dbo].[Categoria]";
                    SqlCommand sqlCommand = new SqlCommand(sqlGetCategorias, sqlConnection);

                    sqlConnection.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categoriaList.Add(
                                new Categoria()
                                {
                                    IDCategoria = Convert.ToInt32(reader["IDCategoria"]),
                                    Nombre = reader["Nombre"].ToString()
                                });
                        }
                    }
                }
            }
            catch
            {
                categoriaList = new List<Categoria>();
            }
            return categoriaList;
        }

        public bool AddCategory(Categoria categoria)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    string sqlInsertCategoria = "INSERT INTO [dbo].[Categoria] ([Nombre]) VALUES (@Nombre)";
                    SqlCommand sqlCommand = new SqlCommand(sqlInsertCategoria, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Nombre", categoria.Nombre);

                    sqlConnection.Open();
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCategory(Categoria categoria)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    string sqlUpdateCategoria = "UPDATE [dbo].[Categoria] SET [Nombre] = @Nombre WHERE [IDCategoria] = @IDCategoria";
                    SqlCommand sqlCommand = new SqlCommand(sqlUpdateCategoria, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                    sqlCommand.Parameters.AddWithValue("@IDCategoria", categoria.IDCategoria);

                    sqlConnection.Open();
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCategory(int idCategoria)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    string sqlDeleteCategoria = "DELETE FROM [dbo].[Categoria] WHERE [IDCategoria] = @IDCategoria";
                    SqlCommand sqlCommand = new SqlCommand(sqlDeleteCategoria, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@IDCategoria", idCategoria);

                    sqlConnection.Open();
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}

