using System.ComponentModel.DataAnnotations;
namespace MWSProductApp.Model
{
    public class MWSLogin
    {
        [Key]
        public string? LoginId {get;set;}

        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? PassWord { get; set; }
    }
}
