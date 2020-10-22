namespace Cryptocop.Software.API.Models.Dtos
{
  //á þessi class að erfa ehv?
  //í large assignment 1 erfa classarnir hypermediamodel
    public class UserDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public int TokenId { get; set; }

    }
}