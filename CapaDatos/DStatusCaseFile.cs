using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DStatusCaseFile
    {
        private int _Id;
        private string _Name;
        private string _TextSearch;
        public int Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string TextSearch { get => _TextSearch; set => _TextSearch = value; }


        public DStatusCaseFile()
        {

        }

        public DStatusCaseFile(int id, string name, string textSearch)
        {
            this.Id = id;
            this.Name = name;
            this.TextSearch = textSearch;

        }


        public string Insert(DStatusCaseFile statusCaseFile)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsert_status_case_file";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParStatusCaseFile = new SqlParameter();
                ParStatusCaseFile.ParameterName = "@id";
                ParStatusCaseFile.SqlDbType = SqlDbType.Int;
                ParStatusCaseFile.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParStatusCaseFile);

                SqlParameter ParName = new SqlParameter();
                ParName.ParameterName = "@name";
                ParName.SqlDbType = SqlDbType.VarChar;
                ParName.Size = 50;
                ParName.Value = statusCaseFile.Name;
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

        public string Update(DStatusCaseFile statusCaseFile)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spupdate_status_case_file";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdStatusCaseFile = new SqlParameter();
                ParIdStatusCaseFile.ParameterName = "@id";
                ParIdStatusCaseFile.SqlDbType = SqlDbType.Int;
                ParIdStatusCaseFile.Value = statusCaseFile.Id;
                SqlCmd.Parameters.Add(ParIdStatusCaseFile);

                SqlParameter ParName = new SqlParameter();
                ParName.ParameterName = "@name";
                ParName.SqlDbType = SqlDbType.VarChar;
                ParName.Size = 50;
                ParName.Value = statusCaseFile.Name;
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


        public string Delete(DStatusCaseFile statusCaseFile)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdelete_status_case_file";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdStatusCaseFile = new SqlParameter();
                ParIdStatusCaseFile.ParameterName = "@id";
                ParIdStatusCaseFile.SqlDbType = SqlDbType.Int;
                ParIdStatusCaseFile.Value = statusCaseFile.Id;
                SqlCmd.Parameters.Add(ParIdStatusCaseFile);

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
            DataTable DtResultado = new DataTable("statusCaseFile");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spshow_status_case_file";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }


        public DataTable SearchName(DStatusCaseFile statusCaseFile)
        {
            DataTable DtResultado = new DataTable("typecustumer");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spsearch_status_case_file";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextSearch = new SqlParameter();
                ParTextSearch.ParameterName = "@textsearch";
                ParTextSearch.SqlDbType = SqlDbType.VarChar;
                ParTextSearch.Size = 50;
                ParTextSearch.Value = statusCaseFile.TextSearch;
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
