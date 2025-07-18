// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
using Zeno.Artifacts.Shared.Client.Models;
namespace Zeno.Artifacts.Shared.Client.My.Grandexchange.Orders
{
    /// <summary>
    /// Builds and executes requests for operations under \my\grandexchange\orders
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class OrdersRequestBuilder : BaseRequestBuilder
    {
        /// <summary>
        /// Instantiates a new <see cref="global::Zeno.Artifacts.Shared.Client.My.Grandexchange.Orders.OrdersRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public OrdersRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/my/grandexchange/orders{?code*,page*,size*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Zeno.Artifacts.Shared.Client.My.Grandexchange.Orders.OrdersRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public OrdersRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/my/grandexchange/orders{?code*,page*,size*}", rawUrl)
        {
        }
        /// <summary>
        /// Fetch your sell orders details.
        /// </summary>
        /// <returns>A <see cref="global::Zeno.Artifacts.Shared.Client.Models.DataPage_GEOrderSchema_"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::Zeno.Artifacts.Shared.Client.Models.DataPage_GEOrderSchema_?> GetAsync(Action<RequestConfiguration<global::Zeno.Artifacts.Shared.Client.My.Grandexchange.Orders.OrdersRequestBuilder.OrdersRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::Zeno.Artifacts.Shared.Client.Models.DataPage_GEOrderSchema_> GetAsync(Action<RequestConfiguration<global::Zeno.Artifacts.Shared.Client.My.Grandexchange.Orders.OrdersRequestBuilder.OrdersRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            return await RequestAdapter.SendAsync<global::Zeno.Artifacts.Shared.Client.Models.DataPage_GEOrderSchema_>(requestInfo, global::Zeno.Artifacts.Shared.Client.Models.DataPage_GEOrderSchema_.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Fetch your sell orders details.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Zeno.Artifacts.Shared.Client.My.Grandexchange.Orders.OrdersRequestBuilder.OrdersRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Zeno.Artifacts.Shared.Client.My.Grandexchange.Orders.OrdersRequestBuilder.OrdersRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::Zeno.Artifacts.Shared.Client.My.Grandexchange.Orders.OrdersRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::Zeno.Artifacts.Shared.Client.My.Grandexchange.Orders.OrdersRequestBuilder WithUrl(string rawUrl)
        {
            return new global::Zeno.Artifacts.Shared.Client.My.Grandexchange.Orders.OrdersRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Fetch your sell orders details.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class OrdersRequestBuilderGetQueryParameters 
        {
            /// <summary>The code of the item.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("code")]
            public string? Code { get; set; }
#nullable restore
#else
            [QueryParameter("code")]
            public string Code { get; set; }
#endif
            /// <summary>Page number</summary>
            [QueryParameter("page")]
            public int? Page { get; set; }
            /// <summary>Page size</summary>
            [QueryParameter("size")]
            public int? Size { get; set; }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class OrdersRequestBuilderGetRequestConfiguration : RequestConfiguration<global::Zeno.Artifacts.Shared.Client.My.Grandexchange.Orders.OrdersRequestBuilder.OrdersRequestBuilderGetQueryParameters>
        {
        }
    }
}
#pragma warning restore CS0618
