using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DAttorney
    {
        private int _Id;
        private string _Name;
        private string _Lastname;
        private string _Rfc;
        private string _Address;
        private string _Cedula;
        private string _TextSearch;

        public int Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Lastname { get => _Lastname; set => _Lastname = value; }
        public string Rfc { get => _Rfc; set => _Rfc = value; }
        public string Address { get => _Address; set => _Address = value; }
        public string Cedula { get => _Cedula; set => _Cedula = value; }
        public string TextSearch { get => _TextSearch; set => _TextSearch = value; }


        public DAttorney()
        {

        }

        public DAttorney(int id, string name,string lastname, string rfc,string address,string cedula, string textSearch)
        {
            this.Id = id;
            this.Name = name;
            this.Lastname = lastname;
            this.Rfc = rfc;
            this.Address = address;
            this.Cedula = cedula;
            this.TextSearch = textSearch;

        }

        public string Insert(DAttorney attorney)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsert_attorney";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdAttorney = new SqlParameter();
                ParIdAttorney.ParameterName = "@id";
                ParIdAttorney.SqlDbType = SqlDbType.Int;
                ParIdAttorney.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdAttorney);

                SqlParameter ParName = new SqlParameter();
                ParName.ParameterName = "@name";
                ParName.SqlDbType = SqlDbType.VarChar;
                ParName.Size = 50;
                ParName.Value = attorney.Name;
                SqlCmd.Parameters.Add(ParName);

                SqlParameter ParLastname = new SqlParameter();
                ParLastname.ParameterName = "@lastname";
                ParLastname.SqlDbType = SqlDbType.VarChar;
                ParLastname.Size = 100;
                ParLastname.Value = attorney.Lastname;
                SqlCmd.Parameters.Add(ParLastname);

                SqlParameter ParRfc = new SqlParameter();
                ParRfc.ParameterName = "@rfc";
                ParRfc.SqlDbType = SqlDbType.VarChar;
                ParRfc.Size = 15;
                ParRfc.Value = attorney.Rfc;
                SqlCmd.Parameters.Add(ParRfc);

                SqlParameter ParAddress = new SqlParameter();
                ParAddress.ParameterName = "@address";
                ParAddress.SqlDbType = SqlDbType.VarChar;
                ParAddress.Size = 250;
                ParAddress.Value = attorney.Address;
                SqlCmd.Parameters.Add(ParAddress);

                SqlParameter ParCedula = new SqlParameter();
                ParCedula.ParameterName = "@cedula";
                ParCedula.SqlDbType = SqlDbType.VarChar;
                ParCedula.Size = 20;
                ParCedula.Value = attorney.Cedula;
                SqlCmd.Parameters.Add(ParCedula);

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


        public string Update(DAttorney attorney)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spupdate_attorney";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdAttorney = new SqlParameter();
                ParIdAttorney.ParameterName = "@id";
                ParIdAttorney.SqlDbType = SqlDbType.Int;
                ParIdAttorney.Value = attorney.Id;
                SqlCmd.Parameters.Add(ParIdAttorney);

                SqlParameter ParName = new SqlParameter();
                ParName.ParameterName = "@name";
                ParName.SqlDbType = SqlDbType.VarChar;
                ParName.Size = 50;
                ParName.Value = attorney.Name;
                SqlCmd.Parameters.Add(ParName);

                SqlParameter ParLastname = new SqlParameter();
                ParLastname.ParameterName = "@lastname";
                ParLastname.SqlDbType = SqlDbType.VarChar;
                ParLastname.Size = 100;
                ParLastname.Value = attorney.Lastname;
                SqlCmd.Parameters.Add(ParLastname);

                SqlParameter ParRfc = new SqlParameter();
                ParRfc.ParameterName = "@rfc";
                ParRfc.SqlDbType = SqlDbType.VarChar;
                ParRfc.Size = 15;
                ParRfc.Value = attorney.Rfc;
                SqlCmd.Parameters.Add(ParRfc);

                SqlParameter ParAddress = new SqlParameter();
                ParAddress.ParameterName = "@address";
                ParAddress.SqlDbType = SqlDbType.VarChar;
                ParAddress.Size = 250;
                ParAddress.Value = attorney.Address;
                SqlCmd.Parameters.Add(ParAddress);

                SqlParameter ParCedula = new SqlParameter();
                ParCedula.ParameterName = "@cedula";
                ParCedula.SqlDbType = SqlDbType.VarChar;
                ParCedula.Size = 20;
                ParCedula.Value = attorney.Cedula;
                SqlCmd.Parameters.Add(ParCedula);

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


        public string Delete(DAttorney attorney)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdelete_attorney";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTypeCustumer = new SqlParameter();
                ParIdTypeCustumer.ParameterName = "@id";
                ParIdTypeCustumer.SqlDbType = SqlDbType.Int;
                ParIdTypeCustumer.Value = attorney.Id;
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
            DataTable DtResultado = new DataTable("attorney");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spshow_attorney";
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

        public DataTable SearchName(DAttorney attorney)
        {
            DataTable DtResultado = new DataTable("attorney");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spsearch_attorney";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextSearch = new SqlParameter();
                ParTextSearch.ParameterName = "@textsearch";
                ParTextSearch.SqlDbType = SqlDbType.VarChar;
                ParTextSearch.Size = 50;
                ParTextSearch.Value = attorney.TextSearch;
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
