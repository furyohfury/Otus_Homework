//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly RangeAttackEventComponent rangeAttackEventComponent = new RangeAttackEventComponent();

    public bool isRangeAttackEvent {
        get { return HasComponent(GameComponentsLookup.RangeAttackEvent); }
        set {
            if (value != isRangeAttackEvent) {
                var index = GameComponentsLookup.RangeAttackEvent;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : rangeAttackEventComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherRangeAttackEvent;

    public static Entitas.IMatcher<GameEntity> RangeAttackEvent {
        get {
            if (_matcherRangeAttackEvent == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RangeAttackEvent);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRangeAttackEvent = matcher;
            }

            return _matcherRangeAttackEvent;
        }
    }
}
