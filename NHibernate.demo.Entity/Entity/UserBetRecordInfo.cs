using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.demo.Entity.Entity
{
    public class UserBetRecordInfo
    {
        /// <summary>
        /// Id 
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// From
        /// </summary>
        public virtual int FromPlatform { get; set; }

        /// <summary>
        /// To
        /// </summary>
        public virtual int ToND { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public virtual double Amount { get; set; }

        /// <summary>
        /// Region  下注区域
        /// </summary>
        public virtual string Region { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public virtual string Username { get; set; }

        /// <summary>
        /// Nd user name
        /// </summary>
        public virtual string Ndusername { get; set; }

        /// <summary>
        /// Apitype
        /// </summary>
        public virtual int Apitype { get; set; }

        /// <summary>
        /// Result
        /// </summary>
        public virtual int Result { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public virtual int FrisbeeStatus { get; set; }

        /// <summary>
        /// Pull time
        /// </summary>
        public virtual DateTime Pulltime { get; set; }

        /// <summary>
        /// Bet time
        /// </summary>
        public virtual DateTime Bettime { get; set; }

        /// <summary>
        /// Period 期号
        /// </summary>
        public virtual string Period { get; set; }

        /// <summary>
        /// Game Type
        /// </summary>
        public virtual int GameType { get; set; }

        /// <summary>
        /// Get Guid
        /// </summary>
        public virtual string Guid { get; set; }

        /// <summary>
        /// Status Text
        /// </summary>
        public virtual string StatusText { get; set; }

        /// <summary>
        /// Result Text
        /// </summary>
        public virtual string ResultText { get; set; }
    }
}
