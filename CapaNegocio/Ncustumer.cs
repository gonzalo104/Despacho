using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class Ncustumer
    {
        public static string Insert(string name, string lastname,string phone, string movil, string email,
                                    string comments, int typeCustumerId)
        {
            DCustumer obj = new DCustumer();
            obj.Name = name;
            obj.Lastname = lastname;
            obj.Phone = phone;
            obj.Movil = movil;
            obj.Email = email;
            obj.Comments = comments;
            obj.TypeCustumerId = typeCustumerId;
            return obj.Insert(obj);
        }

        public static string update(int id,string name, string lastname, string phone, string movil, string email,
                                    string comments, int typeCustumerId)
        {
            DCustumer obj = new DCustumer();
            obj.Id = id;
            obj.Name = name;
            obj.Lastname = lastname;
            obj.Phone = phone;
            obj.Movil = movil;
            obj.Email = email;
            obj.Comments = comments;
            obj.TypeCustumerId = typeCustumerId;
            return obj.Update(obj);
        }

        public static string Delete(int id)
        {
            DCustumer obj = new DCustumer();
            obj.Id = id;
            return obj.Delete(obj);
        }

        public static DataTable Show()
        {
            return new DCustumer().Show();
        }

        public static DataTable TextSearch(string textSearch)
        {
            DCustumer obj = new DCustumer();
            obj.TextSearch = textSearch;
            return obj.SearchName(obj);
        }
    }
}
