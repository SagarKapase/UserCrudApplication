using Microsoft.AspNetCore.Mvc;
using UserCRUDApplication.DTOs;

namespace UserCRUDApplication.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }
}
