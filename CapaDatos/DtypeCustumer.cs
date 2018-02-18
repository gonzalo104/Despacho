using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DtypeCustumer
    {
        private int _Id;
        private string _Name;
        private string _TextSearch;
        public int Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string TextSearch { get => _TextSearch; set => _TextSearch = value; }

        public DtypeCustumer()
        {

        }

        public DtypeCustumer(int id, string name, string textSearch)
        {
            this.Id = id;
            this.Name = name;
            this.TextSearch = textSearch;

        }


        public string Insert(DtypeCustumer typeCustumer)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsert_type_custumer";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTypeCustumer = new SqlParameter();
                ParIdTypeCustumer.ParameterName = "@id";
                ParIdTypeCustumer.SqlDbType = SqlDbType.Int;
                ParIdTypeCustumer.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdTypeCustumer);

                SqlParameter ParName = new SqlParameter();
                ParName.ParameterName = "@name";
                ParName.SqlDbType = SqlDbType.VarChar;
                ParName.Size = 50;
                ParName.Value = typeCustumer.Name;
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

        public string Update(DtypeCustumer typeCustumer)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spupdate_type_custumer";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTypeCustumer = new SqlParameter();
                ParIdTypeCustumer.ParameterName = "@id";
                ParIdTypeCustumer.SqlDbType = SqlDbType.Int;
                ParIdTypeCustumer.Value = typeCustumer.Id;
                SqlCmd.Parameters.Add(ParIdTypeCustumer);

                SqlParameter ParName = new SqlParameter();
                ParName.ParameterName = "@name";
                ParName.SqlDbType = SqlDbType.VarChar;
                ParName.Size = 50;
                ParName.Value = typeCustumer.Name;
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


        public string Delete(DtypeCustumer typeCustumer)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdelete_type_custumer";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTypeCustumer = new SqlParameter();
                ParIdTypeCustumer.ParameterName = "@id";
                ParIdTypeCustumer.SqlDbType = SqlDbType.Int;
                ParIdTypeCustumer.Value = typeCustumer.Id;
                SqlCmd.Parameters.Add(ParIdTypeCustumer);

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
            DataTable DtResultado = new DataTable("typecustumer");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spshow_type_custumer";
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


        public DataTable SearchName(DtypeCustumer typeCustumer)
        {
            DataTable DtResultado = new DataTable("typecustumer");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spsearch_type_custumer";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextSearch = new SqlParameter();
                ParTextSearch.ParameterName = "@textsearch";
                ParTextSearch.SqlDbType = SqlDbType.VarChar;
                ParTextSearch.Size = 50;
                ParTextSearch.Value = typeCustumer.TextSearch;
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
