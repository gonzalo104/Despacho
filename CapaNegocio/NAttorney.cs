using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NAttorney
    {
        public static string Insert(string name, string lastname, string rfc, string address, string cedula)
        {
            DAttorney obj = new DAttorney();
            obj.Name = name;
            obj.Lastname = lastname;
            obj.Rfc = rfc;
            obj.Address = address;
            obj.Cedula = cedula;
            return obj.Insert(obj);
        }

        public static string update(int id, string name, string lastname, string rfc, string address, string cedula)
        {
            DAttorney obj = new DAttorney();
            obj.Id = id;
            obj.Name = name;
            obj.Lastname = lastname;
            obj.Rfc = rfc;
            obj.Address = address;
            obj.Cedula = cedula;
            return obj.Update(obj);
        }

        public static string Delete(int id)
        {
            DAttorney obj = new DAttorney();
            obj.Id = id;
            return obj.Delete(obj);
        }

        public static DataTable Show()
        {
            return new DAttorney().Show();
        }

        public static DataTable TextSearch(string textSearch)
        {
            DAttorney obj = new DAttorney();
            obj.TextSearch = textSearch;
            return obj.SearchName(obj);
        }
    }
}
