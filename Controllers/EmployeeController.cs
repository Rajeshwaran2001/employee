using employee.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace employee.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context) => _context = context;

        [HttpGet]

        public async Task<ActionResult<Employee>> GetAll()
        {
            var Employee = await _context.EmployeeTable.ToListAsync();

            return Ok(new { total = Employee.Count(), data = Employee });
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Employee>> RemoveOne(int? id)
        {
            if (id == null)
            {
                return BadRequest(new { message = "ID is required" });
            }

            var employee = await _context.EmployeeTable.Where(e => e.EmployeeId == id).FirstOrDefaultAsync();
            if (employee == null)
            {
                return NoContent();
            }
            try
            {
                _context.Remove(employee);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Employee Deleted", data = employee });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"{ex.Message.ToString()}" });
            }
        }

        [HttpPut]

        public async Task<ActionResult<Employee>> Update(Employee model)
        {
            if (model == null)
            {
                return BadRequest(new { Message = "Datarequired" });
            }
            var employee = await _context.EmployeeTable.Where(e => e.EmployeeId == model.EmployeeId).FirstOrDefaultAsync();

            if (employee == null)
            {
                return NoContent();
            }
            employee.City = model.City;
            employee.Email = model.Email;
            try
            {
                _context.EmployeeTable.Update(employee);
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Employee details Update", data = model });
            }
            catch(Exception ex)
            {
                return BadRequest(new { Message = $"{ex.Message.ToString()}" });
            }

            

            
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Employee>> Get(int? id)
        {
            if(id ==null)
                return BadRequest(new { Message = "ID Required" });
            var employee = await _context.EmployeeTable.Where(e => e.EmployeeId == id).FirstOrDefaultAsync();

            if (employee == null)
            {
                return NoContent();
            }

            return Ok(new { Message = "Employee register sucefully", data = employee  });
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Create(Employee model)
        {
            if (model == null)
            {
                return BadRequest(new { Message = "Datarequired" });
            }

            var EmailExist =await _context.EmployeeTable.Where(e => e.Email == model.Email).FirstOrDefaultAsync();
            if (EmailExist !=null)
            {
                return BadRequest(new { Message = "Email already Exist" });
            }

            try
            {
                await _context.EmployeeTable.AddAsync(model);
                await _context.SaveChangesAsync();
                return Ok(new { Message = $"Employee Created Successfull", data = model });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"{ex.Message.ToString()}" });
            }

        }
    }
}
