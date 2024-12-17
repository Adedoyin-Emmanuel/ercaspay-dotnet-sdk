namespace ErcaspaySDK.Core.Interfaces;

/// <summary>
/// Represents the request structure for a card transaction.
/// </summary>
public interface ICardRequest
{
    /// <summary>
    /// An encrypted version of card details. Card details should be encrypted with RSA algorithm.
    /// </summary>
    string Payload { get; set; }

    /// <summary>
    /// A unique reference for the transaction.
    /// </summary>
    string TransactionReference { get; set; }

    /// <summary>
    /// Details about the device used for the transaction.
    /// </summary>
    IDeviceDetails DeviceDetails { get; set; }
}

public interface IDeviceDetails
{
    IPayerDeviceDto PayerDeviceDto { get; set; }
}

public interface IPayerDeviceDto
{
    IDevice Device { get; set; }
}

public interface IDevice
{
    /// <summary>
    /// The browser used by the payer.
    /// </summary>
    string Browser { get; set; }

    /// <summary>
    /// Browser details related to 3D Secure and device capabilities.
    /// </summary>
    IBrowserDetails BrowserDetails { get; set; }

    /// <summary>
    /// The IP address of the payer's device (optional).
    /// </summary>
    string? IpAddress { get; set; }
}

public interface IBrowserDetails
{
    /// <summary>
    /// The 3D Secure challenge window size.
    /// </summary>
    string ThreeDSecureChallengeWindowSize { get; set; }

    /// <summary>
    /// Accept headers for the browser.
    /// </summary>
    string AcceptHeaders { get; set; }

    /// <summary>
    /// The color depth of the device's display.
    /// </summary>
    int ColorDepth { get; set; }

    /// <summary>
    /// Whether Java is enabled on the device.
    /// </summary>
    bool JavaEnabled { get; set; }

    /// <summary>
    /// The language setting of the device.
    /// </summary>
    string Language { get; set; }

    /// <summary>
    /// The height of the device's screen in pixels.
    /// </summary>
    int ScreenHeight { get; set; }

    /// <summary>
    /// The width of the device's screen in pixels.
    /// </summary>
    int ScreenWidth { get; set; }

    /// <summary>
    /// The time zone offset in minutes.
    /// </summary>
    int TimeZone { get; set; }
}

/// <summary>
/// Represents the response structure for a card transaction.
/// </summary>
public interface ICardResponse
{
    /// <summary>
    /// A code representing the status of the transaction.
    /// </summary>
    string Code { get; set; }

    /// <summary>
    /// The status of the transaction (e.g., success, failed).
    /// </summary>
    string Status { get; set; }

    /// <summary>
    /// A message from the gateway providing details about the transaction status.
    /// </summary>
    string GatewayMessage { get; set; }

    /// <summary>
    /// A support message providing additional assistance or instructions (optional).
    /// </summary>
    string? SupportMessage { get; set; }

    /// <summary>
    /// A unique reference for the transaction.
    /// </summary>
    string TransactionReference { get; set; }

    /// <summary>
    /// A unique payment reference.
    /// </summary>
    string PaymentReference { get; set; }

    /// <summary>
    /// The amount of money involved in the transaction.
    /// </summary>
    decimal Amount { get; set; }

    /// <summary>
    /// The URL to redirect to for completing the transaction.
    /// </summary>
    string RedirectUrl { get; set; }

    /// <summary>
    /// A unique reference from the gateway (optional).
    /// </summary>
    string? GatewayReference { get; set; }

    /// <summary>
    /// The ECI flag for the transaction (optional).
    /// </summary>
    string? EciFlag { get; set; }

    /// <summary>
    /// The authentication code for the transaction (optional).
    /// </summary>
    string? TransactionAuth { get; set; }

    /// <summary>
    /// The transaction ID (optional).
    /// </summary>
    string? TransactionId { get; set; }

    /// <summary>
    /// A link to authenticate the transaction (optional).
    /// </summary>
    string? TransactionAuthLink { get; set; }
}

/// <summary>
/// Represents the request structure for submitting an OTP for a transaction.
/// </summary>
public interface ISubmitOTPRequest
{
    /// <summary>
    /// The one-time password (OTP) for transaction verification.
    /// </summary>
    string Otp { get; set; }

    /// <summary>
    /// The gateway reference associated with the transaction.
    /// </summary>
    string GatewayReference { get; set; }

    /// <summary>
    /// A unique reference for the transaction.
    /// </summary>
    string TransactionReference { get; set; }
}

/// <summary>
/// Represents the response structure after submitting an OTP for a transaction.
/// </summary>
public interface ISubmitOTPResponse
{
    /// <summary>
    /// The status of the OTP submission.
    /// </summary>
    string Status { get; set; }

    /// <summary>
    /// A message from the gateway providing additional details.
    /// </summary>
    string GatewayMessage { get; set; }

    /// <summary>
    /// A unique reference for the transaction.
    /// </summary>
    string TransactionReference { get; set; }

    /// <summary>
    /// A unique payment reference.
    /// </summary>
    string PaymentReference { get; set; }

    /// <summary>
    /// The amount involved in the transaction.
    /// </summary>
    decimal Amount { get; set; }

    /// <summary>
    /// The URL to call back after submitting the OTP.
    /// </summary>
    string CallbackUrl { get; set; }
}

/// <summary>
/// Represents the request structure for resending an OTP.
/// </summary>
public interface IResendOTPRequest : ISubmitOTPRequest
{
    // OTP property is omitted.
}

/// <summary>
/// Represents the response structure after resending an OTP.
/// </summary>
public interface IResendOTPResponse : ISubmitOTPResponse
{
    // Amount and CallbackUrl properties are omitted.
}

/// <summary>
/// Represents the response structure for retrieving card details.
/// </summary>
public interface IGetCardDetailsResponse
{
    /// <summary>
    /// The amount involved in the transaction.
    /// </summary>
    decimal Amount { get; set; }

    /// <summary>
    /// A unique reference for the transaction.
    /// </summary>
    string Reference { get; set; }

    /// <summary>
    /// The currency in which the transaction is processed.
    /// </summary>
    string Currency { get; set; }
}

/// <summary>
/// Represents the response structure for verifying a card transaction.
/// </summary>
public interface IVerifyCardTransactionResponse
{
    // Define the properties as needed.
}