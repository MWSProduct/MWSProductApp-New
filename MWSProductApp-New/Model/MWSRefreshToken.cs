using System.ComponentModel.DataAnnotations;
namespace MWSProductApp.Model
{
    public class MWSRefreshToken
    {
        [Key]
        public string? RefreshTokenId { get; set; }
        public string? UserId { get; set; }
        public string? Token { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; } = true;
        public MWSLogin? MWSLogin { get; set; }
        public string? CreatedBy { get; set; }
    }

}