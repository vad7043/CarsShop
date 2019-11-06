using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Repository {
    public class CategoryRepository : ICarsCategory {
        private readonly AppDBContent AppDBContent;
        public CategoryRepository(AppDBContent appDBContent) {
            AppDBContent = appDBContent;
        }
        public IEnumerable<Category> AllCategories => AppDBContent.Category;
    }
}
