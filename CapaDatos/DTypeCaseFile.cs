using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
   public class DTypeCaseFile
    {
        private int _Id;
        private string _Name;
        private string _TextSearch;

        public int Id { get => _Id; set => _Id = value; }

        public void Insert()
        {
            throw new NotImplementedException();
        }

        public string Name { get => _Name; set => _Name = value; }
        public string TextSearch { get => _TextSearch; set => _TextSearch = value; }

        public DTypeCaseFile()
        {

        }

        public DTypeCaseFile(int id, string name, string textSearch)
        {
            this.Id = id;
            this.Name = name;
            this.TextSearch = textSearch;
        }

        public string Insert(DTypeCaseFile typeCaseFile)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsert_type_case_file";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTypeCaseFile = new SqlParameter();
                ParIdTypeCaseFile.ParameterName = "@id";
                ParIdTypeCaseFile.SqlDbType = SqlDbType.Int;
                ParIdTypeCaseFile.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdTypeCaseFile);

                SqlParameter ParName = new SqlParameter();
                ParName.ParameterName = "@name";
                ParName.SqlDbType = SqlDbType.VarChar;
                ParName.Size = 50;
                ParName.Value = typeCaseFile.Name;
                SqlCmd.Parameters.Add(ParName);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Ingreso el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }

        public string Update(DTypeCaseFile typeCaseFile)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spupdate_type_case_file";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTypeCaseFile = new SqlParameter();
                ParIdTypeCaseFile.ParameterName = "@id";
                ParIdTypeCaseFile.SqlDbType = SqlDbType.Int;
                ParIdTypeCaseFile.Value = typeCaseFile.Id;
                SqlCmd.Parameters.Add(ParIdTypeCaseFile);

                SqlParameter ParName = new SqlParameter();
                ParName.ParameterName = "@name";
                ParName.SqlDbType = SqlDbType.VarChar;
                ParName.Size = 50;
                ParName.Value = typeCaseFile.Name;
                SqlCmd.Parameters.Add(ParName);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        public string Delete(DTypeCaseFile typeCaseFile)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdelete_type_case_file";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTypeCaseFile = new SqlParameter();
                ParIdTypeCaseFile.ParameterName = "@id";
                ParIdTypeCaseFile.SqlDbType = SqlDbType.Int;
                ParIdTypeCaseFile.Value = typeCaseFile.Id;
                SqlCmd.Parameters.Add(ParIdTypeCaseFile);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Elimino el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }

        public DataTable Show()
        {
            DataTable DtResultado = new DataTable("typecasefile");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spshow_type_case_file";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch(Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public DataTable SearchName(DTypeCaseFile typeCaseFile)
        {
            DataTable DtResultado = new DataTable("typecasefile");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spsearch_type_case_file";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextSearch = new SqlParameter();
                ParTextSearch.ParameterName = "@textsearch";
                ParTextSearch.SqlDbType = SqlDbType.VarChar;
                ParTextSearch.Size = 50;
                ParTextSearch.Value = typeCaseFile.TextSearch;
                SqlCmd.Parameters.Add(ParTextSearch);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }


    }
}
