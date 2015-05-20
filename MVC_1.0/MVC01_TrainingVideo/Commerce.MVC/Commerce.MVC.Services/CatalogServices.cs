using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Commerce.MVC.Data;
using Commerce.MVC.Data.DataAccess;

namespace Commerce.MVC.Services
{
    public class CatalogServices
    {

        ICatalogRepository _repository = null;
        public CatalogServices(ICatalogRepository repository)
        {
            _repository = repository;
            if (_repository == null)
            {
                throw new InvalidOperationException("Repository ");
            }
        }
        public IList<Category> GetCatergories()
        {

            IList<Category> rawCategories = _repository.GetCategories().ToList();
            var parents = (from c in rawCategories
                           where c.ParentID == 0
                           select c).ToList();

            parents.ForEach(p =>
            {
                p.SubCategories = (from subs in rawCategories
                                   where subs.ParentID == p.ID
                                   select subs).ToList();
            });

            return parents;
        }
        public IList<Product> GetProductsByCategory(int categoryID) {
            return _repository.GetProducts().WithCategory(categoryID).ToList();
        }
        public Product GetProductsByID(int id)
        {
            return _repository.GetProducts().WithID(id).Single();
        }
    }
}
