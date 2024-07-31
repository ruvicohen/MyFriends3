using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFriends3.Data;
using MyFriends3.Models;
using MyFriends3.ViewModels;

namespace MyFriends3.Controllers
{
    public class UsersController : Controller
    {
        private readonly MyFriends3Context _context;

        public UsersController(MyFriends3Context context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        //public IActionResult Create()
        //{
        //    var viewModel = new ViewUserModel();
        //    viewModel.User = new User
        //    {
        //        FirstName = "Dudu",
        //        LastName = "Dudu"
        //    };

        //    return View(viewModel);
        //}

        //post: users/create
        //to protect from overposting attacks, enable the specific properties you want to bind to.
        // for more details, see http://go.microsoft.com/fwlink/?linkid=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> create([Bind("Id,FirstName,LastName,Email,Phone,SetImage")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public byte[] ConvertIFormFileToByteArray(IFormFile formFile)
        {
            if (formFile == null || formFile.Length == 0)
                return null;

            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(ViewUserModel viewUserModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.User.Add(viewUserModel.User);
        //        await _context.SaveChangesAsync();


        //        Picture picture = new Picture
        //        {
        //            PictureName = $"{viewUserModel.User.FirstName}  {viewUserModel.User.LastName}",
        //            UserId = viewUserModel.User.Id,
        //            PictureByte = ConvertIFormFileToByteArray(viewUserModel.FileImage)
        //        };
        //        _context.Picture.Add(picture);
        //        await _context.SaveChangesAsync();


        //        viewUserModel.User.ProfilePictureId = picture.PictureId;
        //        _context.Update(viewUserModel.User);
        //        await _context.SaveChangesAsync();

        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(viewUserModel);
        //}

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Phone,ProfilePictureId")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddImage()
        {
            return View(await _context.User.ToListAsync());
        }

        

        public async Task<IActionResult> Images(int? id)
        {
            var friend = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            var imgList = _context.Picture.Where(m => m.UserId == id).ToList();

            if (friend == null)
            {
                return NotFound();
            }
            ViewData["imgList"] = imgList;
            return View(imgList);
        }

        

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
