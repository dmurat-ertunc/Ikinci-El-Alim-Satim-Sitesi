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
    public class IlanlarManager : IlanlarService
    {
        private readonly IlanlarDal ilanlarDal;

        public IlanlarManager(IlanlarDal ilanlarDal)
        {
            this.ilanlarDal = ilanlarDal;
        }

        public void TAdd(Ilanlar entity)
        {
            ilanlarDal.Add(entity);
        }

        public void TDelete(Ilanlar entity)
        {
            ilanlarDal.Delete(entity);
        }

        public List<Ilanlar> TGetAll()
        {
            return ilanlarDal.GetAll();
        }

        public Ilanlar TGetById(int id)
        {
            return ilanlarDal.GetById(id);
        }

        public void TUpdate(Ilanlar entity)
        {
            ilanlarDal.Update(entity);
        }
    }
}
