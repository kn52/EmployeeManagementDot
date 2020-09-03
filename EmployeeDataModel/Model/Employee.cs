namespace EmployeeDataModel.Model
{
    using System.ComponentModel.DataAnnotations;
    public class Employee
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(2, ErrorMessage = "Minimun length is two.")]
        [RegularExpression("^[a-zA-z]{0,}$", ErrorMessage = "Name is not valid.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-mail address is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid.")]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Phone number is required")]
        [Range(10,10)]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Phone number must be in numbers.")]
        public string PhoneNumber { get; set; }
    }
}
