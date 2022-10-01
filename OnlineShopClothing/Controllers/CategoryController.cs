using Microsoft.AspNetCore.Mvc;
using OnlineShopClothing.Models;
using OnlineShopClothing.Repository;

namespace OnlineShopClothing.Controllers
{
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var categories = _unitOfWork.Category.GetAll();

            return View(categories);
        }

        [HttpGet]

        public IActionResult CreateUpdate(int? id)
        {
            Category category = new Category();

            if (id == null || id == 0)
            {
                return View(category);
            }
            else
            {
                category = _unitOfWork.Category.GetT(x => x.Id == id);

                if (category == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(category);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult CreateUpdate(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                    _unitOfWork.Category.Add(category);
                }
                else
                {
                    _unitOfWork.Category.Update(category);
                }

                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = _unitOfWork.Category.GetT(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteData(int? id)
        {
            var category = _unitOfWork.Category.GetT(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Delete(category);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}