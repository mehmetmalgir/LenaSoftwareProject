using AutoMapper;
using LenaSoftware.API.Bussiness.Contracts;
using LenaSoftware.API.Model.Dtos;
using LenaSoftware.API.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LenaSoftware.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private readonly IFormBs _bS;
        private readonly IFieldBs _fB;
        private readonly IMapper _mapper;

        public FormsController(IFormBs bS, IMapper mapper, IFieldBs fB)
        {
            _bS = bS;
            _mapper = mapper;
            _fB = fB;

        }

        [ProducesResponseType(typeof(List<FormGetDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public ActionResult<List<FormGetDto>> GetAll()
        {
            try
            {
                var forms = _bS.GetAllForms(null, "Field", "User");
                var dtos = _mapper.Map<List<FormGetDto>>(forms);

                return Ok(dtos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [ProducesResponseType(typeof(FormGetDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public ActionResult<FormGetDto> GetFormById(int id)
        {

            try
            {
                if (id < 0)
                    return BadRequest("Id 0'dan Küçük Olamaz");

                var form = _bS.GetFormById(id, "Field", "User");

                if (form == null)
                    return NotFound("Bu Id'li Bir Ürün Bulunamadı");

                var dto = _mapper.Map<FormGetDto>(form);
                return Ok(dto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }


        [ProducesResponseType(typeof(FormGetDto), StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<FormGetDto> AddProduct([FromBody] FormForCreation dto)
        {
            var form = _mapper.Map<Form>(dto);
            form.CreatedAt = DateTime.Now;

            var insertedForm = _bS.AddNewForm(form);            

            var insertedDto = _mapper.Map<FormGetDto>(insertedForm);

            Fields entity = new Fields();
            entity.Name = dto.Name;
            entity.Surname = dto.Surname;
            entity.Age = dto.Age;
            entity.FormId = form.Id;

            _fB.AddToField(entity);
            

            return Created("", insertedDto);
        }






    }
}
