//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AttackCooldownComponent attackCooldown { get { return (AttackCooldownComponent)GetComponent(GameComponentsLookup.AttackCooldown); } }
    public bool hasAttackCooldown { get { return HasComponent(GameComponentsLookup.AttackCooldown); } }

    public void AddAttackCooldown(float newValue) {
        var index = GameComponentsLookup.AttackCooldown;
        var component = (AttackCooldownComponent)CreateComponent(index, typeof(AttackCooldownComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAttackCooldown(float newValue) {
        var index = GameComponentsLookup.AttackCooldown;
        var component = (AttackCooldownComponent)CreateComponent(index, typeof(AttackCooldownComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAttackCooldown() {
        RemoveComponent(GameComponentsLookup.AttackCooldown);
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

    static Entitas.IMatcher<GameEntity> _matcherAttackCooldown;

    public static Entitas.IMatcher<GameEntity> AttackCooldown {
        get {
            if (_matcherAttackCooldown == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AttackCooldown);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAttackCooldown = matcher;
            }

            return _matcherAttackCooldown;
        }
    }
}