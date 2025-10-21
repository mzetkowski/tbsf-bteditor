using System;
using System.Collections.Generic;
using TurnBasedStrategyFramework.Common.AI.BehaviourTrees;
using UnityEngine;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes
{
    /// <summary>
    /// Root node of a runtime behaviour tree graph. 
    /// Serves as the tree entry point and delegates execution to its single child node.
    /// </summary>
    [Serializable]
    public class RuntimeRootGraphNode : RuntimeGraphNode
    {
        [SerializeReference] private RuntimeGraphNode _child;

        public RuntimeRootGraphNode(RuntimeGraphNode child)
        {
            _child = child;
        }

        public override ITreeNode Process(Dictionary<string, ProfileVariableBinding> parameters)
        {
            return _child.Process(parameters);
        }
    }
}