using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField]
	private DependencyHelper _dependencyHelper;
	
	private DamagedParticlesHelper _damagedParticlesHelper; // TODO in common config
	private Transform _worldTransform;
	
	private Systems _systems;
	private EntityManager _entityManager;

	private void Start()
	{
		_damagedParticlesHelper = _dependencyHelper.DamagedParticlesHelper;
		_worldTransform = _dependencyHelper.WorldTransform;
		// get a reference to the contexts
		var contexts = Contexts.sharedInstance;
		_entityManager = new EntityManager();
		_entityManager.Initialize(contexts, _worldTransform);

		_systems = new Feature("Systems")
		           .Add(new TargetDeadSystem(contexts))
		           .Add(new TargetDetectionSystem(contexts))
		           .Add(new TargetChaseSystem(contexts))
		           .Add(new LookAtTargetSystem(contexts))
		           .Add(new TargetInRangeSystem(contexts))
		           .Add(new AttackTimerSystem(contexts))
		           .Add(new MeleeAttackRequestSystem(contexts))
		           .Add(new RangeAttackRequestSystem(contexts))
		           .Add(new ShootRequestSystem(contexts))
		           .Add(new SpawnPrefabRequestSystem(contexts, _entityManager))
		           .Add(new MoveSystem(contexts))
		           .Add(new ArrowTriggerEnterRequestSystem(contexts))
		           .Add(new MeleeWeaponTriggerEnterRequestSystem(contexts))
		           .Add(new TakeDamageRequestSystem(contexts))
		           .Add(new HealthEmptySystem(contexts))
		           .Add(new DeathTimerCountdownSystem(contexts))
		           .Add(new DeathRequestSystem(contexts))

		           // View Systems            
		           .Add(new RenderPositionSystem(contexts))
		           .Add(new AnimatorMovingListenerSystem(contexts.game))
		           .Add(new AnimatorMeleeAttackListenerSystem(contexts))
		           .Add(new AnimatorRangeAttackListenerSystem(contexts))
		           .Add(new AnimatorDeathListenerSystem(contexts))
		           .Add(new DamagedAddParticleSystem(contexts, _damagedParticlesHelper, _entityManager))
		           .Add(new DamagedParticlesLifeCycleSystem(contexts, _entityManager))
		           .Add(new DestroyViewSystem(contexts, _entityManager))

		           // Cleanup Systems
		           .Add(new EventsDeleteSystem(contexts));
		
		// call Initialize() on all of the IInitializeSystems
		_systems.Initialize();
	}

	private void Update()
	{
		// call Execute() on all the IExecuteSystems and 
		// ReactiveSystems that were triggered last frame
		_systems.Execute();
		// call cleanup() on all the ICleanupSystems
		_systems.Cleanup();
	}
}