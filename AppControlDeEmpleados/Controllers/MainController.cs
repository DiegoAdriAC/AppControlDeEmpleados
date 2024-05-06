using AppControlDeEmpleados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AppControlDeEmpleados.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {
        private readonly AppDBContext _dbContext;

        public MainController(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        /* ---------- Person ---------- */
        [HttpPost]
        [Route("InsertPerson")]
        public async Task<IActionResult> PostPerson(Person person)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dbContext.Person.Add(person);
                await _dbContext.SaveChangesAsync();

                return CreatedAtAction("Insert", new { id = person.Id }, person);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetPersonForId")]
        public async Task<IActionResult> GetRoleId(int id)
        {
            try
            {
                var person = await _dbContext.Person.FindAsync(id);
                if (person == null)
                {
                    return NotFound();
                }
                return Ok(person);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetAllPerson")]
        public async Task<IActionResult> GetAllRole()
        {
            try
            {
                var Person = await _dbContext.Person.ToListAsync();
                return Ok(Person);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("UpdatePerson")]
        public async Task<IActionResult> UpdateRole(int id, Person person)
        {
            try
            {
                if (id != person.Id)
                {
                    return BadRequest();
                }

                var existingPerson = await _dbContext.Person.FindAsync(id);
                if (existingPerson == null)
                {
                    return NotFound();
                }

                _dbContext.Entry(existingPerson).CurrentValues.SetValues(person);

                await _dbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("DeletePerson")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                var person = await _dbContext.Person.FindAsync(id);
                if (person == null)
                {
                    return NotFound();
                }

                _dbContext.Person.Remove(person);
                await _dbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /* ----------- Role ---------- */

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddRole(Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Si tienes una lista de empleados para agregar al rol, puedes hacerlo aquí
                if (role.Employees != null && role.Employees.Any())
                {
                    foreach (var employee in role.Employees)
                    {
                        // Asigna el rol al empleado
                        employee.Role = role;
                        // Añade el empleado al contexto para ser insertado en la base de datos
                        _dbContext.Employee.Add(employee);
                    }
                }

                // Añade el rol al contexto para ser insertado en la base de datos
                _dbContext.Role.Add(role);
                // Guarda los cambios en la base de datos
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "Internal server error: " + ex.Message);
            }

            return CreatedAtAction("GetRole", new { id = role.IdRole }, role);
        }

        //[HttpGet]
        //[Route("GetId")]
        //public async Task<IActionResult> GetRoleId(int id)
        //{
        //    return Ok(await _dbContext.Role.ToListAsync());
        //}

        //[HttpGet]
        //[Route("GetAll")]
        //public async Task<IActionResult> GetAllRole()
        //{
        //    return Ok();
        //}

        //[HttpPut]
        //[Route("Update")]
        //public async Task<IActionResult> UpdateRole()
        //{
        //    return Ok();
        //}

        //[HttpDelete]
        //[Route("Delete")]
        //public async Task<IActionResult> DeleteRole()
        //{
        //    return Ok();
        //}
    }
}
