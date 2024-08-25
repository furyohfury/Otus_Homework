using System;
using UnityEngine;
using Zenject;

public class ArrowCollisionDispatcher : MonoBehaviour
{
	[SerializeField]
	private EntityView _view;
	private GameEntity _entity;
	private Contexts _contexts;

	public void Construct()
	{
		_contexts = Contexts.sharedInstance;
		_entity = _view.LinkedEntity;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out EntityView hitTarget))
		{
			var triggerRequest = _contexts.game.CreateEntity();
			triggerRequest.isTriggerEnterRequest = true;
			triggerRequest.isArrowTag = true;
			triggerRequest.AddSourceEntity(_entity);
			triggerRequest.AddTargetEntity(hitTarget.LinkedEntity);
		}
	}
}