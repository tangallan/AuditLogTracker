using System;
using System.Collections.Generic;

namespace AuditLogTracking
{
    /// <summary>
    /// This class will represent what we will store in the audit log. For example class name, prev properties and current properties value
    /// </summary>
    internal class AuditLogInformation
    {
        public AuditLogInformation(string entity, string user)
        {
            Entity = entity;
            User = user;
            Changes = new List<string>();
            Changes.Add($"{user} made changes for {entity}");
        }

        /// <summary>
        /// this is the class name
        /// </summary>
        public string Entity { get; set; }

        /// <summary>
        /// this is the user (user context)
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// this will contain the list of ALL public properties changes
        /// </summary>
        public List<string> Changes { get; set; }
    }
}
