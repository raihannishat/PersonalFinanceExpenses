﻿using PFE.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Framework.Service
{
    public interface ICategoryService:IDisposable
    {
        (IList<Category> categories, int total, int totalDisplay) GetCategories(int pageindex,
                                                                              int Pagesize,
                                                                              string searchText,
                                                                              string sortText);
        void CreateCategory(Category category);
        void EditCategory(Category category);
        Category GetCategory(int Id);
        Category DeleteCategory(int Id);
    }
}
