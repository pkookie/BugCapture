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
    
    public partial class TicketDocument
    {
        public int TicketDocumentsId { get; set; }
        public int TicketId { get; set; }
        public int DocumentId { get; set; }
    
        public virtual Document Document { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
