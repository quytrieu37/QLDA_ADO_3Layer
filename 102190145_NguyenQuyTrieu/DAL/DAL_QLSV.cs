using _102190145_NguyenQuyTrieu.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190145_NguyenQuyTrieu.DAL
{
    class DAL_QLSV
    {
        private static DAL_QLSV _Instance;
        public static DAL_QLSV Instance
        {
            get
            {
                if(_Instance ==null)
                {
                    _Instance = new DAL_QLSV();
                }
                return _Instance;
            }
            private set { }
        }
        public List<SV> GetAllSV_DAL()
        {
            List<SV> list = new List<SV>();
            string query = "Select * from SV";
            DataTable dt = DBHelper.Instance.GetRecord(query);
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(new SV()
                {
                    MSSV = dr["MSSV"].ToString(),
                    NameSV = dr["NameSV"].ToString(),
                    Gender = (bool)dr["Gender"],
                    NS = (DateTime)dr["NS"],
                    ID_Lop = (int)dr["ID_Lop"]
                });
            }
            return list;
        }
        public List<LSH> GetAllLSH_DAL()
        {
            string query = "Select * from LSH";
            List<LSH> list = new List<LSH>();
            DataTable dt = DBHelper.Instance.GetRecord(query);
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(new LSH()
                {
                    ID_Lop = (int)dr["ID_Lop"],
                    NameLop = dr["NameLop"].ToString()
                });
            }
            return list;
        }
        public void AddSV_DAL(SV s)
        {
            string query = $"Insert into SV Values ('{s.MSSV}','{s.NameSV}','{s.Gender}','{s.NS}','{s.ID_Lop}')";
            DBHelper.Instance.ExcuteDB(query);
        }
        public void EditSV_DAL(SV s)
        {
            string query = $"UPDATE SV SET NameSV = '{s.NameSV}', Gender= '{s.Gender}', NS = '{s.NS}', ID_Lop = '{s.ID_Lop}' WHERE MSSV = {s.MSSV}";
            DBHelper.Instance.ExcuteDB(query);
        }
        public void DeleteSV_DAL(string mssv)
        {
            string query = $"delete from SV where MSSV = {mssv}";
            DBHelper.Instance.ExcuteDB(query);
        }
    }
}
