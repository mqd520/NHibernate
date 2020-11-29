using System;

namespace NHibernate.demo.Entity
{
	 	//PatientRecords
		public class PatientRecords
	{
	
      	/// <summary>
		/// PatientRecordId
        /// </summary>
        public virtual long PatientRecordId
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Gender
        /// </summary>
        public virtual int Gender
        {
            get; 
            set; 
        }        
		/// <summary>
		/// BirthDate
        /// </summary>
        public virtual DateTime BirthDate
        {
            get; 
            set; 
        }        
		/// <summary>
		/// FirstName
        /// </summary>
        public virtual string FirstName
        {
            get; 
            set; 
        }        
		/// <summary>
		/// LastName
        /// </summary>
        public virtual string LastName
        {
            get; 
            set; 
        }        
		/// <summary>
		/// AddressLine1
        /// </summary>
        public virtual string AddressLine1
        {
            get; 
            set; 
        }        
		/// <summary>
		/// AddressLine2
        /// </summary>
        public virtual string AddressLine2
        {
            get; 
            set; 
        }        
		/// <summary>
		/// City
        /// </summary>
        public virtual string City
        {
            get; 
            set; 
        }        
		/// <summary>
		/// StateId
        /// </summary>
        public virtual long? StateId
        {
            get; 
            set; 
        }        
		/// <summary>
		/// ZipCode
        /// </summary>
        public virtual string ZipCode
        {
            get; 
            set; 
        }        
		/// <summary>
		/// PatientId
        /// </summary>
        public virtual long PatientId
        {
            get; 
            set; 
        }        
		   
	}
}