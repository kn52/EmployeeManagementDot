namespace EmployeeDataModel.Model
{
    using System.ComponentModel.DataAnnotations;
    public class Employee
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("^[A-Z]{1}[a-zA-Z\\s]{1,}$", ErrorMessage = "Name should contain only alphabats start with capital letter")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("^[A-Z]{1}[a-zA-Z\\s]{1,}$", ErrorMessage = "Name should contain only alphabats start with capital letter")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-mail address is required")]
        [RegularExpression("^[a-zA-Z]{1,}([-|+|.|_]?[a-zA-Z0-9]+)?[@]{1}[A-Za-z0-9]+[.]{1}[a-zA-Z]{2,4}([.]{1}[a-zA-Z]+)?$",
            ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=[^$@!#%*?&]*[$#@!%*?&][^$@!#%*?&]*$).{8,}$",
            ErrorMessage = "Password must contain atleast one uppercase, lowercase, number and atmost one special character with minimum length 8")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Phone number is required")]
        [StringLength(10,ErrorMessage = "Phone number must be of 10 digits")]
        [RegularExpression("^[0-9]{10}$",ErrorMessage = "Phone number should contain digits only")]
        public string PhoneNumber { get; set; }
    }
}
