using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopClothing.Repository;
using OnlineShopClothing.ViewModels;

namespace OnlineShopClothing.Controllers
{
    public class ClothingController : Controller
    {
        private IUnitOfWork _unitOfWork;

        private IWebHostEnvironment _hostingEnvironment;

        public ClothingController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult AllClothing()
        {
            var clothing = _unitOfWork.Clothing.GetAll(includeProperties: "Category,Brand,Country");
            return Json(new { data = clothing });
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            ClothingVM vm = new()
            {
                Clothing = new(),
                Categories = _unitOfWork.Category.GetItems(),
                Brands = _unitOfWork.Brand.GetItems(),
                Countries = _unitOfWork.Country.GetItems(),
                Sizes = _unitOfWork.Size.GetItems(),
            };

            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Clothing = _unitOfWork.Clothing.GetT(x => x.Id == id);
                if (vm.Clothing == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult CreateUpdate(ClothingVM vm, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string uploadDir = Path.Combine(_hostingEnvironment.WebRootPath, "ClothingImage");
                    string fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                    string filePath = Path.Combine(uploadDir, fileName);

                    if (vm.Clothing.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(_hostingEnvironment.WebRootPath, vm.Clothing.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    vm.Clothing.ImageUrl = @"\ClothingImage\" + fileName;
                }
                if (vm.Clothing.Id == 0)
                {
                    // TODO: remove SizeId when are add SizeCheckboxList
                    vm.Clothing.SizeId = 1;
                    _unitOfWork.Clothing.Add(vm.Clothing);
                    TempData["success"] = "Product Created Done!";
                }
                else
                {
                    _unitOfWork.Clothing.UpDate(vm.Clothing);
                    TempData["success"] = "Product Update Done!";
                }

                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            vm.Categories = _unitOfWork.Category.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            vm.Brands = _unitOfWork.Brand.GetItems();
            vm.Countries = _unitOfWork.Country.GetItems();
            vm.Sizes = _unitOfWork.Size.GetItems();

            return View(vm);
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var clothing = _unitOfWork.Clothing.GetT(x => x.Id == id);

            if (clothing == null)
            {
                return Json(new { success = false, message = "Error in Fetching Data" });
            }
            else
            {
                var oldImagePath = Path.Combine(_hostingEnvironment.WebRootPath, clothing.ImageUrl.TrimStart('\\'));

                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }

                _unitOfWork.Clothing.Delete(clothing);
                _unitOfWork.Save();

                return Json(new { success = true, message = "Clothing Deleted" });
            }
        }
    }
}
