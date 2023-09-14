using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class RepositoryFactory
    {
        public static INewsRepository rep;
        public static INewsRepository CreateRepositoryNews()
        {
            if (rep == null)
            {
                int tip = Convert.ToInt32(ConfigurationManager.AppSettings["repoTip"]);
                if (tip == 0)
                {
                    lock(new object())
                    {
                        rep = new NewsRepository();
                    }
                }
                else
                {
                    lock (new object())
                    {
                        rep = new NewsRepositoryMock();
                    }
                }
            }
            return rep;
        }
    }
}
