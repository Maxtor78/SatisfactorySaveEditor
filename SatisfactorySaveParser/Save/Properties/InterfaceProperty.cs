﻿using System;
using System.IO;

namespace SatisfactorySaveParser.Save.Properties
{
    public class InterfaceProperty : SerializedProperty, IInterfacePropertyValue
    {
        public const string TypeName = nameof(InterfaceProperty);
        public override string PropertyType => TypeName;

        public override Type BackingType => typeof(ObjectReference);
        public override object BackingObject => Reference;

        public override int SerializedLength => Reference.SerializedLength;

        public ObjectReference Reference { get; set; }

        public InterfaceProperty(string propertyName, int index = 0) : base(propertyName, index)
        {
        }

        public override string ToString()
        {
            return $"Interface {PropertyName}: {Reference}";
        }

        public static InterfaceProperty Deserialize(BinaryReader reader, string propertyName, int index)
        {
            var result = new InterfaceProperty(propertyName, index);

            reader.AssertNullByte();
            result.Reference = reader.ReadObjectReference();

            return result;
        }

        public override void Serialize(BinaryWriter writer)
        {
            writer.Write((byte)0);
            writer.Write(Reference);
        }
    }
}
