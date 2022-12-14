using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.FindAll();

            return View(products);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.Create(productModel);
                if (response != null)
                    return RedirectToAction(nameof(ProductIndex));
            }

            return View(productModel);
        }

        public async Task<IActionResult> ProductUpdate(int id)
        {
            var productModel = await _productService.FindById(id);
            if (productModel != null)
                return View(productModel);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel productModel)
        {
            /*ToDo: ele esta dando erro na hora de salvar por causa de trazer com a virgula e salvar com o ponto*/
            if (ModelState.IsValid)
            {
                var response = await _productService.Update(productModel);
                if (response != null)
                    return RedirectToAction(nameof(ProductIndex));
            }

            return View(productModel);
        }

        public async Task<IActionResult> ProductDelete(int id)
        {
            var productModel = await _productService.FindById(id);
            if (productModel != null)
                return View(productModel);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductModel productModel)
        {
                var response = await _productService.DeleteById(productModel.Id);
                if (response)
                    return RedirectToAction(nameof(ProductIndex));
            return View(productModel);
        }
    }
}
