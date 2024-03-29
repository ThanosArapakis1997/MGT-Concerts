﻿using MGTConcerts.Models;
using MGTConcerts.Repository;
using MGTConcerts.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MGTConcerts.Areas.Cashier.Controllers
{
    [Area("Cashier")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Cashier)]
    //[Authorize(Roles = SD.Role_Cashier)]

    public class OrderController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public IActionResult Concerts()
        {
            List<Concert> ConcertList = unitOfWork.Concert.GetAll().ToList();
            return View(ConcertList);
        }
        public IActionResult Index(int? id)
        {
            List<Order> OrderList = unitOfWork.Order.GetAll(u=>u.ConcertId == id && !u.Present, includeProperties: "Concert").ToList();
            ViewBag.ConcertId = id;
            return View(OrderList);
        }

        [HttpPost]
        public IActionResult AddPresents(int id)
        {
            Order order = unitOfWork.Order.Get(u => u.Id == id);
            order.Present = true;
            TempData["success"] = "Η Κράτηση ενημερώθηκε επιτυχώς";
            unitOfWork.Order.Update(order);
            unitOfWork.Save();
                                  
            return Redirect($"/cashier/order/index?id={order.ConcertId}");
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            JsonSerializerOptions options = new()
            {
                WriteIndented = true
            };
            List<Concert> ConcertList = unitOfWork.Concert.GetAll(includeProperties: "Artist,MusicVenue").ToList();
            return Json(new { data = ConcertList }, new JsonSerializerOptions(options));
        }
        #endregion


    }

}
