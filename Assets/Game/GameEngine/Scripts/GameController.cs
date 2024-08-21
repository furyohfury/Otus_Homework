using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Systems _systems;
    private EntityManager _entityManager;

    private void Start()
    {
        Application.targetFrameRate = 60;
        
        // get a reference to the contexts
        var contexts = Contexts.sharedInstance;
        _entityManager = new EntityManager();
        _entityManager.Initialize(contexts);

        _systems = new Feature("Systems")
            .Add(new TargetDeadSystem(contexts))
            .Add(new TargetDetectionSystem(contexts))
            .Add(new TargetChaseSystem(contexts))
            .Add(new LookAtTargetSystem(contexts))
            .Add(new TargetInRangeSystem(contexts))
            .Add(new AttackTimerSystem(contexts))
            .Add(new MeleeAttackRequestSystem(contexts))
            .Add(new RangeAttackRequestSystem(contexts))           
            .Add(new SpawnRequestSystem(contexts, _entityManager)) 
            .Add(new MoveSystem(contexts))
            
            // View Systems            
            .Add(new RenderPositionSystem(contexts))
            .Add(new AnimatorMovingListenerSystem(contexts.game))
            .Add(new AnimatorMeleeAttackListenerSystem(contexts))
            .Add(new AnimatorRangeAttackListenerSystem(contexts));
        

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