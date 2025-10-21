using UnityEngine;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime
{
    /// <summary>
    /// Provides a value source for runtime graph nodes: either a baked constant (Value) or a lookup into the runtime
    /// parameters dictionary (VariableName). Runtime nodes use this to obtain the actual input value by checking PassedByVariable
    /// and resolving from parameters when true, or using the stored Value when false.
    /// </summary>
    public class RuntimeValueReference<T>
    {
        [field: SerializeField] public T Value { get; set; }
        [field: SerializeField] public bool PassedByVariable { get; set; }
        [field: SerializeField] public string VariableName { get; set; }
    }
}