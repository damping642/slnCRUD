﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using prjCRUD.Models;
namespace prjCRUD.Controllers
{
    public class HomeController : Controller
    {
        dbToDoEntities db = new dbToDoEntities();
        // GET: Home
        public ActionResult Index()
        {
            var todos=db.tToDo.OrderByDescending(m => m.fDate).ToList();
            return View(todos);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create
            (string fTitle, string fImage, DateTime fDate)
        {
            tToDo todo = new tToDo();
            todo.fTitle = fTitle;
            todo.fImage = fImage;
            todo.fDate = fDate;
            db.tToDo.Add(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var todo =db.tToDo.Where(m => m.fId == id).FirstOrDefault();
            db.tToDo.Remove(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}