using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NStatusCaseFile
    {
        public static string Insert(string name)
        {
            DStatusCaseFile obj = new DStatusCaseFile();
            obj.Name = name;
            return obj.Insert(obj);
        }

        public static string update(int id, string name)
        {
            DStatusCaseFile obj = new DStatusCaseFile();
            obj.Id = id;
            obj.Name = name;
            return obj.Update(obj);
        }

        public static string Delete(int id)
        {
            DStatusCaseFile obj = new DStatusCaseFile();
            obj.Id = id;
            return obj.Delete(obj);
        }


        public static DataTable Show()
        {
            return new DStatusCaseFile().Show();
        }

        public static DataTable TextSearch(string textSearch)
        {
            DStatusCaseFile obj = new DStatusCaseFile();
            obj.TextSearch = textSearch;
            return obj.SearchName(obj);
        }
    }
}
