using System;

namespace NHibernate.demo.Entity
{
	 	//Region
		public class Region
	{
	
      	/// <summary>
		/// RegionId
        /// </summary>
        public virtual long RegionId
        {
            get; 
            set; 
        }        
		/// <summary>
		/// RegionDescription
        /// </summary>
        public virtual string RegionDescription
        {
            get; 
            set; 
        }        
		   
	}
}