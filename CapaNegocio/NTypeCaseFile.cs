using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;


namespace CapaNegocio
{
    public class NTypeCaseFile
    {
        public static string Insert(string name)
        {
            DTypeCaseFile obj = new DTypeCaseFile();
            obj.Name = name;
            return obj.Insert(obj);
        }

        public static string update(int id, string name)
        {
            DTypeCaseFile obj = new DTypeCaseFile();
            obj.Id = id;
            obj.Name = name;
            return obj.Update(obj);
        }

        public static string Delete(int id)
        {
            DTypeCaseFile obj = new DTypeCaseFile();
            obj.Id = id;
            return obj.Delete(obj);
        }


        public static DataTable Show()
        {
            return new DTypeCaseFile().Show();
        }

        public static DataTable TextSearch(string textSearch)
        {
            DTypeCaseFile obj = new DTypeCaseFile();
            obj.TextSearch = textSearch;
            return obj.SearchName(obj);
        }

    }
}
