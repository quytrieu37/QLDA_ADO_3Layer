using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190145_NguyenQuyTrieu.DTO
{
    public class SVView
    {
        public string MSSV { get; set; }
        public string NameSV { get; set; }
        public bool Gender { get; set; }
        public DateTime NS { get; set; }
        public string NameLop { get; set; }
        public static bool ASCNameSV(object a, object b)
        {
            if (String.Compare(((SVView)a).NameSV, ((SVView)b).NameSV) > 0)
            {
                return true;
            }
            return false;
        }
        public static bool DESCTenSV(object a, object b)
        {
            if (String.Compare(((SVView)a).NameSV, ((SVView)b).NameSV) < 0)
            {
                return true;
            }
            return false;
        }
        public static bool DESCNS(object a, object b)
        {
            if (((SVView)a).NS < ((SVView)b).NS)
            {
                return true;
            }
            return false;
        }
        public static bool ASCNS(object a, object b)
        {
            if (((SVView)a).NS > ((SVView)b).NS)
            {
                return true;
            }
            return false;
        }
    }
}
