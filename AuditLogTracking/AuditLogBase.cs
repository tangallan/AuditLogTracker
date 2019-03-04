using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace AuditLogTracking
{
    /// <summary>
    /// This is a base class to be used to track changes on the parent class
    /// </summary>
    public class AuditLogBase 
    {
        private readonly AuditLogInformation _auditLogInformations;
        private readonly Dictionary<string, object> _currentState;

        /// <summary>
        /// This constructor takes in the name of the class we are tracking and the user context (user name)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userContextName"></param>
        public AuditLogBase(string entity, string userContextName)
        {
            _auditLogInformations = new AuditLogInformation(entity, userContextName);
            _currentState = new Dictionary<string, object>();
        }

        /// <summary>
        /// Initialize our Current State to keep track of the previous values
        /// </summary>
        protected void Initialize()
        {
            var thisType = this.GetType();
            PropertyInfo[] properties = thisType.GetProperties();

            // Save the current value of the properties to our dictionary.
            foreach (PropertyInfo property in properties)
            {
                var value = thisType.GetProperty(property.Name)?.GetValue(this);

                _currentState.Add(property.Name, value);
            }
        }

        /// <summary>
        /// On changes needs to be called by the properties we want to keep track of
        /// Inside the on changes we update our Current State to keep track of the previous value and it also logs the changes
        /// </summary>
        /// <param name="callerMember"></param>
        protected void OnChanges( [CallerMemberName] string callerMember= "")
        {
            var currentValue = this.GetType().GetProperty(callerMember).GetValue(this);
            if (this._currentState.ContainsKey(callerMember))
            {
                var prevValue = this._currentState[callerMember];
                this._currentState[callerMember] = currentValue;

                _auditLogInformations.Changes.Add($"Field {callerMember}, original value: {prevValue ?? ""}, new value: {currentValue}");
            }
            else
            {
                _auditLogInformations.Changes.Add($"Field {callerMember}, original value: , new value: {currentValue}");
            }
        }

        /// <summary>
        /// Simple console write line on our logs
        /// </summary>
        public void DisplayChanges()
        {
            foreach (var c in this._auditLogInformations.Changes)
            {
                Console.WriteLine(c);
            }
        }
    }
}
