using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medvedev_UserRegistration_PZ5.Model
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_User { get; set; }

        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}