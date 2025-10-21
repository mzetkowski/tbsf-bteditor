using System;
using System.Collections.Generic;
using TurnBasedStrategyFramework.Common.AI.Evaluators;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime.Nodes
{
    /// <summary>
    /// Represents a runtime graph node that instantiates a <see cref="IPositionEvaluator"/> with resolved parameters.
    /// </summary>
    [Serializable]
    public abstract class RuntimePositionEvaluatorGraphNode
    {
        public abstract IPositionEvaluator GetEvaluator(Dictionary<string, ProfileVariableBinding> parameters);
    }
}