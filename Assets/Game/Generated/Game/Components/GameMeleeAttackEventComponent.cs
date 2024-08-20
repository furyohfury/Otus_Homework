//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly MeleeAttackEventComponent meleeAttackEventComponent = new MeleeAttackEventComponent();

    public bool isMeleeAttackEvent {
        get { return HasComponent(GameComponentsLookup.MeleeAttackEvent); }
        set {
            if (value != isMeleeAttackEvent) {
                var index = GameComponentsLookup.MeleeAttackEvent;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : meleeAttackEventComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherMeleeAttackEvent;

    public static Entitas.IMatcher<GameEntity> MeleeAttackEvent {
        get {
            if (_matcherMeleeAttackEvent == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MeleeAttackEvent);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMeleeAttackEvent = matcher;
            }

            return _matcherMeleeAttackEvent;
        }
    }
}
