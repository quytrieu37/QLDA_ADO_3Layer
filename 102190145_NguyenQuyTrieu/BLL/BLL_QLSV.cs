using _102190145_NguyenQuyTrieu.DAL;
using _102190145_NguyenQuyTrieu.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190145_NguyenQuyTrieu.BLL
{
    class BLL_QLSV
    {
        public delegate bool DelSort(object a, object b);
        private static BLL_QLSV _Instance;
        public static BLL_QLSV Instance
        {
            get
            {
                if(_Instance ==null)
                {
                    _Instance = new BLL_QLSV();
                }
                return _Instance;
            }
            private set { }
        }
        public List<LopSH> GetAllLSH_BLL()
        {
            return DAL_QLSV.Instance.GetAllLSH_DAL();
        }
        public bool IsTrue(string mssv)
        {
            List<SV> list = DAL_QLSV.Instance.GetAllSV_DAL();
            foreach(SV s in list)
            {
                if(s.MSSV == mssv)
                {
                    return true;
                }    
            }
            return false;
        }
        public void AddOrEditSV(SV sv)
        {
            if(!IsTrue(sv.MSSV))
            {
                DAL_QLSV.Instance.AddSV_DAL(sv);
            }
            else
            {
                DAL_QLSV.Instance.EditSV_DAL(sv);
            }
        }
        public SV GetSVByMSSV(string mssv)
        {
            List<SV> list = DAL_QLSV.Instance.GetAllSV_DAL();
            foreach(SV s in list)
            {
                if(s.MSSV == mssv)
                {
                    return s;
                }    
            }
            return null;
        }
        public List<SVView> GetAllSVView_BLL()
        {
            List<SVView> result = new List<SVView>();
            List<SV> list = DAL_QLSV.Instance.GetAllSV_DAL();
            List<LopSH> lshs = DAL_QLSV.Instance.GetAllLSH_DAL();
            string temp = "";
            foreach (SV sv in list)
            {
                foreach (LopSH l in lshs)
                {
                    if (l.ID_Lop == sv.ID_Lop)
                    {
                        temp = l.NameLop;
                    }
                }
                result.Add(new SVView()
                {
                    MSSV = sv.MSSV,
                    NameSV=sv.NameSV,
                    Gender= sv.Gender,
                    NS = sv.NS,
                    NameLop = temp
                });
            }
            return result;
        }
        public List<SVView> GetListSVView_BLL(int ID_Lop, string textSeach)
        {
            List<SVView> result = new List<SVView>();
            List<SVView> all = GetAllSVView_BLL();
            List<SV> list = DAL_QLSV.Instance.GetAllSV_DAL();
            List<LopSH> lshs = DAL_QLSV.Instance.GetAllLSH_DAL();
            string temp = "";
            if (ID_Lop != 0)
            {
                foreach (SV sv in list)
                {
                    if(sv.ID_Lop == ID_Lop)
                    {
                        foreach (LopSH l in lshs)
                        {
                            if (l.ID_Lop == sv.ID_Lop)
                            {
                                temp = l.NameLop;
                            }
                        }
                        result.Add(new SVView()
                        {
                            MSSV = sv.MSSV,
                            NameSV = sv.NameSV,
                            Gender = sv.Gender,
                            NS = sv.NS,
                            NameLop = temp
                        });
                    }    
                }
            }
            if (textSeach == "")
            {
                if (ID_Lop == 0)
                {
                    return all;
                }
                return result;
            }
            else
            {
                if (ID_Lop == 0)
                {
                    result.Clear();
                    foreach (SVView svv in all)
                    {
                        if (svv.NameSV.ToLower().Contains(textSeach))
                        {
                            result.Add(svv);
                        }
                    }
                    return result;
                }
                all.Clear();
                foreach (SVView svv in result)
                {
                    if (svv.NameSV.ToLower().Contains(textSeach))
                    {
                        all.Add(svv);
                    }
                }
                return all;
            }
        }
        public void DeleteSV(string mssv)
        {
            if(IsTrue(mssv))
            {
                DAL_QLSV.Instance.DeleteSV_DAL(mssv);
            }    
        }
        public void Sort(List<SVView> list, DelSort del)
        {
            SVView temp;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (del(list[i], list[j]))
                    {
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }
    }
}
