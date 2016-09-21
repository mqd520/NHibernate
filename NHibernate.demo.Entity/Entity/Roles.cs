using System;

namespace NHibernate.demo.Entity
{
	 	//Roles
		public class Roles
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
		/// Name
        /// </summary>
        public virtual string Name
        {
            get; 
            set; 
        }        
		/// <summary>
		/// IsActive
        /// </summary>
        public virtual bool IsActive
        {
            get; 
            set; 
        }        
		/// <summary>
		/// EntityId
        /// </summary>
        public virtual int? EntityId
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