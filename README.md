# Behaviour Tree Editor

A visual editor extension for creating and managing Behaviour Trees used by the **Turn Based Strategy Framework** in Unity.  
This package is **not a standalone system** — it enhances the Turn Based Strategy Framework by providing a visual workflow for authoring AI logic.

## Requirements

* Unity >= 6.2  
* Turn Based Strategy Framework >= 4.0.2  
* Graph Toolkit == 0.4.0-exp.2  

## Installation

1. Install the Graph Toolkit, as described here: [Graph Toolkit Installation Guide](https://docs.unity3d.com/Packages/com.unity.graphtoolkit@0.4/manual/installation.html)
2. Download and import the latest release package from this repository.

## Getting Started

The project includes a ready-to-use `RegularBehaviourTreeGraph` and a corresponding `RegularBehaviourTreeProfile`.  
This AI behaves the same as the `RegularBehaviourTreeResource` included in the Turn Based Strategy Framework.

To quickly test the setup:

1. Open the unit prefab and add an empty child GameObject.  
2. Add a `BehaviourTreeProfileAdapter` component to the new GameObject.  
3. Assign the `BTEditor/RegularBehaviourTreeProfile` to the **Profile** field.  
4. Assign the `BehaviourTreeProfileAdapter` to the **BehaviourTreeResource** field on your Unit prefab.  

The unit will now use the `RegularBehaviourTreeProfile` as its AI.

For creating your own trees and profiles, see the sections below.

## Creating Behaviour Tree Graphs

A Behaviour Tree defines decision-making logic as a hierarchy of nodes that control how an AI agent acts.  
Understanding how Behaviour Trees work conceptually is beyond the scope of this README — basic familiarity is assumed.  
The Turn Based Strategy Framework includes an implementation of Behaviour Tree–based AI, but by default these trees must be authored in code.  
This editor provides a visual alternative.

### Basic Concepts

- **Behaviour Tree Graph** – An asset edited in the Graph Toolkit editor.  
  Create via: `Create → Turn Based Strategy Framework → Behaviour Tree Graph`
- **Behaviour Tree Profile** – A ScriptableObject that instantiates a specific Behaviour Tree Graph and provides parameterization for runtime use.  
  Create via: `Create → Turn Based Strategy Framework → Behaviour Tree Profile`
- **Behaviour Tree Profile Adapter** – A component that attaches a Behaviour Tree Profile to a unit.
- **Nodes** – The functional elements of the tree.  
  The project includes implementations of all standard node types provided by the Turn Based Strategy Framework.

### Building the Graph

The editor interface is powered by the Graph Toolkit.  
You can create and connect nodes, define variables on the blackboard, and arrange the graph visually.  
For detailed guidance on Graph Toolkit usage, see the official documentation:  
[Graph Toolkit Manual](https://docs.unity3d.com/Packages/com.unity.graphtoolkit@0.4/manual/introduction.html)

1. Create a new graph via `Create → Turn Based Strategy Framework → Behaviour Tree Graph`.  
   Double-click the new asset to open it for editing.
2. Add and connect nodes to define behaviour logic.
   > **⚠️Important**: Each graph must start with a `RootGraphNode`.
3. Save the graph.

### Creating Behaviour Tree Profiles

A graph acts as a template. Profiles create specific instances of that graph with adjustable parameters.  
For example, you can derive multiple unit AIs—aggressive, defensive, cautious—by changing the profile’s variable values.

1. Create a new profile via `Create → Turn Based Strategy Framework → Behaviour Tree Profile`.  
2. Assign the desired Behaviour Tree Graph to the **Template** field.  
3. Adjust parameter values in the inspector.

### Assigning Behaviour Tree Profiles to Units

Repeat the same setup used in *Getting Started* for your custom profiles:

1. Open the unit prefab and add an empty child GameObject.  
2. Add a `BehaviourTreeProfileAdapter` component.  
3. Assign your chosen profile (for example, `BTEditor/RegularBehaviourTreeProfile`) to the **Profile** field.  
4. Assign the `BehaviourTreeProfileAdapter` to the **BehaviourTreeResource** field on the Unit prefab.  

The unit will now use the selected Behaviour Tree Profile at runtime.

## Development

To contribute to the development of the Behaviour Tree Editor:

1. Clone this repository **into your Turn Based Strategy Framework project folder**.  
2. Open the project in Unity.  
3. Make your changes.  
4. Submit a pull request.

## FAQ

**Q:** Why isn’t the editor included directly in the framework?  
**A:** The Graph Toolkit is an experimental package. I don’t want to require users to install experimental dependencies. Once a stable release is available, I will consider adding it directly to the project.

**Q:** Getting  
```
NullReferenceException: Object reference not set to an instance of an object
TurnBasedStrategyFramework.Unity.Units.Unit.get_BehaviourTree()
```
**A:** You didn’t reassign the brain to the `unit.BehaviourTreeResource` field.

**Q:** I wrote a custom node and parameter values aren’t being passed to runtime nodes.  
**A:** Make sure to add `[SerializeField]` to value fields and `[SerializeReference]` to reference fields in your runtime node classes.

**Q:** I added `[SerializeField]`, but parameter values are still not being passed.  
**A:** Save the graph again so Unity reimports it.

## Support

If you have any questions, feedback, or need assistance with the Behaviour Tree Editor, feel free to reach out. You can contact me directly via email at crookedhead@outlook.com for specific queries or suggestions. Additionally, for broader community support and discussions, join the TBSF Discord server: [TBSF Discord](https://discord.gg/uBJNPJHFjB). This platform is ideal for connecting with other TBSF users, sharing experiences, and getting help from the community.
