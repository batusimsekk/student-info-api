using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static List<Student> _students = new List<Student>();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_students);
        }
        
        [HttpGet("get/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById([FromRoute]int id)
        {
            var student = _students.Find(x => x.Id == id);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost("post")]
        public IActionResult Post([FromForm]Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(_students.Any(s => s.Number == student.Number))
            {
                return Conflict("Bu öğrenci numarası zaten kayıtlı");
            }
            student.Id = _students.Count == 0 ? 1 : _students.Max(x => x.Id) + 1;
            _students.Add(student);
            return Ok();
        }

        [HttpPut("update/{number}")]
        // NUMARASINI HİÇBİR ZAMAN DEĞİŞEMEZ
        public IActionResult Update(int number,Student student)
        {
            var update = _students.Find(x => x.Number == number);
            if(update == null)
            {
                return NotFound("Ogrenci bulunamadı!");
            }
            update.Name = student.Name;
            update.Surname = student.Surname;
            update.Class = student.Class;
            return Ok(update);
        }

        [HttpDelete("delete/{number}")]
        public IActionResult Delete(int number)
        {
            var item = _students.Find(x => x.Number == number);
            if(item == null)
            {
                return NotFound("Ogrenci bulunamadı!");
            }
            _students.Remove(item);
            return NoContent();
        }
    }
}
 