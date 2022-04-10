using System.Collections.Generic;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        void CategoryAdd(Category p);
        Category GetById(int id);
        void CategoryDelete(Category p);
        void CategoryUpdate(Category p);
    }
}