using System.Collections.Generic;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        void HeadingAdd(Heading p);
        Heading GetById(int id);
        void HeadingDelete(Heading p);
        void HeadingUpdate(Heading p);
    }
}