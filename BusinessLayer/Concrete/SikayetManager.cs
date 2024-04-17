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
    public class SikayetManager : ISikayetServices
    {
        private readonly ISikayetDal sikayetDal;

        public SikayetManager(ISikayetDal sikayetDal)
        {
            this.sikayetDal = sikayetDal;
        }

        public void TAdd(Sikayet entity)
        {
            sikayetDal.Add(entity);
        }

        public void TDelete(Sikayet entity)
        {
            sikayetDal.Delete(entity);
        }

        public List<Sikayet> TGetAll()
        {
            return sikayetDal.GetAll();
        }

        public Sikayet TGetById(int id)
        {
            return sikayetDal.GetById(id);
        }

        public void TUpdate(Sikayet entity)
        {
            sikayetDal.Update(entity);
        }
    }
}
