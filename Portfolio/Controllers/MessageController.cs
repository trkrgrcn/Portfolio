using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class MessageController : Controller
    {
        MyPortfolioDbEntities1 _context = new MyPortfolioDbEntities1();
        // GET: Message
        public ActionResult Inbox()
        {
            var values = _context.Message.ToList();
            return View(values);
        }
        public ActionResult MessageDetails(int id) 
        { 
        var value = _context.Message.Where(x=>x.MessageId==id).FirstOrDefault();
            return View(value);
        }
        public ActionResult MesaageStatusChange(int id)
        {
            var value = _context.Message.Where(x => x.MessageId == id).FirstOrDefault();
            if(value.IsRead==false)
            {
                value.IsRead = true;
            }
            else
            {
                value.IsRead = false;
            }
            _context.SaveChanges();
            return RedirectToAction("Inbox");
        }
    }
}