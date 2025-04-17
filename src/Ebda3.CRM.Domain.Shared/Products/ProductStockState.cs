namespace Ebda3.CRM.Products;

// Inherit [byte] to store single byte for each value
public enum ProductStockState : byte
{
    PreOrder,
    InStock,
    NotAvailable,
    Stopped
}