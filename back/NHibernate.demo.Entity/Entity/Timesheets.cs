using System;

namespace NHibernate.demo.Entity
{
	 	//Timesheets
		public class Timesheets
	{
	
      	/// <summary>
		/// TimesheetId
        /// </summary>
        public virtual int TimesheetId
        {
            get; 
            set; 
        }        
		/// <summary>
		/// SubmittedDate
        /// </summary>
        public virtual DateTime? SubmittedDate
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Submitted
        /// </summary>
        public virtual bool Submitted
        {
            get; 
            set; 
        }        
		   
	}
}