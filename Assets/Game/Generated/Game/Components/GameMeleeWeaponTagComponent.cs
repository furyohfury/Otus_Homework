//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly MeleeWeaponTagComponent meleeWeaponTagComponent = new MeleeWeaponTagComponent();

    public bool isMeleeWeaponTag {
        get { return HasComponent(GameComponentsLookup.MeleeWeaponTag); }
        set {
            if (value != isMeleeWeaponTag) {
                var index = GameComponentsLookup.MeleeWeaponTag;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : meleeWeaponTagComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherMeleeWeaponTag;

    public static Entitas.IMatcher<GameEntity> MeleeWeaponTag {
        get {
            if (_matcherMeleeWeaponTag == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MeleeWeaponTag);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMeleeWeaponTag = matcher;
            }

            return _matcherMeleeWeaponTag;
        }
    }
}