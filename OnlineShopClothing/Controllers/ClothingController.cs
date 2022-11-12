using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopClothing.Models;
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
            var sizes  =_unitOfWork.Size.GetItems();
            var clothingSizes = _unitOfWork.ClothingSize.GetItems();

            foreach(var item in clothing)
            {
                item.JoinedClothingSizes = String.Join(',', (clothingSizes.Where(cs => cs.ClothingId == item.Id).Select(cs => sizes.First(s => s.Value == cs.SizeId.ToString()).Text)));
            }

            return Json(new { data = clothing });
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            var clothingSizes = _unitOfWork.ClothingSize.GetItemsByClothingId(id ?? 0).Select(c => c.SizeId.ToString()).ToList();

            ClothingVM vm = new()
            {
                Clothing = new(),
                Categories = _unitOfWork.Category.GetItems(),
                Brands = _unitOfWork.Brand.GetItems(),
                Countries = _unitOfWork.Country.GetItems(),
                Sizes = _unitOfWork.Size.GetItems().ToList(),
            };

            foreach (var item in vm.Sizes)
            {
                item.Selected = clothingSizes.Contains(item.Value);
            }

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
                    //_unitOfWork.Size.GetItems();


                    _unitOfWork.Clothing.Add(vm.Clothing);
                    TempData["success"] = "Product Created Done!";
                }
                else
                {
                    _unitOfWork.Clothing.UpDate(vm.Clothing);
                    TempData["success"] = "Product Update Done!";
                }

                _unitOfWork.Save();

                var selectedSizesIds = vm.Sizes.Where(x => x.Selected).Select(y => y.Value).ToList();
                var clothingSizes = _unitOfWork.ClothingSize.GetItemsByClothingId(vm.Clothing.Id).Select(c => c.SizeId.ToString()).ToList();
                
                // Добавление новых записей
                foreach (var sizeId in selectedSizesIds)
                {
                    int.TryParse(sizeId, out int sizeIdInt);
                    if (clothingSizes != null && !clothingSizes.Contains(sizeId))
                        _unitOfWork.ClothingSize.Add(new ClothingSize() { ClothingId = vm.Clothing.Id, SizeId = sizeIdInt });

                }
                //Удаление существующих
                foreach (var sizeId in clothingSizes)
                {
                    int.TryParse(sizeId, out int sizeIdInt);
                    if (!selectedSizesIds.Contains(sizeId.ToString()))
                        _unitOfWork.ClothingSize.Delete(sizeIdInt);
                }

                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            // If ModelState is not valid we add all lists which are null 
            vm.Categories = _unitOfWork.Category.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            vm.Brands = _unitOfWork.Brand.GetItems();
            vm.Countries = _unitOfWork.Country.GetItems();
            vm.Sizes = _unitOfWork.Size.GetItems().ToList();

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
