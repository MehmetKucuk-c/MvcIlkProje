using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.EntityFramework
{
    public class EfHeadingDal:GeneticRepository<Heading>, IHeadingDal
    {
        
    }
}