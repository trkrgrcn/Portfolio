using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio.Models;
namespace Portfolio.Controllers
{
    public class SkillController : Controller
    {
     MyPortfolioDbEntities1 _context = new MyPortfolioDbEntities1();
        public ActionResult SkillList()
        {
            var values = _context.Skill.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSkill()
        { 
            return View(); 
        }
        [HttpPost]
        public ActionResult CreateSkill(Skill skill)
        { 
            _context.Skill.Add(skill);
            _context.SaveChanges();
            return RedirectToAction("SkillList"); 
        }   
        
        public ActionResult DeleteSkill(int id)
        {
            var value = _context.Skill.Find(id);
            _context.Skill.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("SkillList"); 
        }

    }
}