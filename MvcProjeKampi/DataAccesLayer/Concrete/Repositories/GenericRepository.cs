using DataAccesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class //T değeri bir class olmalı
    {
        Context c = new Context();
        DbSet<T> _object; //object t değerine karşılık gelen sınıfı tutuyor
        public GenericRepository() //constructor method
        {
            _object = c.Set<T>();// contexe bağlı olarak gönderilen t değerini _objectin içine atıyoruz
        }
        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);//sileceğimiz değeri deletedEntity içine atadık
            deletedEntity.State = EntityState.Deleted;
           // _object.Remove(p);//silme işlemini entitystate üzerinden gerçekleştirdiğimiz için buna gerek kalmadı
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter); //filterden  gelen değeri döndür
            //SingleOrDefault bir dizide veya listede sadece bir tane değer döndürmek
            //için kulllanılan entity framework linq komutudur
        }

      

        public void Insert(T p)
        {
            var addedEntity = c.Entry(p);//ekleyeceğimiz değeri addedEntity içine atadık
            addedEntity.State = EntityState.Added;//addedentity değişkeninin statesine added statesini atadık
           // _object.Add(p); //ekleme işlemini entitystate üzerinden gerçekleştirdiğimiz için buna gerek kalmadı
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();//gönderilen filtera göre listeleme yapacak
        }

        public void Update(T p)
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
