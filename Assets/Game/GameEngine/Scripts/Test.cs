using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particleSystem;
    [ShowInInspector]
    public bool alive;
    [ShowInInspector]
    public bool emitting;
    [ShowInInspector]

    public bool isplaying;
    [ShowInInspector]

    public bool ispaused;

    [Button]
    public void PlayPS() => _particleSystem.Play();

    private void Update()
    {
      alive = _particleSystem.IsAlive();
      emitting = _particleSystem.isEmitting;

      isplaying = _particleSystem.isPaused;

      ispaused = _particleSystem.isPaused;
    }
}
