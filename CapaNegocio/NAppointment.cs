using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NAppointment
    {
        public static string Insert(string dateAppointment, int custumerId,string comments)
        {
            DAppointment obj = new DAppointment();
            obj.DateAppointment = dateAppointment;
            obj.CustumerId = custumerId;
            obj.Comments = comments;
            return obj.Insert(obj);
        }

        public static string update(int id, string dateAppointment, int custumerId, string comments)
        {
            DAppointment obj = new DAppointment();
            obj.Id = id;
            obj.DateAppointment = dateAppointment;
            obj.CustumerId = custumerId;
            obj.Comments = comments;

            return obj.Update(obj);
        }
        public static string Delete(int id)
        {
            DAppointment obj = new DAppointment();
            obj.Id = id;
            return obj.Delete(obj);
        }
        public static DataTable SearchDate(string dateSearch)
        {
            DAppointment obj = new DAppointment();
            obj.DateSearch = dateSearch;
            return obj.SearchDate(obj);
        }
    }
}
