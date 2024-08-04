using System;
using Atomic.Elements;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public class RotationComponent
    {
        public AtomicEvent<Vector3> RotateAction;
        public Rigidbody RotationRoot => _rotationRoot;
        public IAtomicExpression<bool> CanRotate;

        [SerializeField] 
        private Rigidbody _rotationRoot;
        [SerializeField] 
        private AtomicVariable<float> _rotateRate;               

        private RotateMechanics _rotateMechanics;

        public void Compose(IAtomicExpression<bool> canRotate)
        {
            CanRotate = canRotate;
            _rotateMechanics = new(RotateAction, _rotateRate, _rotationRoot, CanRotate);
        }        
    }
}