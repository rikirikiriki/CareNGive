using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareNGive
{
    public class CategoriesLogic:BaseLogic
    {
        public CategoryModel GetOneCategory(int id)
        {
            return DB.Categories.Where(u => u.CategoryID == id).Select(u => new CategoryModel
            { id = u.CategoryID, subCategoryID = u.ParentCategory, name = u.CategoryName, description = u.Description }).SingleOrDefault();
        }
        public List<CategoryModel> GetAllCategories()
        {
            return DB.Categories.Where(u=>u.ParentCategory==null).Select(u => new CategoryModel
            { id=u.CategoryID, name = u.CategoryName, description = u.Description }).ToList();
        }
        public List<string> GetCategoryNames()
        {
            return DB.Categories.Where(c => c.ParentCategory == null).Select(c => c.CategoryName).ToList();
        }
        public List<CategoryModel> GetSubCategories(int categoryID)
        {
            return DB.Categories.Where(c => c.ParentCategory == categoryID).Select(c => new CategoryModel
            { id = c.CategoryID, name = c.CategoryName, description = c.Description }).ToList();
        }
        //public List<CategoryModel> GetSubCategories(string categoryName)
        //{
        //    int categoryID = DB.Categories.Where(c => c.CategoryName == categoryName).Select(c => c.CategoryID).FirstOrDefault();
        //    return DB.Categories.Where(c => c.ParentCategory == categoryID).Select(c => new CategoryModel
        //    { id = c.CategoryID, name = c.CategoryName, description = c.Description }).ToList();
        //}
        public List<string> GetSubCategoryNames(string categoryName)
        {
            int categoryID = DB.Categories.Where(c => c.CategoryName == categoryName).Select(c => c.CategoryID).FirstOrDefault();
            return DB.Categories.Where(c => c.ParentCategory == categoryID).Select(c => c.CategoryName).ToList();
        }

        public string GetCategoryNameByID(int adID)
        {
            int subID = DB.Advertisements.Where(a => a.AdID == adID).Select(a => a.CategoryID).SingleOrDefault();
            int? id = DB.Categories.Where(c => c.CategoryID == subID).Select(c => c.ParentCategory).SingleOrDefault();
            return DB.Categories.Where(c => c.CategoryID == id).Select(c => c.CategoryName).SingleOrDefault();
        }
        //public CategoryModel AddCategory(CategoryModel categoryModel)
        //{
        //    Category category = new Category {ParentCategory=categoryModel.subCategoryID, CategoryName=categoryModel.name, Description=categoryModel.description };
        //    DB.Categories.Add(category);
        //    DB.SaveChanges();
        //    return GetOneCategory(category.CategoryID);
        //}
    }
}
