//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly DamagedEventComponent damagedEventComponent = new DamagedEventComponent();

    public bool isDamagedEvent {
        get { return HasComponent(GameComponentsLookup.DamagedEvent); }
        set {
            if (value != isDamagedEvent) {
                var index = GameComponentsLookup.DamagedEvent;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : damagedEventComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherDamagedEvent;

    public static Entitas.IMatcher<GameEntity> DamagedEvent {
        get {
            if (_matcherDamagedEvent == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DamagedEvent);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDamagedEvent = matcher;
            }

            return _matcherDamagedEvent;
        }
    }
}
