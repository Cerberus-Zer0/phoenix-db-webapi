using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using WebAPI.Data;
using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/institutions")]
    [ApiController]
    public class InstitutionsController : ControllerBase
    {
        private readonly IInstitution _repository;
        private readonly IMapper _mapper;

        public InstitutionsController(IInstitution repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult <InstitutionReadDto> CreateInstitution(InstitutionCreateDto institutionCreateDto) 
        {
            var institutionModel = _mapper.Map<Institution>(institutionCreateDto);
            _repository.CreateInstitution(institutionModel);
            _repository.SaveChanges();

            var institutionReadDto = _mapper.Map<InstitutionReadDto>(institutionModel);

            return CreatedAtRoute(nameof(GetInstitutionById), new {Id = institutionReadDto.Id}, institutionReadDto);
        }

        [HttpGet]
        public ActionResult <IEnumerable<Institution>> GetAllInstitutions()
        {
            var institutions = _repository.GetAllInstitutions();

            return Ok(_mapper.Map<IEnumerable<InstitutionReadDto>>(institutions));
        }

        [HttpGet("{id}", Name="GetInstitutionById")]
        public ActionResult <InstitutionReadDto> GetInstitutionById(int id)
        {
            var institution = _repository.GetInstitutionById(id);

            if (institution != null)
            {
                return Ok(_mapper.Map<InstitutionReadDto>(institution));
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateInstitution(int id, InstitutionUpdateDto institutionUpdateDto) 
        {
            var institutionModelFromRepo = _repository.GetInstitutionById(id);
            if (institutionModelFromRepo == null) 
            {
                return NotFound();
            }
            _mapper.Map(institutionUpdateDto, institutionModelFromRepo);
            _repository.UpdateInstitution(institutionModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialInstitutionUpdate(int id, JsonPatchDocument<InstitutionUpdateDto> patchDoc) 
        {
            var institutionModelFromRepo = _repository.GetInstitutionById(id);
            if (institutionModelFromRepo == null) 
            {
                return NotFound();
            }

            var institutionToPatch = _mapper.Map<InstitutionUpdateDto>(institutionModelFromRepo);
            patchDoc.ApplyTo(institutionToPatch, ModelState);
            if (!TryValidateModel(institutionToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(institutionToPatch, institutionModelFromRepo);
            _repository.UpdateInstitution(institutionModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteInstitution(int id) 
        {
            var institutionModelFromRepo = _repository.GetInstitutionById(id);
            if (institutionModelFromRepo == null) 
            {
                return NotFound();
            }
            _repository.DeleteInstitution(institutionModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}