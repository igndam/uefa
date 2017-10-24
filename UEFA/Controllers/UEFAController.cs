using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UEFA.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System;

namespace UEFA.Controllers
{
    [Route("api/uefa")]
    [Authorize]
    public class UEFAController : Controller
    {
        private readonly UEFAContext _context;

        public UEFAController(UEFAContext context)
        {
            _context = context;

            if (_context.UEFAteams.Count() == 0)
            {
                _context.UEFAteams.Add(new UEFAteam { name = "Team1" });
                _context.SaveChanges();
            }
        }
        [HttpGet]
        public IEnumerable<UEFAteam> GetAll()
        {
            bool userHasReadScope = User.HasClaim("scope", "scope.readaccess");
            bool userHasFullScope = User.HasClaim("scope", "scope.fullaccess");
            if (userHasFullScope == false && userHasReadScope == false)
            {
                throw new Exception("Invalid scope");
            }
            return _context.UEFAteams.ToList();
        }

        [HttpGet("{id}", Name = "GetUEFA")]
        public IActionResult GetById(long id)
        {
            bool userHasFullScope = User.HasClaim("scope", "scope.fullaccess");
            bool userHasReadScope = User.HasClaim("scope", "scope.readaccess");
            if (userHasFullScope == false && userHasReadScope == false)
            {
                throw new Exception("Invalid scope");
            }
            var item = _context.UEFAteams.FirstOrDefault(t => t.id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UEFAteam item)
        {
            bool userHasFullScope = User.HasClaim("scope", "scope.fullaccess");
            if (userHasFullScope == false)
            {
                throw new Exception("Invalid scope");
            }
            if (item == null)
            {
                return BadRequest();
            }

            _context.UEFAteams.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetUEFA", new { id = item.id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] UEFAteam item)
        {
            bool userHasFullScope = User.HasClaim("scope", "scope.fullaccess");
            if (userHasFullScope == false)
            {
                throw new Exception("Invalid scope");
            }
            if (item == null || item.id != id)
            {
                return BadRequest();
            }

            var todo = _context.UEFAteams.FirstOrDefault(t => t.id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.name = item.name;
            todo.country = item.country;
            todo.neededQualification = item.neededQualification;
            todo.Manager = item.Manager;
            todo.currentRecord = item.currentRecord;
            todo.currentPhase = item.currentPhase;
            todo.previousWinner = item.previousWinner;

            _context.UEFAteams.Update(todo);
            _context.SaveChanges();
            return new EmptyResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            bool userHasFullScope = User.HasClaim("scope", "scope.fullaccess");
            if (userHasFullScope == false)
            {
                throw new Exception("Invalid scope");
            }
            var todo = _context.UEFAteams.FirstOrDefault(t => t.id == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.UEFAteams.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}