using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    
    public class NewsRepositoryMock :  INewsRepository
    {
        static List<NewsT> listNews;
        public NewsRepositoryMock()
        {
            if (listNews == null || listNews.Count > 0)
            {
                listNews = new List<NewsT>();
                listNews.Add(new NewsT() { Id = 1, Title = "title", CatId = 1, Spot = "spot", Status = true, EditorId = 1 });
            }
        }

        public List<NewsT> List()
        {
            return listNews;
        }
        public void Add(NewsT entity)
        {
            entity.Id = listNews.Max(x => x.Id) + 1;
            listNews.Add(entity);
        }

        public void Update(NewsT entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int entityId)
        {
            throw new NotImplementedException();
        }

        public NewsT FindById(int EntityId)
        {
            throw new NotImplementedException();
        }
    }
}
