using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text;
using UserCRUDApplication.DTOs;
using UserCRUDApplication.Models;

namespace UserCRUDApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext dbContext;

        public UserController(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Get All Users 

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            var List = await dbContext.Users.Select(
            s => new UserDTO
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                UserName = s.UserName,
                Password = s.Password

            }).ToListAsync();

            if(List.Count < 0)
            {
                return NotFound();
            }else
            {
                return Ok(List);
            }
        }
        
        //Get Single Users

        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            UserDTO User = await dbContext.Users.Select(s => new UserDTO
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                UserName = s.UserName,
                Password = s.Password
            }).FirstOrDefaultAsync(s => s.Id == id);

            if (User == null)
            {
                return NotFound();
            }
            else
            {
                return User;
            }
        }

        //Adding a new User 

        [HttpPost("InsertUser")]
        public async Task<ActionResult<UserDTO>> InsertUser(UserDTO userDTO)
        {
            // Map UserDTO to User entity
            var entity = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                UserName = userDTO.UserName,
                Password = userDTO.Password
            };

            dbContext.Users.Add(entity);

            await dbContext.SaveChangesAsync(); 

            var createdUserDTO = new UserDTO
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                UserName = entity.UserName,
                Password = entity.Password
            };
            return CreatedAtAction(nameof(InsertUser), createdUserDTO);
        }

        //Update a user and return it 

        [HttpPut("UpdateUser/{id}")]
        public async Task<ActionResult<UserDTO>> UpdateUser([FromBody] UserDTO userDTO,int id)
        {
          var entity = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

          if (entity == null)
          {
                return BadRequest();
          }

          entity.FirstName = userDTO.FirstName;
          entity.LastName = userDTO.LastName;
          entity.UserName = userDTO.UserName;
          entity.Password = userDTO.Password;

          await dbContext.SaveChangesAsync();

            var updatedUser = new UserDTO
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                UserName = entity.UserName,
                Password = entity.Password
            };

            return Ok(updatedUser);
        }

        //Delete a Single User

        [HttpDelete("deleteUser/{id}")]
        public async Task<string> DeleteUser(int id)
        {
            var entity = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            dbContext.Users.Remove(entity);
            await dbContext.SaveChangesAsync();

            return "Ho gaya samadhan ?";
        }

    }
}
