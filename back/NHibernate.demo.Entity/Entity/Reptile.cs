using System;

namespace NHibernate.demo.Entity
{
	 	//Reptile
		public class Reptile
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
		/// BodyTemperature
        /// </summary>
        public virtual decimal? BodyTemperature
        {
            get; 
            set; 
        }        
		   
	}
}