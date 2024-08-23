public sealed partial class GameMatcher {

	static Entitas.IMatcher<GameEntity> _matcherTeam;

	public static Entitas.IMatcher<GameEntity> Team {
		get {
			if (_matcherTeam == null) {
				var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Team);
				matcher.componentNames = GameComponentsLookup.componentNames;
				_matcherTeam = matcher;
			}

			return _matcherTeam;
		}
	}
}