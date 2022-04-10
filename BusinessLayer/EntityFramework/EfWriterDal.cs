using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.EntityFramework
{
    public class EfWriterDal :GeneticRepository<Writer>, IWriterDal
    {
        
    }
}