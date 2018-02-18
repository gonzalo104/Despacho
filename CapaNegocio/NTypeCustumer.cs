using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NTypeCustumer
    {

        public static string Insert(string name)
        {
            DtypeCustumer obj = new DtypeCustumer();
            obj.Name = name;
            return obj.Insert(obj);
        }

        public static string update(int id, string name)
        {
            DtypeCustumer obj = new DtypeCustumer();
            obj.Id = id;
            obj.Name = name;
            return obj.Update(obj);
        }

        public static string Delete(int id)
        {
            DtypeCustumer obj = new DtypeCustumer();
            obj.Id = id;
            return obj.Delete(obj);
        }


        public static DataTable Show()
        {
            return new DtypeCustumer().Show();
        }

        public static DataTable TextSearch(string textSearch)
        {
            DtypeCustumer obj = new DtypeCustumer();
            obj.TextSearch = textSearch;
            return obj.SearchName(obj);
        }


    }
}
