using System;
using System.Collections.Generic;

namespace ErcaspaySDK.Core.Interfaces;

    /// <summary>
    /// Represents the request structure for initiating a checkout transaction.
    /// </summary>
    public interface IInitiateCheckoutTransactionRequest
    {
        /// <summary>
        /// The amount for the transaction.
        /// </summary>
        decimal Amount { get; set; }

        /// <summary>
        /// A unique reference for the payment.
        /// </summary>
        string PaymentReference { get; set; }

        /// <summary>
        /// A comma-separated list of available payment methods.
        /// </summary>
        string PaymentMethods { get; set; }

        /// <summary>
        /// The name of the customer initiating the payment.
        /// </summary>
        string CustomerName { get; set; }

        /// <summary>
        /// The email address of the customer.
        /// </summary>
        string CustomerEmail { get; set; }

        /// <summary>
        /// The phone number of the customer (optional).
        /// </summary>
        string CustomerPhoneNumber { get; set; }

        /// <summary>
        /// The currency in which the transaction will be processed. It can be NGN, GBP, USD, EUR, and CAD.
        /// </summary>
        string Currency { get; set; }

        /// <summary>
        /// Defines who bears the transaction fee ("customer" or "merchant").
        /// </summary>
        string FeeBearer { get; set; }

        /// <summary>
        /// The URL to redirect to after the transaction.
        /// </summary>
        string RedirectUrl { get; set; }

        /// <summary>
        /// A description of the transaction.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Additional metadata related to the transaction (optional).
        /// </summary>
        Dictionary<string, object> Metadata { get; set; }
    }

    /// <summary>
    /// Represents the response structure after initiating a checkout transaction.
    /// </summary>
    public interface IInitiateCheckoutTransactionResponse
    {
        /// <summary>
        /// The unique payment reference.
        /// </summary>
        string PaymentReference { get; set; }

        /// <summary>
        /// A unique transaction reference.
        /// </summary>
        string TransactionReference { get; set; }

        /// <summary>
        /// The URL to complete the checkout process.
        /// </summary>
        string CheckoutUrl { get; set; }
    }

    /// <summary>
    /// Represents the details of a customer.
    /// </summary>
    public interface ICustomer
    {
        /// <summary>
        /// The name of the customer.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The email address of the customer.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// The phone number of the customer (optional).
        /// </summary>
        string PhoneNumber { get; set; }

        /// <summary>
        /// A unique reference identifier for the customer.
        /// </summary>
        string Reference { get; set; }
    }

    /// <summary>
    /// Represents the response structure for verifying a checkout transaction.
    /// </summary>
    public interface IVerifyCheckoutTransactionResponse
    {
        /// <summary>
        /// The domain where the transaction was processed.
        /// </summary>
        string Domain { get; set; }

        /// <summary>
        /// The status of the transaction (e.g., success, failed).
        /// </summary>
        string Status { get; set; }

        /// <summary>
        /// The ERCs reference associated with the transaction.
        /// </summary>
        string ErcsReference { get; set; }

        /// <summary>
        /// The unique transaction reference.
        /// </summary>
        string TxReference { get; set; }

        /// <summary>
        /// The amount for the transaction.
        /// </summary>
        decimal Amount { get; set; }

        /// <summary>
        /// A description of the transaction.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// The timestamp when the payment was made.
        /// </summary>
        string PaidAt { get; set; }

        /// <summary>
        /// The timestamp when the transaction was created.
        /// </summary>
        string CreatedAt { get; set; }

        /// <summary>
        /// The payment channel used for the transaction.
        /// </summary>
        string Channel { get; set; }

        /// <summary>
        /// The currency in which the transaction was processed.
        /// </summary>
        string Currency { get; set; }

        /// <summary>
        /// Additional metadata related to the transaction (optional).
        /// </summary>
        Dictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// The fee charged for processing the transaction.
        /// </summary>
        decimal Fee { get; set; }

        /// <summary>
        /// Specifies who bears the transaction fee ("customer" or "merchant").
        /// </summary>
        string FeeBearer { get; set; }

        /// <summary>
        /// The amount that was actually settled for the transaction.
        /// </summary>
        decimal SettledAmount { get; set; }

        /// <summary>
        /// Information about the customer involved in the transaction.
        /// </summary>
        ICustomer Customer { get; set; }
    }

