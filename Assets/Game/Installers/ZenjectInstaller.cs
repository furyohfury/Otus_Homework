﻿using System.Collections.Generic;
using Entities;
using EventBus;
using Game.EventBus;
using TMPro;
using UI;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
	public class ZenjectInstaller : MonoInstaller
	{
		[SerializeField]
		private HeroEntity[] _bluePlayerHeroes;
		[SerializeField]
		private HeroEntity[] _redPlayerHeroes;
		[SerializeField]
		private ParticleSystem _damagedParticleSystem;
		[SerializeField]
		private AudioPlayer _audioPlayer;
		[SerializeField]
		private GameObject _freezeEffectPrefab;
		[SerializeField]
		private ParticleSystem _damageAllParticleSystem;
		[SerializeField]
		private ParticleSystem _healParticleSystem;
		[SerializeField]
		private GameObject _projectile;
		[SerializeField]
		private Transform _worldTransform;
		[SerializeField]
		private GameObject _gameOverScreen;
		[SerializeField]
        private TMP_Text _playerText;

		private readonly Dictionary<Player, HeroCollection> _heroCollections = new();

		public override void InstallBindings()
		{
			Application.targetFrameRate = 60;
			// Scene
			Container.Bind<UIService>().FromComponentInHierarchy().AsSingle();
			Container.BindInterfacesAndSelfTo<CurrentHeroService>().AsSingle();
			Container.Bind<AudioPlayer>().FromInstance(_audioPlayer).AsSingle();
			_heroCollections.Add(Player.Blue, new HeroCollection(_bluePlayerHeroes, 0));
			_heroCollections.Add(Player.Red, new HeroCollection(_redPlayerHeroes, _redPlayerHeroes.Length - 1));
			Container.BindInstance(_heroCollections).AsSingle();
			Container.BindInterfacesAndSelfTo<GameOverController>().AsSingle().WithArguments(_gameOverScreen, _playerText);

			// Pipeline
			Container.Bind<VisualPipeline>().AsCached();

			var playerTurnPipeline = new TurnPipeline();
			Container.Bind<TurnPipeline>().FromInstance(playerTurnPipeline).AsCached();
			Container.BindInterfacesAndSelfTo<PlayerTurnPipelineInstaller>().AsCached()
			         .WithArguments(playerTurnPipeline);
			var aiTurnPipeline = new TurnPipeline();
			Container.Bind<TurnPipeline>().FromInstance(aiTurnPipeline).AsCached();
			Container.BindInterfacesAndSelfTo<AITurnPipelineInstaller>().AsCached().WithArguments(aiTurnPipeline);

			Container.BindInterfacesAndSelfTo<GamePipelineRunner>().AsCached();

			// Event bus logic
			Container.Bind<global::EventBus.EventBus>().AsSingle();
			Container.BindInterfacesAndSelfTo<AttackWrongTargetHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<AttackHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<FreezeHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<DamageRandomEnemyHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<DamageAllHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<DealDamageHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<VampiricHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<HealRandomAllyHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<HealHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<RemoveDivineShieldHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<RemoveFrozenHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<DestroyHandler>().AsSingle();

			// Event bus visual
			Container.BindInterfacesAndSelfTo<AttackVisualHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<FreezeVisualHandler>().AsSingle().WithArguments(_freezeEffectPrefab);
			Container.BindInterfacesAndSelfTo<DamageAllVisualHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<DealDamageVisualHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<HealVisualHandler>().AsSingle().WithArguments(_healParticleSystem);
			Container.BindInterfacesAndSelfTo<FireProjectileVisualHandler>().AsSingle().WithArguments(_worldTransform);
			Container.BindInterfacesAndSelfTo<RemoveDivineShieldVisualHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<DamageRandomEnemyVisualHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<HealRandomAllyVisualHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<RemoveFrozenVisualHandler>().AsSingle();
			Container.BindInterfacesAndSelfTo<DestroyVisualHandler>().AsSingle();
		}
	}
}