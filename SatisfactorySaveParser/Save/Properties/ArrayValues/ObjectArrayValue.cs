﻿using System;
using System.IO;

namespace SatisfactorySaveParser.Save.Properties.ArrayValues
{
    public class ObjectArrayValue : IObjectPropertyValue, IArrayElement
    {
        public ObjectReference Reference { get; set; }

        public void ArraySerialize(BinaryWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
