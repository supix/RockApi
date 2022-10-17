using System;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Classes.User
{
    public class Users
    {
        public int Id           { get;  set; }
        public string FirstName { get;  set; }
        public string LastName  { get;  set; }
        [Key]
        public string Username  { get;  set; }
        public string Password  { get;  set; }
        public bool Active      { get;  set; }

        public void hashPwd(string pwdHashed) {
            this.Password = pwdHashed;
        }
    }
}