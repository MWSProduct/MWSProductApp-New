using System.ComponentModel.DataAnnotations;
namespace MWSProductApp.Model
{
    public class MWSRoles
    {
        [Key]
        public string? RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}