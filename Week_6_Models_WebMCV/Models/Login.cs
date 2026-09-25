using System.ComponentModel.DataAnnotations;

namespace Week_6_Models_WebMCV.Models
{
    public class Login
    {
        public string userName { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
