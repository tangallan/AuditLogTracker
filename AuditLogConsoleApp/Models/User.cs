using System;
using System.Collections.Generic;
using System.Text;
using AuditLogTracking;

namespace AuditLogConsoleApp.Models
{
    public class User : AuditLogBase
    {
        public User(string userContextName) : base(nameof(User), userContextName)
        {
            base.Initialize();
        }

        private string _firstName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                base.OnChanges();
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                base.OnChanges();
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                base.OnChanges();
            }
        }
    }
}
