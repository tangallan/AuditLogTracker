using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AuditLogTracking
{
    /// <summary>
    /// This is the only class we expose to allow user to wrap their own classes
    /// User will need to use UpdateAndTrack function to enable tracking for certain properties they want to keep track
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AuditLogTracker<T> where T : class
    {
        private readonly AuditLog<T> _auditLog;
        private readonly T _classToTrack;

        public AuditLogTracker(T classToTrack, string userName)
        {
            _classToTrack = classToTrack;
            _auditLog = new AuditLog<T>(classToTrack, userName);
        }

        /// <summary>
        /// UpdateAndTrack function to log the update and Also updates the property for the object
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="nameOfProperty"></param>
        /// <param name="value"></param>
        public void UpdateAndTrack<TValue>(string nameOfProperty, TValue value)
        {
            var propInfo = _classToTrack.GetType().GetProperty(nameOfProperty);
            if (propInfo != null)
            {
                propInfo.SetValue(_classToTrack, value);
                _auditLog.OnChanges(nameOfProperty);
            }
        }

        /// <summary>
        /// Console.Writeline display for all the changes for the object
        /// </summary>
        public void DisplayChanges()
        {
            _auditLog.DisplayChanges();
        }
    }
}
