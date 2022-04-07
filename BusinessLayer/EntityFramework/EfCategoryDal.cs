using DataAccessLayer.Concrete.Repositories;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.EntityFramework
{
    public class EfCategoryDal : GeneticRepository<Category>, ICategoryDal
    {

    }
}
