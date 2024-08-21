using UnityEngine;
using Zenject;

public class ArrowCollisionDispatcher : MonoBehaviour
{
	[SerializeField]
	private GameEntity _entity;

	private Contexts _contexts;

	private void Awake()
	{
		_entity = GetComponent<EntityView>().LinkedEntity;
	}

	[Inject]
	public void Construct(Contexts contexts)
	{
		_contexts = contexts;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out EntityView entityView))
		{
			var triggerRequest = _contexts.game.CreateEntity();
			triggerRequest.isTriggerEnterRequest = true;
			triggerRequest.AddSourceEntity(_entity);
			triggerRequest.AddTargetEntity(entityView.LinkedEntity);
		}
	}
}