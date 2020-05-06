﻿using System;
using System.IO;

namespace SatisfactorySaveParser.Save.Properties
{
    public class ObjectProperty : SerializedProperty, IObjectPropertyValue
    {
        public const string TypeName = nameof(ObjectProperty);
        public override string PropertyType => TypeName;

        public override Type BackingType => typeof(ObjectReference);
        public override object BackingObject => Reference;

        public override int SerializedLength => Reference.SerializedLength;

        public ObjectReference Reference { get; set; }

        public ObjectProperty(string propertyName, int index = 0) : base(propertyName, index)
        {
        }

        public override string ToString()
        {
            return $"Object {PropertyName}: {Reference}";
        }

        public static ObjectProperty Deserialize(BinaryReader reader, string propertyName, int index)
        {
            var result = new ObjectProperty(propertyName, index);

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
