using System;

namespace NHibernate.demo.Entity
{
	 	//TimesheetEntries
		public class TimesheetEntries
	{
	
      	/// <summary>
		/// TimesheetEntryId
        /// </summary>
        public virtual int TimesheetEntryId
        {
            get; 
            set; 
        }        
		/// <summary>
		/// EntryDate
        /// </summary>
        public virtual DateTime? EntryDate
        {
            get; 
            set; 
        }        
		/// <summary>
		/// NumberOfHours
        /// </summary>
        public virtual int? NumberOfHours
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Comments
        /// </summary>
        public virtual string Comments
        {
            get; 
            set; 
        }        
		/// <summary>
		/// TimesheetID
        /// </summary>
        public virtual int? TimesheetID
        {
            get; 
            set; 
        }        
		   
	}
}