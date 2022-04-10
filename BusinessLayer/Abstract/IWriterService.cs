using System.Collections.Generic;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        void WriterAdd(Writer p);
        void WriterDelete(Writer p);
        void WriterUpdate(Writer p);
        Writer GetById(int id);
    }
}