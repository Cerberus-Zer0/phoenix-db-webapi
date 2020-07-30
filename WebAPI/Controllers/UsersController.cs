using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using WebAPI.Data;
using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _repository;
        private readonly IMapper _mapper;

        public UsersController(IUser repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<User>> GetAllUsers()
        {
            var users = _repository.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
        }

        [HttpGet("{id}")]
        public ActionResult <UserReadDto> GetUserById(int id)
        {
            var user = _repository.GetUserById(id);

            if (user != null)
            {
                return Ok(_mapper.Map<UserReadDto>(user));
            }
            return NotFound();
        }
        
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserUpdateDto userUpdateDto) 
        {
            var userModelFromRepo = _repository.GetUserById(id);
            if (userModelFromRepo == null) 
            {
                return NotFound();
            }
            _mapper.Map(userUpdateDto, userModelFromRepo);
            _repository.UpdateUser(userModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUserUpdate(int id, JsonPatchDocument<UserUpdateDto> patchDoc) 
        {
            var userModelFromRepo = _repository.GetUserById(id);
            if (userModelFromRepo == null) 
            {
                return NotFound();
            }

            var userToPatch = _mapper.Map<UserUpdateDto>(userModelFromRepo);
            patchDoc.ApplyTo(userToPatch, ModelState);
            if (!TryValidateModel(userToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(userToPatch, userModelFromRepo);
            _repository.UpdateUser(userModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id) 
        {
            var userModelFromRepo = _repository.GetUserById(id);
            if (userModelFromRepo == null) 
            {
                return NotFound();
            }
            _repository.DeleteUser(userModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}