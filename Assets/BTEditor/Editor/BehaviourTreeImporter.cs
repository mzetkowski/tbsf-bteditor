using System.Linq;
using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Editor.Nodes;
using TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Runtime;
using Unity.GraphToolkit.Editor;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace TurnBasedStrategyFramework.Unity.BehaviourTreeEditor.Editor
{
    /// <summary>
    /// Imports a BehaviourTreeGraph asset (.btg) and generates a corresponding runtime asset.
    /// Converts editor nodes into a runtime BehaviourTreeRuntimeGraph and serializes its variables.
    /// </summary>
    [ScriptedImporter(1, BehaviourTreeGraph.AssetExtension)]
    class BehaviourTreeImporter : ScriptedImporter
    {
        public override void OnImportAsset(AssetImportContext ctx)
        {
            var graph = GraphDatabase.LoadGraphForImporter<BehaviourTreeGraph>(ctx.assetPath);
            if (graph == null)
            {
                Debug.LogError($"Failed to load Behaviour Tree graph asset: {ctx.assetPath}");
                return;
            }

            var startNodeModel = graph.GetNodes().OfType<RootGraphNode>().FirstOrDefault();
            if (startNodeModel == null)
            {
                return;
            }
            var runtimeAsset = ScriptableObject.CreateInstance<BehaviourTreeRuntimeGraph>();

            runtimeAsset.RootGraphNode = startNodeModel.ToRuntimeGraphNode();
            runtimeAsset.Variables = graph.GetVariables().Select(v => new GraphVariable(v.name, v.dataType.AssemblyQualifiedName)).ToList();
            ctx.AddObjectToAsset("RuntimeAsset", runtimeAsset);
            ctx.SetMainObject(runtimeAsset);
        }
    }
}
