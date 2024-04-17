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
    public class KategorilerManager : IKategorilerService
    {
        private readonly IKategorilerDal _kategorilerDal;
        public KategorilerManager(IKategorilerDal kategorilerDal)
        {
            _kategorilerDal = kategorilerDal;
        }
        public void TAdd(Kategoriler entity)
        {
            _kategorilerDal.Add(entity);
        }

        public void TDelete(Kategoriler entity)
        {
            _kategorilerDal.Delete(entity);
        }

        public List<Kategoriler> TGetAll()
        {
            return _kategorilerDal.GetAll();
        }

        public Kategoriler TGetById(int id)
        {
            return _kategorilerDal.GetById(id);
        }

        public void TUpdate(Kategoriler entity)
        {
            _kategorilerDal.Update(entity);
        }
    }
}
