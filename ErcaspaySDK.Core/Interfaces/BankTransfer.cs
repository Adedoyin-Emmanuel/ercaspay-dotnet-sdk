namespace ErcaspaySDK.Core.Interfaces;

public interface IIntitializeTransferResponse
{
    /// <summary>
    /// The status of the transfer (e.g., success, failed).
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// A message from the gateway providing additional details about the transfer status.
    /// </summary>
    public string GatewayMessage { get; set; }

    /// <summary>
    /// A unique reference for the transaction.
    /// </summary>
    public string TransactionReference { get; set; }

    /// <summary>
    /// The amount of money to be transferred.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// The account number to which the transfer will be made.
    /// </summary>
    public string AccountNumber { get; set; }

    /// <summary>
    /// The email address associated with the account receiving the transfer.
    /// </summary>
    public string AccountEmail { get; set; }

    /// <summary>
    /// The name of the account holder receiving the transfer.
    /// </summary>
    public string AccountName { get; set; }

    /// <summary>
    /// A unique reference for the account involved in the transfer.
    /// </summary>
    public string AccountReference { get; set; }

    /// <summary>
    /// The name of the bank handling the transfer.
    /// </summary>
    public string BankName { get; set; }

    /// <summary>
    /// The time in seconds until the transfer expires.
    /// </summary>
    public int ExpiresIn { get; set; }
}
