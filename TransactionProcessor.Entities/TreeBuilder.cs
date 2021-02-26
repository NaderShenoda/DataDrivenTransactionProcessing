using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransactionProcessor.Entities
{
    public static class TreeBuilder
    {
        public static DataDefinitionTree FindDataDefinitionTree(this DataDefinitionTree tree, long id)
        {
            if (tree.Definition.Id == id)
            {
                return tree;
            }
            return tree.Fields.FindDataDefinitionTree(id);
        }

        public static DataDefinitionTree FindDataDefinitionTree(this IEnumerable<DataDefinitionTree> trees, long id)
        {
            foreach (var tree in trees ?? Enumerable.Empty<DataDefinitionTree>())
            {
                var foundTree = tree.FindDataDefinitionTree(id);
                if (foundTree != null)
                {
                    return foundTree;
                }
            }
            return null;
        }

        public static DataDefinitionTree BuildDataDefinitionTree(this IEnumerable<DataDefinition> dataDefinitions, DataDefinition dataDefinition = null, string parentPath = null)
        {
            dataDefinition = dataDefinition ?? dataDefinitions?.Single(definition => !definition.ParentDataDefinitionId.HasValue);
            if (dataDefinition == null)
            {
                throw new ArgumentNullException(nameof(dataDefinition));
            }
            var path = dataDefinition.Path(parentPath);
            var dataDefinitionTree = new DataDefinitionTree
            {
                Definition = dataDefinition,
                Fields = dataDefinitions?
                .Where(definition => definition.ParentDataDefinitionId == dataDefinition?.Id)
                .Select(definition => dataDefinitions.BuildDataDefinitionTree(definition, path))
                .ToArray() ?? Enumerable.Empty<DataDefinitionTree>(),
                Path = path
            };
            return dataDefinitionTree;
        }

        public static string Path(this DataDefinition dataDefinition, string parentPath = null)
        {
            var path = !string.IsNullOrEmpty(parentPath) ? $"{parentPath}.{dataDefinition.Name}" : dataDefinition.Name;
            if (dataDefinition.IsArray)
            {
                path = $"{path}[]";
            }
            return path;
        }
    }
}
