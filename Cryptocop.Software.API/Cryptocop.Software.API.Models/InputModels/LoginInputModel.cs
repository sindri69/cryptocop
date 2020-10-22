using System.ComponentModel.DataAnnotations;

namespace Cryptocop.Software.API.Models.InputModels
{
    public class LoginInputModel
    {
        [Required]
        //[RegularExpression ("(http|ftp|https)://[\\w-]+(.[\\w-]+)+([\\w-.,@?^=%&amp;:/~+#]*[\\w-@?^=%&amp;/~+#])?")]
        //[RegularExpression ("(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*)")]
        //vantar regex sem virkar til ad tjekka a email

        public string Email { get; set; }

        [Required]
        [MinLength(8)]

        public string Password { get; set; }

    }
}