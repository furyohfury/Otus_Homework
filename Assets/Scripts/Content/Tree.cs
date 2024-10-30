using Game.Engine;
using UnityEngine;

namespace Game.Content
{
    public sealed class Tree : MonoBehaviour
    {
        private static readonly int ChopAnimHash = Animator.StringToHash("Chop");

        [field : SerializeField]
        public ResourceStorageComponent Storage {get; private set;}

        [SerializeField]
        private Animator _animator;        

        private void OnEnable()
        {
            this.Storage.OnStateChanged += this.OnStateChanged;
        }

        private void OnDisable()
        {
            this.Storage.OnStateChanged -= this.OnStateChanged;
        }

        private void OnStateChanged()
        {
            if (this.Storage.IsEmpty())
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                _animator.Play(ChopAnimHash, -1, 0);
            }
        }
    }
}