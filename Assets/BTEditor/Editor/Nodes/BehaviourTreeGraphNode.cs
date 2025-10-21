using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes;
using Unity.GraphToolkit.Editor;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Editor.Nodes
{
    /// <summary>
    /// Base class for editor graph nodes representing behaviour tree nodes.
    /// Provides a method to convert the editor node into its corresponding runtime representation.
    /// </summary>
    public abstract class BehaviourTreeGraphNode : Node
    {
        /// <summary>
        /// Converts this editor graph node into a runtime graph node for execution.
        /// </summary>
        /// <returns>Corresponding RuntimeGraphNode instance.</returns>
        public abstract RuntimeGraphNode ToRuntimeGraphNode();
    }
}