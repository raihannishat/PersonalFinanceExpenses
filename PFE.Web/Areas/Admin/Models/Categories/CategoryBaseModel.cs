﻿using Autofac;
using PFE.Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Web.Areas.Admin.Models.Categories
{
    public class CategoryBaseModel : AdminBaseModel, IDisposable
    {
        protected ICategoryService _categoryService;

        public CategoryBaseModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public CategoryBaseModel()
        {
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
        }
        public void Dispose()
        {
            _categoryService?.Dispose();
        }
    }
}
