using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KickyLegs.Data;
using KickyLegs.Domain.DataContext;
using KickyLegs.Domain.Repositories;
using KickyLegs.Web.Models.Events;
using Microsoft.AspNet.Identity;

namespace KickyLegs.Web.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {

        private readonly IEventRepository _eventRepository;

        public EventsController()
        {
            _eventRepository = new EventRepository(new EventDbContext());
        }

        // GET: Events
        public ActionResult Index()
        {
            return View(_eventRepository.GetUserEvents(User.Identity.GetUserId()));
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var @event = _eventRepository.GetEvent(id.Value);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            var createViewModel = new CreateEventViewModel {EventTime = DateTime.Now};

            return View(createViewModel);
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEventViewModel createEventViewModel)
        {
            if (ModelState.IsValid)
            {
                var @event = new Event();
                @event.DateTime = createEventViewModel.EventTime;
                @event.Duration = createEventViewModel.Duration;
                @event.UserId = User.Identity.GetUserId();
                @event.LastCaffeine = createEventViewModel.LastCaffeine > -1 ? createEventViewModel.LastCaffeine : (int?)null;
                @event.LastFood = createEventViewModel.LastFood;
                @event.Notes = createEventViewModel.Notes;

                _eventRepository.Save(@event);
                return RedirectToAction("Index");
            }

            return View(createEventViewModel);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _eventRepository.GetEvent(id.Value);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,UserId,DateTime,LastCaffeine,LastFood,Duration,Notes")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _eventRepository.Save(@event);
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var @event = _eventRepository.GetEvent(id.Value);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var @event = _eventRepository.GetEvent(id);
            _eventRepository.Delete(@event);
            return RedirectToAction("Index");
        }
    }
}
