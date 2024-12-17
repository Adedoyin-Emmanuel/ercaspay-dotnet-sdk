namespace ErcaspaySDK.Core.Interfaces;

    /// <summary>
    /// Represents a base response structure for API requests.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response body.</typeparam>
    public interface IBaseResponse<TResponse>
    {
        /// <summary>
        /// Indicates whether the request was successful.
        /// </summary>
        bool RequestSuccessful { get; set; }

        /// <summary>
        /// A code representing the status of the response (e.g., success, error).
        /// </summary>
        string ResponseCode { get; set; }

        /// <summary>
        /// A message providing additional details on the response, typically used for errors.
        /// </summary>
        string ErrorMessage { get; set; }

        /// <summary>
        /// A message providing additional details on the response, typically used for success responses.
        /// </summary>
        string ResponseMessage { get; set; }

        /// <summary>
        /// The actual data returned in the response.
        /// </summary>
        TResponse ResponseBody { get; set; }
    }
