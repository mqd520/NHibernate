using System;

namespace NHibernate.demo.Entity
{
	 	//Physicians
		public class Physicians
	{
	
      	/// <summary>
		/// PhysicianId
        /// </summary>
        public virtual long PhysicianId
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Name
        /// </summary>
        public virtual string Name
        {
            get; 
            set; 
        }        
		   
	}
}