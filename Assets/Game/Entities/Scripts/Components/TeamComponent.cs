namespace Entities
{
	public sealed class TeamComponent : IComponent
	{
		public Team Team;

		public TeamComponent(Team team)
		{
			Team = team;
		}
	}

    public enum Team : byte
    {
        Blue,
        Red
    }
}