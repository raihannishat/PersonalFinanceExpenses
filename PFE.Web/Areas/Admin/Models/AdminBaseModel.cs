using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using PFE.Framework;

namespace PFE.Web.Areas.Admin.Models
{
    public abstract class AdminBaseModel
    {
        public MenuModel MenuModel { get; set; }
        public ResponseModel Response
        {
            get
            {
                if (_httpContextAccessor.HttpContext.Session.IsAvailable
                    && _httpContextAccessor.HttpContext.Session.Keys.Contains(nameof(Response)))
                {
                    var response = _httpContextAccessor.HttpContext.Session.Get<ResponseModel>(nameof(Response));
                    _httpContextAccessor.HttpContext.Session.Remove(nameof(Response));

                    return response;
                }
                else
                    return null;
            }
            set
            {
                _httpContextAccessor.HttpContext.Session.Set(nameof(Response),
                    value);
            }
        }

        protected IHttpContextAccessor _httpContextAccessor;
        public AdminBaseModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            SetupMenu();
        }

        public AdminBaseModel()
        {
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
            SetupMenu();
        }

        private void SetupMenu()
        {
            MenuModel = new MenuModel
            {
                MenuItems = new List<MenuItem>
                {
                    new MenuItem
                    {
                        Title = "Category",
                        Childs = new List<MenuChildItem>
                        {
                            new MenuChildItem{ Title = "Category list", Url = "/Admin/Category" },
                            new MenuChildItem{ Title = "Add Category", Url ="/Admin/Category/CreateCategory"}
                                
                        }

                    },
                      new MenuItem
                    {
                        Title = "Items",
                        Childs = new List<MenuChildItem>
                        {
                            new MenuChildItem{ Title = "Item list", Url = "/Admin/ItemCategory" },
                            new MenuChildItem{ Title = "Add Item", Url ="/Admin/ItemCategory/CreateCategory"}

                        }

                    },
                    new MenuItem
                    {
                        Title = "Budget",
                        Childs = new List<MenuChildItem>
                        {
                            new MenuChildItem{ Title = "Budget list", Url = "/Admin/Budget" },
                            new MenuChildItem{ Title = "Add Budget", Url ="/Admin/Budget/CreateBudget"}

                        }

                    },
                        new MenuItem
                    {
                        Title = "Expenses",
                        Childs = new List<MenuChildItem>
                        {
                            new MenuChildItem{ Title = "Expenses List", Url = "/Admin/Expenses" },
                            new MenuChildItem{ Title = "Add Expenses", Url ="/Admin/Expenses/CreateBudget"}

                        }

                    },

                         new MenuItem
                    {
                        Title = "Report",
                        Childs = new List<MenuChildItem>
                        {
                            new MenuChildItem{ Title = "Result", Url = "/GenarateRepot" }
                        }

                    },
                    new MenuItem
                    {
                        Title = "Setting",
                        Childs = new List<MenuChildItem>
                        {
                            new MenuChildItem{ Title = "Manage Profile", Url = "/Identity/Account/Manage/Index" },
                            new MenuChildItem{ Title = "Log Out", Url ="/Identity/Account/Logout"}

                        }

                    }
                }
            };

        }
    }
}

