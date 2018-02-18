using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DAppointment
    {
        private int _Id;
        private string _DateAppointment;
        private int _CustumerId;
        private string _Comments;
        public int Id { get => _Id; set => _Id = value; }
        public string DateAppointment { get => _DateAppointment; set => _DateAppointment = value; }
        public int CustumerId { get => _CustumerId; set => _CustumerId = value; }
        public string Comments { get => _Comments; set => _Comments = value; }
        public string DateSearch { get => dateSearch; set => dateSearch = value; }

        private string dateSearch;

        public DAppointment()
        {

        }

        public DAppointment(int id, string dateAppointment, int custumerId, string comments, string dateSearch)
        {
            this.Id = id;
            this.DateAppointment = dateAppointment;
            this.CustumerId = custumerId;
            this.Comments = comments;
            this.dateSearch = dateSearch;
        }

        public string Insert(DAppointment appointment)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spInsert_appointment";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdAppointment = new SqlParameter();
                ParIdAppointment.ParameterName = "@id";
                ParIdAppointment.SqlDbType = SqlDbType.Int;
                ParIdAppointment.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdAppointment);

                SqlParameter ParDate = new SqlParameter();
                ParDate.ParameterName = "@date_appountment";
                ParDate.SqlDbType = SqlDbType.Date;
                ParDate.Value = appointment.DateAppointment;
                SqlCmd.Parameters.Add(ParDate);

                SqlParameter ParCustumerId = new SqlParameter();
                ParCustumerId.ParameterName = "@custumer_id";
                ParCustumerId.SqlDbType = SqlDbType.Int;
                ParCustumerId.Value = appointment.CustumerId;
                SqlCmd.Parameters.Add(ParCustumerId);

                SqlParameter ParComments = new SqlParameter();
                ParComments.ParameterName = "@comments";
                ParComments.SqlDbType = SqlDbType.VarChar;
                ParComments.Size = 250;
                ParComments.Value = appointment.Comments;
                SqlCmd.Parameters.Add(ParComments);

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

        public string Update(DAppointment appointment)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spupdate_appointment";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdAppointment = new SqlParameter();
                ParIdAppointment.ParameterName = "@id";
                ParIdAppointment.SqlDbType = SqlDbType.Int;
                ParIdAppointment.Value = appointment.Id;
                SqlCmd.Parameters.Add(ParIdAppointment);

                SqlParameter ParDate = new SqlParameter();
                ParDate.ParameterName = "@date_appountment";
                ParDate.SqlDbType = SqlDbType.Date;
                ParDate.Value = appointment.DateAppointment;
                SqlCmd.Parameters.Add(ParDate);

                SqlParameter ParCustumerId = new SqlParameter();
                ParCustumerId.ParameterName = "@custumer_id";
                ParCustumerId.SqlDbType = SqlDbType.Int;
                ParCustumerId.Value = appointment.CustumerId;
                SqlCmd.Parameters.Add(ParCustumerId);

                SqlParameter ParComments = new SqlParameter();
                ParComments.ParameterName = "@comments";
                ParComments.SqlDbType = SqlDbType.VarChar;
                ParComments.Size = 250;
                ParComments.Value = appointment.Comments;
                SqlCmd.Parameters.Add(ParComments);

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


        public string Delete(DAppointment appointment)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdelete_appointment";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCustumerId = new SqlParameter();
                ParCustumerId.ParameterName = "@id";
                ParCustumerId.SqlDbType = SqlDbType.Int;
                ParCustumerId.Value = appointment.Id;
                SqlCmd.Parameters.Add(ParCustumerId);

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

        public DataTable SearchDate(DAppointment appointment)
        {
            DataTable DtResultado = new DataTable("attorney");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spsearch_appointments_date";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDateSearch = new SqlParameter();
                ParDateSearch.ParameterName = "@date";
                ParDateSearch.SqlDbType = SqlDbType.Date;
                ParDateSearch.Value = appointment.dateSearch;
                SqlCmd.Parameters.Add(ParDateSearch);

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
