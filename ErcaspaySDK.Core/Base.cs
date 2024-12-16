using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ErcaspaySDK;

    /// <summary>
    /// Base class for interacting with the Ercaspay API.
    /// Provides a configurable HTTP client with predefined headers, 
    /// environment-specific base URLs, and response handlers.
    /// </summary>
    public abstract class ErcaspayBase
    {
        /// <summary>
        /// The secret key for authenticating API requests.
        /// </summary>
        protected readonly string SecretKey;

        /// <summary>
        /// The HttpClient instance for making HTTP requests.
        /// </summary>
        protected readonly HttpClient Client;

        /// <summary>
        /// The base URL for the Ercaspay API (sandbox or production).
        /// </summary>
        protected readonly string BaseUrl;

        /// <summary>
        /// The current environment ('development' or 'production').
        /// Defaults to 'development'.
        /// </summary>
        protected readonly string Environment;

        /// <summary>
        /// Initializes an instance of the ErcaspayBase class.
        /// </summary>
        /// <param name="secretKey">The secret key used to authenticate requests.</param>
        /// <param name="environment">The environment for the API (defaults to 'development').</param>
        /// <exception cref="ArgumentException">Thrown if the secret key is not provided.</exception>
        protected ErcaspayBase(string secretKey, string environment = "development")
        {
            if (string.IsNullOrWhiteSpace(secretKey))
            {
                throw new ArgumentException("Secret key is required", nameof(secretKey));
            }

            SecretKey = secretKey;
            Environment = environment.ToLower();
            
            const string SANDBOX_URL = "https://gw.ercaspay.com/api/v1";
            const string PRODUCTION_URL = "https://api.ercaspay.com/api/v1";

            BaseUrl = Environment == "development" ? SANDBOX_URL : PRODUCTION_URL;

            // Initialize HttpClient with base settings
            Client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };

            // Set default headers
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SecretKey);
        }

        /// <summary>
        /// Handles HTTP responses and errors.
        /// </summary>
        /// <typeparam name="T">The expected response type.</typeparam>
        /// <param name="response">The HTTP response message.</param>
        /// <returns>The deserialized response.</returns>
        /// <exception cref="HttpRequestException">Thrown if the response is unsuccessful.</exception>
        protected async Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                // Read error message from response
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(errorContent);
            }

            // Deserialize the response content
            var content = await response.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<T>(content, new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }

