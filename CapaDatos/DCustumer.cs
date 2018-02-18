using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCustumer
    {
        private int _Id;
        private string _Name;
        private string _Lastname;
        private string _Phone;
        private string _Movil;
        private string _Email;
        private string _Comments;
        private int _TypeCustumerId;
        private string _TextSearch;

        public int Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Lastname { get => _Lastname; set => _Lastname = value; }
        public string Phone { get => _Phone; set => _Phone = value; }
        public string Movil { get => _Movil; set => _Movil = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Comments { get => _Comments; set => _Comments = value; }
        public int TypeCustumerId { get => _TypeCustumerId; set => _TypeCustumerId = value; }
        public string TextSearch { get => _TextSearch; set => _TextSearch = value; }


        public DCustumer()
        {

        }

        public DCustumer(int id, string name, string lastname, string phone, string movil, string email,
                        string comments,int typeCustumerId,string textSearch)
        {
            this.Id = id;
            this.Name = name;
            this.Lastname = lastname;
            this.Phone = phone;
            this.Movil = movil;
            this.Email = email;
            this.Comments = comments;
            this.TypeCustumerId = typeCustumerId;
            this.TextSearch = textSearch;
        }


        public string Insert(DCustumer custumer)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsert_custumer";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter PartIdCustumer = new SqlParameter();
                PartIdCustumer.ParameterName = "@id";
                PartIdCustumer.SqlDbType = SqlDbType.Int;
                PartIdCustumer.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(PartIdCustumer);

                SqlParameter ParName = new SqlParameter();
                ParName.ParameterName = "@name";
                ParName.SqlDbType = SqlDbType.VarChar;
                ParName.Size = 50;
                ParName.Value = custumer.Name;
                SqlCmd.Parameters.Add(ParName);

                SqlParameter ParLastname = new SqlParameter();
                ParLastname.ParameterName = "@lastname";
                ParLastname.SqlDbType = SqlDbType.VarChar;
                ParLastname.Size = 150;
                ParLastname.Value = custumer.Lastname;
                SqlCmd.Parameters.Add(ParLastname);

                SqlParameter ParPhone = new SqlParameter();
                ParPhone.ParameterName = "@phone";
                ParPhone.SqlDbType = SqlDbType.VarChar;
                ParPhone.Size = 12;
                ParPhone.Value = custumer.Phone;
                SqlCmd.Parameters.Add(ParPhone);

                SqlParameter ParMovil = new SqlParameter();
                ParMovil.ParameterName = "@movil";
                ParMovil.SqlDbType = SqlDbType.VarChar;
                ParMovil.Size = 12;
                ParMovil.Value = custumer.Movil;
                SqlCmd.Parameters.Add(ParMovil);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = custumer.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParComments = new SqlParameter();
                ParComments.ParameterName = "@comments";
                ParComments.SqlDbType = SqlDbType.VarChar;
                ParComments.Size = 250;
                ParComments.Value = custumer.Comments;
                SqlCmd.Parameters.Add(ParComments);

                SqlParameter ParTypeCustumer = new SqlParameter();
                ParTypeCustumer.ParameterName = "@type_custumer_id";
                ParTypeCustumer.SqlDbType = SqlDbType.Int;
                ParTypeCustumer.Value = custumer.TypeCustumerId;
                SqlCmd.Parameters.Add(ParTypeCustumer);

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


        public string Update(DCustumer custumer)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spupdate_custumer";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCustumer = new SqlParameter();
                ParIdCustumer.ParameterName = "@id";
                ParIdCustumer.SqlDbType = SqlDbType.Int;
                ParIdCustumer.Value = custumer.Id;
                SqlCmd.Parameters.Add(ParIdCustumer);

                SqlParameter ParName = new SqlParameter();
                ParName.ParameterName = "@name";
                ParName.SqlDbType = SqlDbType.VarChar;
                ParName.Size = 50;
                ParName.Value = custumer.Name;
                SqlCmd.Parameters.Add(ParName);

                SqlParameter ParLastname = new SqlParameter();
                ParLastname.ParameterName = "@lastname";
                ParLastname.SqlDbType = SqlDbType.VarChar;
                ParLastname.Size = 150;
                ParLastname.Value = custumer.Lastname;
                SqlCmd.Parameters.Add(ParLastname);

                SqlParameter ParPhone = new SqlParameter();
                ParPhone.ParameterName = "@phone";
                ParPhone.SqlDbType = SqlDbType.VarChar;
                ParPhone.Size = 12;
                ParPhone.Value = custumer.Phone;
                SqlCmd.Parameters.Add(ParPhone);

                SqlParameter ParMovil = new SqlParameter();
                ParMovil.ParameterName = "@movil";
                ParMovil.SqlDbType = SqlDbType.VarChar;
                ParMovil.Size = 12;
                ParMovil.Value = custumer.Movil;
                SqlCmd.Parameters.Add(ParMovil);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = custumer.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParComments = new SqlParameter();
                ParComments.ParameterName = "@comments";
                ParComments.SqlDbType = SqlDbType.VarChar;
                ParComments.Size = 250;
                ParComments.Value = custumer.Comments;
                SqlCmd.Parameters.Add(ParComments);

                SqlParameter ParTypeCustumer = new SqlParameter();
                ParTypeCustumer.ParameterName = "@type_custumer_id";
                ParTypeCustumer.SqlDbType = SqlDbType.Int;
                ParTypeCustumer.Value = custumer.TypeCustumerId;
                SqlCmd.Parameters.Add(ParTypeCustumer);

             

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



        public string Delete(DCustumer custumer)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdelete_custumer";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCustumer = new SqlParameter();
                ParIdCustumer.ParameterName = "@id";
                ParIdCustumer.SqlDbType = SqlDbType.Int;
                ParIdCustumer.Value = custumer.Id;
                SqlCmd.Parameters.Add(ParIdCustumer);

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
            DataTable DtResultado = new DataTable("custumer");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spshow_custumers";
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

        public DataTable SearchName(DCustumer custumer)
        {
            DataTable DtResultado = new DataTable("attorney");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spsearch_custumer";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextSearch = new SqlParameter();
                ParTextSearch.ParameterName = "@textsearch";
                ParTextSearch.SqlDbType = SqlDbType.VarChar;
                ParTextSearch.Size = 50;
                ParTextSearch.Value = custumer.TextSearch;
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
