namespace Ebda3.CRM.Leads;

public enum LeadStatus : byte
{
    New,
    Open,
    Unqualified,
    AttemptingContact,
    Contacted,
    Engaged,
    Meeting,
    Qualified,
    Opportunity,
    InProgress,
    ProposalSent,
    Negotiation,
    ClosedWon,
    ClosedLost,
    Nurturing,
    Recycled,
    Inactive,
    BadTiming
}