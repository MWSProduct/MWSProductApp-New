using System.ComponentModel.DataAnnotations;
namespace MWSProductApp.Model
{
    public class MWSSetPassword
    {
        [Key]
        public string? UserGuid { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? Security_Question_1 { get; set; }
        public string? Security_Question_2 { get; set; }
        public string? Security_Question_3 { get; set; }
        public string? Security_Question_4 { get; set; }
        public string? Captcha { get; set; }

    }
}
