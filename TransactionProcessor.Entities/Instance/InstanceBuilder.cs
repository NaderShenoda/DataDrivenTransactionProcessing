using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransactionProcessor.Entities.Instance
{
    public static class InstanceBuilder
    {
        public static ComplexDataFieldInstance BuildDataInstance(this DataDefinitionTree dataDefinitionTree)
        {
            if (dataDefinitionTree == null)
            {
                throw new ArgumentNullException(nameof(dataDefinitionTree));
            }
            var dataDefinitionInstance = new ComplexDataFieldInstance
            {
                DataDefinition = dataDefinitionTree,
                ComplexValue = dataDefinitionTree.Fields.Select<DataDefinitionTree, DataFieldInstanceBase>(field =>
                {
                    if (field.Definition.IsArray)
                    {
                        return new ArrayDataFieldInstance { DataDefinition = field };
                    }
                    else if (field.Fields.Any())
                    {
                        return field.BuildDataInstance();
                    }
                    return new SimpleDataFieldInstance { DataDefinition = field };
                }).ToList()
            };
            return dataDefinitionInstance;
        }

        public static DataFieldInstanceBase StripChildren(this DataFieldInstanceBase dataFieldInstance)
        {
            if (dataFieldInstance == null)
            {
                throw new ArgumentNullException(nameof(dataFieldInstance));
            }
            dataFieldInstance.DataDefinition.Fields = Enumerable.Empty<DataDefinitionTree>();
            if (dataFieldInstance is ComplexDataFieldInstance complexDataFieldInstance)
            {
                foreach (var field in complexDataFieldInstance.ComplexValue)
                {
                    field.StripChildren();
                }
            }
            if (dataFieldInstance is ArrayDataFieldInstance arrayDataFieldInstance)
            {
                foreach (var field in arrayDataFieldInstance.ArrayValue)
                {
                    field.StripChildren();
                }
            }
            return dataFieldInstance;
        }
    }
}
