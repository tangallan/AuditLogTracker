using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace AuditLogTracking
{
    /// <summary>
    /// This class is the main class of how we store and keep track of updates
    /// </summary>
    internal class AuditLog<T>
    {
        private readonly AuditLogInformation _auditLogInformations;
        private readonly Dictionary<string, object> _currentState;
        private readonly T _entity;

        public AuditLog(T entity, string userContextName)
        {
            _entity = entity;
            _auditLogInformations = new AuditLogInformation(entity.GetType().Name, userContextName);
            _currentState = new Dictionary<string, object>();
            Initialize();
        }

        /// <summary>
        /// Initialize our Current State to keep track of the previous values
        /// </summary>
        private void Initialize()
        {
            var thisType = _entity.GetType();
            PropertyInfo[] properties = thisType.GetProperties();

            // Save the current value of the properties to our dictionary.
            foreach (PropertyInfo property in properties)
            {
                var value = thisType.GetProperty(property.Name)?.GetValue(_entity);

                _currentState.Add(property.Name, value);
            }
        }

        /// <summary>
        /// On changes needs to be called by the properties we want to keep track of
        /// Inside the on changes we update our Current State to keep track of the previous value and it also logs the changes
        /// </summary>
        public void OnChanges(string propertyName)
        {
            var currentValue = _entity.GetType().GetProperty(propertyName)?.GetValue(_entity);
            if (_currentState.ContainsKey(propertyName))
            {
                var prevValue = _currentState[propertyName];
                _currentState[propertyName] = currentValue;

                _auditLogInformations.Changes.Add($"Field {propertyName}, original value: {prevValue ?? ""}, new value: {currentValue}");
            }
            else
            {
                _auditLogInformations.Changes.Add($"Field {propertyName}, original value: , new value: {currentValue}");
            }
        }

        /// <summary>
        /// Simple console write line on our logs
        /// </summary>
        public void DisplayChanges()
        {
            foreach (var c in _auditLogInformations.Changes)
            {
                Console.WriteLine(c);
            }
        }
    }
}
