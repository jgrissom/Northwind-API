using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class ProductController : Controller
    {
        // this controller depends on the NorthwindRepository
        private INorthwindRepository repository;
        public ProductController(INorthwindRepository repo) => repository = repo;

        public IActionResult Category() => View(repository.Categories.OrderBy(c => c.CategoryName));
        public IActionResult Index(int id) => View(repository.Products.Where(p => p.CategoryId == id && p.Discontinued == false).OrderBy(p => p.ProductName));
        public IActionResult Discounts() => View(repository.Discounts.Where(d => d.StartTime <= DateTime.Now && d.EndTime > DateTime.Now));
    }
}