﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using MusicShop.Core.Contracts;
using MusicShop.Core.Services;
using MusicShop.Infrastructure.Data.Entities;
using MusicShop.Models.Client;

namespace MusicShop.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class ClientController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOrderService _orderService;

        public ClientController(UserManager<ApplicationUser> userManager, IOrderService orderService)
        {
            this._userManager = userManager;
            this._orderService = orderService;
        }
        // GET: ClientController
        public async Task<IActionResult> Index()
        {
            var allUsers = this._userManager.Users
                  .Select(u => new ClientIndexVM
                  {
                      Id = u.Id,
                      UserName = u.UserName,
                      FirstName = u.FirstName,
                      LastName = u.LastName,
                      Address = u.Address,
                      Email = u.Email,
                  }).ToList();
            var adminIds = (await _userManager.GetUsersInRoleAsync("Administrator"))
                .Select(a => a.Id).ToList();
            foreach (var user in allUsers)
            {
                user.IsAdmin = adminIds.Contains(user.Id);

            }
            var users = allUsers.Where(x => x.IsAdmin == false)
                .OrderBy(x=> x.UserName).ToList();
            
            return this.View(users);
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(string id)
        {
            var user = this._userManager.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            List<Order> orders = _orderService.GetOrdersByUser(id);
            if (orders.Count >0)
            {
                return RedirectToAction(nameof(Denied));
            }
            ClientDeleteVM userToDelete = new ClientDeleteVM()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Email = user.Email,
                UserName = user.UserName,
            };
            return View(userToDelete);
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ClientDeleteVM bindingModel)
        {
            string id = bindingModel.Id;
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) 
            {
                return NotFound();

            }
            IdentityResult result = await _userManager.DeleteAsync(user);
            if (result.Succeeded) 
            {
                return RedirectToAction(nameof(Success));
            }
                return NotFound();
            
        }
        public ActionResult Success() 
        { 
            return View(); 
        }
        public ActionResult Denied()
        {
            return View();
        }
    }
}
