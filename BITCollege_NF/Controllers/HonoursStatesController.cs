﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BITCollege_NF.Data;
using BITCollege_NF.Models;

namespace BITCollege_NF.Controllers
{
    public class HonoursStatesController : Controller
    {
        private BITCollege_NFContext db = new BITCollege_NFContext();

        // GET: HonoursStates
        public ActionResult Index()
        {
            return View(db.GradePointStates.ToList());
        }

        // GET: HonoursStates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HonoursState honoursState = (HonoursState)db.GradePointStates.Find(id);
            if (honoursState == null)
            {
                return HttpNotFound();
            }
            return View(honoursState);
        }

        // GET: HonoursStates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HonoursStates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GradePointStateId,LowerLimit,UpperLimit,TuitionRateFactor")] HonoursState honoursState)
        {
            if (ModelState.IsValid)
            {
                db.GradePointStates.Add(honoursState);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(honoursState);
        }

        // GET: HonoursStates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HonoursState honoursState = (HonoursState)db.GradePointStates.Find(id);
            if (honoursState == null)
            {
                return HttpNotFound();
            }
            return View(honoursState);
        }

        // POST: HonoursStates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GradePointStateId,LowerLimit,UpperLimit,TuitionRateFactor")] HonoursState honoursState)
        {
            if (ModelState.IsValid)
            {
                db.Entry(honoursState).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(honoursState);
        }

        // GET: HonoursStates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HonoursState honoursState = (HonoursState)db.GradePointStates.Find(id);
            if (honoursState == null)
            {
                return HttpNotFound();
            }
            return View(honoursState);
        }

        // POST: HonoursStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HonoursState honoursState = (HonoursState)db.GradePointStates.Find(id);
            db.GradePointStates.Remove(honoursState);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}