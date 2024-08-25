//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public BuildingDamagedParticleSystemComponent buildingDamagedParticleSystem { get { return (BuildingDamagedParticleSystemComponent)GetComponent(GameComponentsLookup.BuildingDamagedParticleSystem); } }
    public bool hasBuildingDamagedParticleSystem { get { return HasComponent(GameComponentsLookup.BuildingDamagedParticleSystem); } }

    public void AddBuildingDamagedParticleSystem(UnityEngine.ParticleSystem newSmall, UnityEngine.ParticleSystem newBig) {
        var index = GameComponentsLookup.BuildingDamagedParticleSystem;
        var component = (BuildingDamagedParticleSystemComponent)CreateComponent(index, typeof(BuildingDamagedParticleSystemComponent));
        component.Small = newSmall;
        component.Big = newBig;
        AddComponent(index, component);
    }

    public void ReplaceBuildingDamagedParticleSystem(UnityEngine.ParticleSystem newSmall, UnityEngine.ParticleSystem newBig) {
        var index = GameComponentsLookup.BuildingDamagedParticleSystem;
        var component = (BuildingDamagedParticleSystemComponent)CreateComponent(index, typeof(BuildingDamagedParticleSystemComponent));
        component.Small = newSmall;
        component.Big = newBig;
        ReplaceComponent(index, component);
    }

    public void RemoveBuildingDamagedParticleSystem() {
        RemoveComponent(GameComponentsLookup.BuildingDamagedParticleSystem);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherBuildingDamagedParticleSystem;

    public static Entitas.IMatcher<GameEntity> BuildingDamagedParticleSystem {
        get {
            if (_matcherBuildingDamagedParticleSystem == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BuildingDamagedParticleSystem);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBuildingDamagedParticleSystem = matcher;
            }

            return _matcherBuildingDamagedParticleSystem;
        }
    }
}