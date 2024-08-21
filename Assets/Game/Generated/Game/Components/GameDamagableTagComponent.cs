//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly DamagableTagComponent damagableTagComponent = new DamagableTagComponent();

    public bool isDamagableTag {
        get { return HasComponent(GameComponentsLookup.DamagableTag); }
        set {
            if (value != isDamagableTag) {
                var index = GameComponentsLookup.DamagableTag;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : damagableTagComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherDamagableTag;

    public static Entitas.IMatcher<GameEntity> DamagableTag {
        get {
            if (_matcherDamagableTag == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DamagableTag);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDamagableTag = matcher;
            }

            return _matcherDamagableTag;
        }
    }
}
