using System;

namespace NHibernate.demo.Entity
{
	 	//Patients
		public class Patients
	{
	
      	/// <summary>
		/// PatientId
        /// </summary>
        public virtual long PatientId
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Active
        /// </summary>
        public virtual bool Active
        {
            get; 
            set; 
        }        
		/// <summary>
		/// PhysicianId
        /// </summary>
        public virtual long PhysicianId
        {
            get; 
            set; 
        }        
		   
	}
}