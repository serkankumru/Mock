using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NewsRepository:BaseRepository<NewsT>, INewsRepository
    {
        public int NewsStatus(int id)
        {
            var ctx = new NewsEntities();
            NewsT news = ctx.NewsT.FirstOrDefault(x => x.Id == id);
            news.Status = !news.Status;
            ctx.SaveChanges();
            if(Convert.ToBoolean(news.Status))
                return 1;
            return 0;
        }

        public override void Update(NewsT entity)
        {
            var ctx = new NewsEntities();
            NewsT news = ctx.NewsT.FirstOrDefault(x => x.Id == entity.Id);

            news.Title = entity.Title;
            news.Spot = entity.Spot;
            news.CatId = entity.CatId;
            news.Content = entity.Content;
            news.ImagesId = entity.ImagesId;

            ctx.SaveChanges();

            //base.Update(entity);
        }


        public void ReadCount(int id)
        {
            var ctx = new NewsEntities();
            NewsT news = ctx.NewsT.FirstOrDefault(x => x.Id == id);
            if (news.ReadCount == null)
                news.ReadCount = 1;
            else
                news.ReadCount++;

            ctx.SaveChanges();
        }
    }
}
