// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
using Zeno.Artifacts.Shared.Client.My.Item.ActionNamespace.Npc.Buy;
using Zeno.Artifacts.Shared.Client.My.Item.ActionNamespace.Npc.Sell;
namespace Zeno.Artifacts.Shared.Client.My.Item.ActionNamespace.Npc
{
    /// <summary>
    /// Builds and executes requests for operations under \my\{name}\action\npc
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class NpcRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The buy property</summary>
        public global::Zeno.Artifacts.Shared.Client.My.Item.ActionNamespace.Npc.Buy.BuyRequestBuilder Buy
        {
            get => new global::Zeno.Artifacts.Shared.Client.My.Item.ActionNamespace.Npc.Buy.BuyRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The sell property</summary>
        public global::Zeno.Artifacts.Shared.Client.My.Item.ActionNamespace.Npc.Sell.SellRequestBuilder Sell
        {
            get => new global::Zeno.Artifacts.Shared.Client.My.Item.ActionNamespace.Npc.Sell.SellRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Zeno.Artifacts.Shared.Client.My.Item.ActionNamespace.Npc.NpcRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public NpcRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/my/{name}/action/npc", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Zeno.Artifacts.Shared.Client.My.Item.ActionNamespace.Npc.NpcRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public NpcRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/my/{name}/action/npc", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
