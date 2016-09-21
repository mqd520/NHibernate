using System;

namespace NHibernate.demo.Entity
{
	 	//Animal
		public class Animal
	{
	
      	/// <summary>
		/// Id
        /// </summary>
        public virtual int Id
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Description
        /// </summary>
        public virtual string Description
        {
            get; 
            set; 
        }        
		/// <summary>
		/// body_weight
        /// </summary>
        public virtual decimal? body_weight
        {
            get; 
            set; 
        }        
		/// <summary>
		/// mother_id
        /// </summary>
        public virtual int? mother_id
        {
            get; 
            set; 
        }        
		/// <summary>
		/// father_id
        /// </summary>
        public virtual int? father_id
        {
            get; 
            set; 
        }        
		/// <summary>
		/// SerialNumber
        /// </summary>
        public virtual string SerialNumber
        {
            get; 
            set; 
        }        
		/// <summary>
		/// ParentId
        /// </summary>
        public virtual int? ParentId
        {
            get; 
            set; 
        }        
		   
	}
}