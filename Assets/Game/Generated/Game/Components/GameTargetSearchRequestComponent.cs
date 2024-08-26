//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly TargetSearchRequestComponent targetSearchRequestComponent = new TargetSearchRequestComponent();

    public bool isTargetSearchRequest {
        get { return HasComponent(GameComponentsLookup.TargetSearchRequest); }
        set {
            if (value != isTargetSearchRequest) {
                var index = GameComponentsLookup.TargetSearchRequest;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : targetSearchRequestComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherTargetSearchRequest;

    public static Entitas.IMatcher<GameEntity> TargetSearchRequest {
        get {
            if (_matcherTargetSearchRequest == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TargetSearchRequest);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTargetSearchRequest = matcher;
            }

            return _matcherTargetSearchRequest;
        }
    }
}
