using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private EntityView _view;

    [Button]
    public void HasMoveDirection()
    {
        Debug.Log(_view.LinkedEntity.animatorView.Value.GetBool("IsMoving"));
        Debug.Log(_view.LinkedEntity.hasMoveDirection.ToString());
    }
}
