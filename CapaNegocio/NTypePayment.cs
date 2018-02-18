using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NTypePayment
    {
        public static string Insert(string name)
        {
            DTypePayment obj = new DTypePayment();
            obj.Name = name;
            return obj.Insert(obj);
        }

        public static string update(int id, string name)
        {
            DTypePayment obj = new DTypePayment();
            obj.Id = id;
            obj.Name = name;
            return obj.Update(obj);
        }

        public static string Delete(int id)
        {
            DTypePayment obj = new DTypePayment();
            obj.Id = id;
            return obj.Delete(obj);
        }


        public static DataTable Show()
        {
            return new DTypePayment().Show();
        }

        public static DataTable TextSearch(string textSearch)
        {
            DTypePayment obj = new DTypePayment();
            obj.TextSearch = textSearch;
            return obj.SearchName(obj);
        }


    }
}
