using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.Cooky.Logic;
using ppedv.Cooky.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ppedv.Cooky.UI.Web.Controllers
{
    public class RezeptController : Controller
    {
        Core core = new Core();

        // GET: RezeptController
        public ActionResult Index()
        {
            return View(core.UnitOfWork.RezeptRepository.Query().ToList());
        }

        // GET: RezeptController/Details/5
        public ActionResult Details(int id)
        {
            return View(core.UnitOfWork.RezeptRepository.GetById(id));
        }

        // GET: RezeptController/Create
        public ActionResult Create()
        {
            return View(new Rezept() { Name = "NEU" });
        }

        // POST: RezeptController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Rezept rezept)
        {
            try
            {
                core.UnitOfWork.RezeptRepository.Add(rezept);
                core.UnitOfWork.SaveAll();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RezeptController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(core.UnitOfWork.RezeptRepository.GetById(id));

        }

        // POST: RezeptController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Rezept rezept)
        {
            try
            {
                core.UnitOfWork.RezeptRepository.Update(rezept);
                core.UnitOfWork.SaveAll();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RezeptController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(core.UnitOfWork.RezeptRepository.GetById(id));
        }

        // POST: RezeptController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Rezept rezept)
        {
            try
            {
                var loaded = core.UnitOfWork.RezeptRepository.GetById(id);
                if (loaded != null)
                {
                    core.UnitOfWork.RezeptRepository.Delete(loaded);
                    core.UnitOfWork.SaveAll();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
