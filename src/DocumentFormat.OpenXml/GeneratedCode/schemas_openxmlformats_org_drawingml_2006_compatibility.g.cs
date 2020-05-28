﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Framework;
using DocumentFormat.OpenXml.Framework.Metadata;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Validation.Schema;
using DocumentFormat.OpenXml.Validation.Semantic;
using System;
using System.Collections.Generic;
using System.IO.Packaging;

namespace DocumentFormat.OpenXml.Drawing.LegacyCompatibility
{
    /// <summary>
    /// <para>Legacy Drawing Object.</para>
    /// <para>This class is available in Office 2007 or above.</para>
    /// <para>When the object is serialized out as xml, it's qualified name is comp:legacyDrawing.</para>
    /// </summary>
    public partial class LegacyDrawing : OpenXmlLeafElement
    {
        /// <summary>
        /// Initializes a new instance of the LegacyDrawing class.
        /// </summary>
        public LegacyDrawing() : base()
        {
        }

        /// <summary>
        /// <para>Shape ID</para>
        /// <para>Represents the following attribute in the schema: spid</para>
        /// </summary>
        public StringValue ShapeId
        {
            get => GetAttribute<StringValue>();
            set => SetAttribute(value);
        }

        internal override void ConfigureMetadata(ElementMetadata.Builder builder)
        {
            base.ConfigureMetadata(builder);
            builder.SetSchema(13, "legacyDrawing");
            builder.AddElement<LegacyDrawing>()
.AddAttribute(0, "spid", a => a.ShapeId, aBuilder =>
{
aBuilder.AddValidator(new RequiredValidatorAttribute());
aBuilder.AddValidator(new StringValidatorAttribute() { IsToken = (true) });
});
        }

        private static readonly ISemanticConstraint[] _semanticConstraint = new ISemanticConstraint[] {
            new UniqueAttributeValueConstraint(0 /*:spid*/, true, null)
        };

        internal override ISemanticConstraint[] SemanticConstraints => _semanticConstraint;

        /// <inheritdoc/>
        public override OpenXmlElement CloneNode(bool deep) => CloneImp<LegacyDrawing>(deep);
    }
}