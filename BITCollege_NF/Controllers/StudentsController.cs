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
    public class StudentsController : Controller
    {
        private BITCollege_NFContext db = new BITCollege_NFContext();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.AcademicProgram).Include(s => s.GradePointState);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym");
            ViewBag.GradePointStateId = new SelectList(db.GradePointStates, "GradePointStateId", "Description");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,GradePointStateId,AcademicProgramId,StudentNumber,FirstName,LastName,Address,City,Province,DateCreated,GradePointAverage,OutstandingFees,Notes")] Student student)
        {
            student.SetNextStudentNumber();
            // Check for a GPA state change.
            // Automatically persist the change in the db.

            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                student.ChangeState();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym", student.AcademicProgram.ProgramAcronym);
            ViewBag.GradePointStateId = new SelectList(db.GradePointStates, "GradePointStateId", "Description", student.GradePointState.Description);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym", student.AcademicProgramId);
            ViewBag.GradePointStateId = new SelectList(db.GradePointStates, "GradePointStateId", "GradePointStateId", student.GradePointStateId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,GradePointStateId,AcademicProgramId,StudentNumber,FirstName,LastName,Address,City,Province,DateCreated,GradePointAverage,OutstandingFees,Notes")] Student student)
        {
            // Check for a GPA state change.
            // Automatically persist the change in the db.
            // Step 1: Query our student
            //Student student = db.Students.Include(s => s.Registrations).Include(s => s.GradePointState).First(s => s.Id == student.StudentId);

            //double tuitionAdjustment = student.GradePointState.TuitionRateAdjustment(student);


            //Gpas = db.GradePointStates.ToList();
            //Whenever we check the GPA of a student.
            
            
            //IQueryable<double> tuitionAmounts = from courses in db.Courses where courses.AcademicProgramId == student.AcademicProgramId select courses.TuitionAmount;

            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                student.ChangeState();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AcademicProgramId = new SelectList(db.AcademicPrograms, "AcademicProgramId", "ProgramAcronym", student.AcademicProgramId);
            ViewBag.GradePointStateId = new SelectList(db.GradePointStates, "GradePointStateId", "GradePointStateId", student.GradePointStateId);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
