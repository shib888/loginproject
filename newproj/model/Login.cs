using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newproj.model
{
    public class Login
    {
        public string FirstrName { get; set; }
        public string SecondName { get; set; }
        public string ChildsFirstName { get; set; }
        public string ChildsSecondName { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public Login()
        {

        }
        public Login(string FirstrName, string SecondName, string ChildsFirstName, string ChildsSecondName, int Age, string Password, string Email)
        {
            this.FirstrName = FirstrName;
            this.SecondName = SecondName;
            this.ChildsFirstName = ChildsFirstName;
            this.ChildsSecondName = ChildsSecondName;
            this.Age = Age;
            this.Password = Password;
            this.Email = Email;

        }
       
    }
}
