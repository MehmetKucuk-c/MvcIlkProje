using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class WriterManager:IWriterService
    {
        public  WriterManager (IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        private readonly IWriterDal _writerDal;

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public void WriterAdd(Writer p)
        {
            _writerDal.Insert(p);
        }

        public void WriterDelete(Writer p)
        {
            _writerDal.Delete(p);
        }

        public void WriterUpdate(Writer p)
        {
            _writerDal.Update(p);
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(x => x.WriterId == id);
        }
    }
}