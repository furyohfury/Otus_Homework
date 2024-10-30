using Game.Engine;
using UnityEngine;

namespace Game.Content
{
    public sealed class Character : MonoBehaviour
    {
        [Header("Movement")]
        [field : SerializeField]
        public MoveComponent MoveComponent {get; private set;}

        [SerializeField]
        private LookComponent _lookComponent;

        [Header("Harvesting")]
        [field : SerializeField]
        public HarvestComponent HarvestComponent {get; private set;}

        [SerializeField]
        private OverlapSphereComponent _overlapSphereComponent;

        [SerializeField]
        private TakeResourceComponent _takeResourceComponent;

        [Header("Storage")]
        [field : SerializeField]
        public ResourceStorageComponent ResourceStorage {get; private set;}

        private void OnEnable()
        {
            MoveComponent.OnMove += this.OnMove;
        }

        private void OnDisable()
        {
            MoveComponent.OnMove -= this.OnMove;
        }

        private void OnMove()
        {
            _lookComponent.Direction = MoveComponent.MoveDirection;
        }

        private void Start()
        {
            HarvestComponent.AddCondition(ResourceStorage.IsNotFull);
            HarvestComponent.SetProcessAction(this.RaycastResources);
        }

        private void RaycastResources()
        {
            _overlapSphereComponent.OverlapSphere(this.HarvestResource);
        }

        private bool HarvestResource(GameObject target)
        {
            return target.CompareTag(GameObjectTags.Tree) &&
                   target.activeSelf &&
                   _takeResourceComponent.TakeResources(target);
        }
    }
}