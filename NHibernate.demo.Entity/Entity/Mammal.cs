using System;

namespace NHibernate.demo.Entity
{
	 	//Mammal
		public class Mammal
	{
	
      	/// <summary>
		/// Animal
        /// </summary>
        public virtual int Animal
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Pregnant
        /// </summary>
        public virtual bool Pregnant
        {
            get; 
            set; 
        }        
		/// <summary>
		/// BirthDate
        /// </summary>
        public virtual DateTime? BirthDate
        {
            get; 
            set; 
        }        
		   
	}
}