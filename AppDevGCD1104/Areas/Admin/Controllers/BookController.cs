﻿using AppDevGCD1104.Models;
using AppDevGCD1104.Models.ViewModels;
using AppDevGCD1104.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AppDevGCD1104.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Book> myList = _unitOfWork.BookRepository.GetAll("Category").ToList();
            return View(myList);
        }
        public IActionResult Create()
        {
            BookVM bookVM = new BookVM()
            {
                Categories = _unitOfWork.CategoryRepository.GetAll().Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                }),
                Book = new Book()
            };
            return View(bookVM);
        }
        [HttpPost]
        public IActionResult Create(BookVM bookVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwrootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string bookPath = Path.Combine(wwwrootPath, @"img\Books");
                    using (var fileStream = new FileStream(Path.Combine(bookPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    bookVM.Book.ImgUrl = @"img\Books\" + fileName;
                }
                _unitOfWork.BookRepository.Add(bookVM.Book);
                _unitOfWork.BookRepository.Save();
                TempData["success"] = "Book created successfully";
                return RedirectToAction("Index");
            }
            return View(bookVM);
        }
        public IActionResult Edit(int? id)
        {
            BookVM bookVM = new BookVM()
            {
                Categories = _unitOfWork.CategoryRepository.GetAll().Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                }),
                Book = _unitOfWork.BookRepository.Get(c => c.Id == id)
            };
            bookVM.Categories = _unitOfWork.CategoryRepository.GetAll().Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString(),
            });
            return View(bookVM);
        }
        [HttpPost]
        public IActionResult Edit(BookVM bookVM, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwrootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string bookPath = Path.Combine(wwwrootPath, @"img\Books");
                    // Delete Old Images
                    if (!string.IsNullOrEmpty(bookVM.Book.ImgUrl))
                    {
                        var oldImagePath = Path.Combine(wwwrootPath, bookVM.Book.ImgUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    // Copy File to \img\Books
                    using (var fileStream = new FileStream(Path.Combine(bookPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    // Update ImageUrl in DB
                    bookVM.Book.ImgUrl = @"\img\Books\" + fileName;
                }
                _unitOfWork.BookRepository.Update(bookVM.Book);
                _unitOfWork.BookRepository.Save();
                TempData["success"] = "Book edited successfully";
                return RedirectToAction("Index");
            }
            return View(bookVM);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Book? book = _unitOfWork.BookRepository.Get(c => c.Id == id, "Category");
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost]
        public IActionResult Delete(Book book)
        {
             _unitOfWork.BookRepository.Delete(book);
            _unitOfWork.BookRepository.Save();
            TempData["success"] = "Book deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
