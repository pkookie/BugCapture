//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BugCapture.Domain.DataConnections
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ticket
    {
        public Ticket()
        {
            this.SystemTickets = new HashSet<SystemTicket>();
            this.TicketDocuments = new HashSet<TicketDocument>();
            this.UserTickets = new HashSet<UserTicket>();
        }
    
        public int TicketId { get; set; }
        public System.DateTime RaisedOn { get; set; }
        public int PriorityId { get; set; }
        public string ProblemSummary { get; set; }
        public string ProblemDescription { get; set; }
        public string StepsToReproduce { get; set; }
        public string ExpectedOutcome { get; set; }
        public string ActualOutcome { get; set; }
        public string WorkAround { get; set; }
    
        public virtual Priority Priority { get; set; }
        public virtual ICollection<SystemTicket> SystemTickets { get; set; }
        public virtual ICollection<TicketDocument> TicketDocuments { get; set; }
        public virtual ICollection<UserTicket> UserTickets { get; set; }
    }
}
