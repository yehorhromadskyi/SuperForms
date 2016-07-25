using System;
using System.Collections.Generic;

namespace SuperToolkit.Core.Navigation
{
    public class SuperMapper
    {
        private Dictionary<Type, object> _typeToAssociateDictionary = new Dictionary<Type, object>();

        private Dictionary<object, Type> _associateToType = new Dictionary<object, Type>();

        public void AddMapping(Type type, object associatedSource)
        {
            _typeToAssociateDictionary.Add(type, associatedSource);
            _associateToType.Add(associatedSource, type);
        }

        public Type GetTypeSource(object associatedSource)
        {
            var typeSource = _associateToType[associatedSource];
            return typeSource;
        }

        public object GetAssociatedSource(Type typeSource)
        {
            var associatedSource = _typeToAssociateDictionary[typeSource];
            return associatedSource;
        }
    }
}
