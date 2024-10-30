using Game.Engine;
using UnityEngine;

namespace Game.Content
{
    public sealed class Character : MonoBehaviour
    {
        [Header("Movement")]
        public MoveComponent MoveComponent;

        public LookComponent LookComponent;

        [Header("Harvesting")]
        public HarvestComponent HarvestComponent;

        public OverlapSphereComponent OverlapSphereComponent;

        public TakeResourceComponent TakeResourceComponent;

        [Header("Storage")]
        public ResourceStorageComponent ResourceStorage;
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
            LookComponent.Direction = MoveComponent.MoveDirection;
        }

        private void Start()
        {
            HarvestComponent.AddCondition(ResourceStorage.IsNotFull);
            HarvestComponent.SetProcessAction(this.RaycastResources);
        }

        private void RaycastResources()
        {
            OverlapSphereComponent.OverlapSphere(this.HarvestResource);
        }

        private bool HarvestResource(GameObject target)
        {
            return target.CompareTag(GameObjectTags.Tree) &&
                   target.activeSelf &&
                   TakeResourceComponent.TakeResources(target);
        }
    }
}