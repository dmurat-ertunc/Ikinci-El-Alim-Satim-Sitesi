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
    public class UrunlerManager : IUrunlerService
    {
        private readonly IUrunlerDal urunlerDal;

        public UrunlerManager(IUrunlerDal urunlerDal)
        {
            this.urunlerDal = urunlerDal;
        }

        public void TAdd(Urunler entity)
        {
            urunlerDal.Add(entity);
        }

        public void TDelete(Urunler entity)
        {
            urunlerDal.Delete(entity);
        }

        public List<Urunler> TGetAll()
        {
            return urunlerDal.GetAll();
        }

        public Urunler TGetById(int id)
        {
            return urunlerDal.GetById(id);
        }

        public void TUpdate(Urunler entity)
        {
            urunlerDal.Update(entity);
        }
    }
}
