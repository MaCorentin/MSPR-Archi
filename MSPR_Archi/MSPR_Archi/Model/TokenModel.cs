using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSPR_Archi.Model
{
    [Table("Token")]
    public class TokenModel
    {
        [Key]
        public string userId { get; set; }
        public string token { get; set; }
        public DateTime created_on { get; set; }
        public DateTime expire_on { get; set; }
    }
}
