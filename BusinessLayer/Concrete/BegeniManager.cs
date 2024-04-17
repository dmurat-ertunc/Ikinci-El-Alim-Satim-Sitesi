using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BegeniManager  : IBegeniService
    {
        private readonly IBegeniDal begeniDal;

        public BegeniManager(IBegeniDal begeniDal)
        {
            this.begeniDal = begeniDal;
        }

        public void TAdd(Begeni entity)
        {
            begeniDal.Add(entity);
        }

        public void TDelete(Begeni entity)
        {
            begeniDal.Delete(entity);
        }

        public List<Begeni> TGetAll()
        {
            return begeniDal.GetAll();
        }

        public Begeni TGetById(int id)
        {
            return begeniDal.GetById(id);
        }

        public void TUpdate(Begeni entity)
        {
            begeniDal.Update(entity);
        }
    }
}
