//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BullsAndCows.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long MessageTypeId { get; set; }
        public long UserId { get; set; }
        public long GameId { get; set; }
        public long MessageStateId { get; set; }
    
        public virtual Game Game { get; set; }
        public virtual MessageState MessageState { get; set; }
        public virtual User User { get; set; }
        public virtual MessageType MessageType { get; set; }
    }
}