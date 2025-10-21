using System;
using System.Collections.Generic;
using TurnBasedStrategyFramework.Common.AI.BehaviourTrees;
using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes;
using UnityEngine;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime
{
    /// <summary>
    /// Runtime template for a behaviour tree graph. 
    /// </summary>
    public class BehaviourTreeRuntimeGraph : ScriptableObject
    {
        [SerializeReference] public RuntimeGraphNode RootGraphNode;
        public List<GraphVariable> Variables;
        public ITreeNode GetRuntimeTree(Dictionary<string, ProfileVariableBinding> parameters)
        {
            return RootGraphNode.Process(parameters);
        }
    }

    /// <summary>
    /// Metadata for a variable declared in a behaviour tree graph: its name and AssemblyQualifiedName type.
    /// Used by the importer and editor to build runtime variable lists and perform simple type validation.
    /// </summary>
    [Serializable]
    public class GraphVariable
    {
        [field: SerializeField] public string Name { get; set; }
        [field: SerializeField] public string TypeAssemblyQualifiedName { get; set; }

        public GraphVariable(string name, string typeAssemblyQualifiedName)
        {
            Name = name;
            TypeAssemblyQualifiedName = typeAssemblyQualifiedName;
        }
    }
}