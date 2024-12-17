using YourNamespace;

namespace ErcaspaySDK.Core.Interfaces;

public class ErcaspayBankTransfer : ErcaspayBase
{
 
    /// <summary>
    /// Handles bank transfer payment flows for the Ercaspay SDK.
    /// </summary>
    private const string BankTransferBaseUrl = "/payment/bank-transfer";
    
    
    
   
    /// <summary>
    /// Initializes an instance of the ErcaspayBankTransfer class.
    /// </summary>
    /// <param name="secretKey">The secret key for authentication.</param>
    /// <param name="environment">The environment ("development" or "production").</param>
    public ErcaspayBankTransfer(string secretKey, string environment = "development")
        : base(secretKey, environment)
    {
    }
    
    
    /// <summary>
    /// Initiates a bank transfer request for a given transaction reference.
    /// </summary>
    /// <param name="transactionReference">The unique reference for the transaction.</param>
    /// <returns>The response object containing transaction details.</returns>
    /// <exception cref="ArgumentException">Thrown if the transaction reference is null or empty.</exception>
    public async Task<IBaseResponse<IIntitializeTransferResponse>> InitializeTransfer(string transactionReference)
    {
        if (string.IsNullOrWhiteSpace(transactionReference))
        {
            throw new ArgumentException("Transaction reference is required", nameof(transactionReference));
        }

        var endpoint = $"{BankTransferBaseUrl}/request-bank-account/{transactionReference}";

        var response = await Client.GetAsync(endpoint);

        return await HandleResponse<IBaseResponse<IIntitializeTransferResponse>>(response);
    }
}