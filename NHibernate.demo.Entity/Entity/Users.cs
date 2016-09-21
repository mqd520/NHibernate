using System;

namespace NHibernate.demo.Entity
{
	 	//Users
		public class Users
	{
	
      	/// <summary>
		/// UserId
        /// </summary>
        public virtual int UserId
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
		/// InvalidLoginAttempts
        /// </summary>
        public virtual int? InvalidLoginAttempts
        {
            get; 
            set; 
        }        
		/// <summary>
		/// RegisteredAt
        /// </summary>
        public virtual DateTime? RegisteredAt
        {
            get; 
            set; 
        }        
		/// <summary>
		/// LastLoginDate
        /// </summary>
        public virtual DateTime? LastLoginDate
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Enum1
        /// </summary>
        public virtual string Enum1
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Enum2
        /// </summary>
        public virtual int Enum2
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Features
        /// </summary>
        public virtual int Features
        {
            get; 
            set; 
        }        
		/// <summary>
		/// RoleId
        /// </summary>
        public virtual int? RoleId
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Property1
        /// </summary>
        public virtual string Property1
        {
            get; 
            set; 
        }        
		/// <summary>
		/// Property2
        /// </summary>
        public virtual string Property2
        {
            get; 
            set; 
        }        
		/// <summary>
		/// OtherProperty1
        /// </summary>
        public virtual string OtherProperty1
        {
            get; 
            set; 
        }        
		   
	}
}