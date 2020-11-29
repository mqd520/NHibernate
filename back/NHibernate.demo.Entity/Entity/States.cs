using System;

namespace NHibernate.demo.Entity
{
	 	//States
		public class States
	{
	
      	/// <summary>
		/// StateId
        /// </summary>
        public virtual long StateId
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Abbreviation
        /// </summary>
        public virtual string Abbreviation
        {
            get; 
            set; 
        }        
		/// <summary>
		/// FullName
        /// </summary>
        public virtual string FullName
        {
            get; 
            set; 
        }        
		   
	}
}