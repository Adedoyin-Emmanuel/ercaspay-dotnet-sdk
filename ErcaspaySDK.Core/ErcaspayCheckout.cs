using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ErcaspaySDK.Interfaces;
using YourNamespace;

namespace ErcaspaySDK;

    /// <summary>
    /// Provides methods for interacting with the Ercaspay Checkout API.
    /// </summary>
    public class ErcaspayCheckout : ErcaspayBase
    {
        private readonly string CheckoutBaseUrl = "/payment";

        public ErcaspayCheckout(string secretKey, string? environment = "development") : base(secretKey, environment)
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="ErcaspayCheckout"/> class.
        /// </summary>
        /// <param name="secretKey">The secret key used to authenticate requests.</param>
        /// <param name="environment">The environment for the API (defaults to 'development').</param>
        public async Task<IBaseResponse<IInitiateCheckoutTransactionResponse>> InitiateTransaction(
            IInitiateCheckoutTransactionRequest data)
        {
            var response = await Client.PostAsJsonAsync($"{CheckoutBaseUrl}/initiate", data);
            return await HandleResponse<IBaseResponse<IInitiateCheckoutTransactionResponse>>(response);
        }

        /// <summary>
        /// Verifies the status of a transaction by sending a GET request with the transaction reference.
        /// </summary>
        /// <param name="transactionReference">The reference of the transaction to verify.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the response body.</returns>
        public async Task<IBaseResponse<IVerifyCheckoutTransactionResponse>> VerifyTransaction(
            string transactionReference)
        {
            var response = await Client.GetAsync($"{CheckoutBaseUrl}/transaction/verify/{transactionReference}");
            
            return await HandleResponse<IBaseResponse<IVerifyCheckoutTransactionResponse>>(response);
        }
    }
