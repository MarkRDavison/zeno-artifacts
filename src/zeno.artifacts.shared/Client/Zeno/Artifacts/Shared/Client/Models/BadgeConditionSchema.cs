// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace Zeno.Artifacts.Shared.Client.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class BadgeConditionSchema : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Code of the condition.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Code { get; set; }
#nullable restore
#else
        public string Code { get; set; }
#endif
        /// <summary>Quantity of the condition (if any).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Zeno.Artifacts.Shared.Client.Models.BadgeConditionSchema.BadgeConditionSchema_quantity? Quantity { get; set; }
#nullable restore
#else
        public global::Zeno.Artifacts.Shared.Client.Models.BadgeConditionSchema.BadgeConditionSchema_quantity Quantity { get; set; }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::Zeno.Artifacts.Shared.Client.Models.BadgeConditionSchema"/> and sets the default values.
        /// </summary>
        public BadgeConditionSchema()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::Zeno.Artifacts.Shared.Client.Models.BadgeConditionSchema"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::Zeno.Artifacts.Shared.Client.Models.BadgeConditionSchema CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::Zeno.Artifacts.Shared.Client.Models.BadgeConditionSchema();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "code", n => { Code = n.GetStringValue(); } },
                { "quantity", n => { Quantity = n.GetObjectValue<global::Zeno.Artifacts.Shared.Client.Models.BadgeConditionSchema.BadgeConditionSchema_quantity>(global::Zeno.Artifacts.Shared.Client.Models.BadgeConditionSchema.BadgeConditionSchema_quantity.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("code", Code);
            writer.WriteObjectValue<global::Zeno.Artifacts.Shared.Client.Models.BadgeConditionSchema.BadgeConditionSchema_quantity>("quantity", Quantity);
            writer.WriteAdditionalData(AdditionalData);
        }
        /// <summary>
        /// Composed type wrapper for classes <see cref="global::Zeno.Artifacts.Shared.Client.Models.BadgeConditionSchema_quantityMember1"/>, <see cref="int"/>
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class BadgeConditionSchema_quantity : IComposedTypeWrapper, IParsable
        {
            /// <summary>Composed type representation for type <see cref="global::Zeno.Artifacts.Shared.Client.Models.BadgeConditionSchema_quantityMember1"/></summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public global::Zeno.Artifacts.Shared.Client.Models.BadgeConditionSchema_quantityMember1? BadgeConditionSchemaQuantityMember1 { get; set; }
#nullable restore
#else
            public global::Zeno.Artifacts.Shared.Client.Models.BadgeConditionSchema_quantityMember1 BadgeConditionSchemaQuantityMember1 { get; set; }
#endif
            /// <summary>Composed type representation for type <see cref="int"/></summary>
            public int? Integer { get; set; }
            /// <summary>
            /// Creates a new instance of the appropriate class based on discriminator value
            /// </summary>
            /// <returns>A <see cref="global::Zeno.Artifacts.Shared.Client.Models.BadgeConditionSchema.BadgeConditionSchema_quantity"/></returns>
            /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
            public static global::Zeno.Artifacts.Shared.Client.Models.BadgeConditionSchema.BadgeConditionSchema_quantity CreateFromDiscriminatorValue(IParseNode parseNode)
            {
                _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
                var result = new global::Zeno.Artifacts.Shared.Client.Models.BadgeConditionSchema.BadgeConditionSchema_quantity();
                if(parseNode.GetIntValue() is int integerValue)
                {
                    result.Integer = integerValue;
                }
                else {
                    result.BadgeConditionSchemaQuantityMember1 = new global::Zeno.Artifacts.Shared.Client.Models.BadgeConditionSchema_quantityMember1();
                }
                return result;
            }
            /// <summary>
            /// The deserialization information for the current model
            /// </summary>
            /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
            public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
            {
                if(BadgeConditionSchemaQuantityMember1 != null)
                {
                    return ParseNodeHelper.MergeDeserializersForIntersectionWrapper(BadgeConditionSchemaQuantityMember1);
                }
                return new Dictionary<string, Action<IParseNode>>();
            }
            /// <summary>
            /// Serializes information the current object
            /// </summary>
            /// <param name="writer">Serialization writer to use to serialize this model</param>
            public virtual void Serialize(ISerializationWriter writer)
            {
                _ = writer ?? throw new ArgumentNullException(nameof(writer));
                if(Integer != null)
                {
                    writer.WriteIntValue(null, Integer);
                }
                else {
                    writer.WriteObjectValue<global::Zeno.Artifacts.Shared.Client.Models.BadgeConditionSchema_quantityMember1>(null, BadgeConditionSchemaQuantityMember1);
                }
            }
        }
    }
}
#pragma warning restore CS0618
