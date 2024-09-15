using System;
using Entities;
using EventBus;
using Zenject;

public sealed class CurrentHeroService : ICurrentHeroService// TODO make everything through interface
{
	public HeroEntity CurrentHero => _currentHero;
	public Player CurrentPlayer => _currentPlayer;
	private HeroEntity _currentHero;
	private Player _currentPlayer;

	public void SetCurrentHero(HeroEntity heroEntity) => _currentHero = heroEntity;
	public void SetCurrentPlayer(Player player) => _currentPlayer = player;
}