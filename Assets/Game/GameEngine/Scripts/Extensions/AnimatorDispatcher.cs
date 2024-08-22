using System;
using System.Collections.Generic;
using UnityEngine;


    public class AnimatorDispatcher : MonoBehaviour
    {
        private readonly Dictionary<string, List<Action>> _actionsDictionary = new();

        public void SubscribeOnEvent(string key, Action action)
        {
            if (!_actionsDictionary.ContainsKey(key))
            {
                _actionsDictionary[key] = new List<Action>();
            }

            _actionsDictionary[key].Add(action);
        }

        public void UnsubscribeOnEvent(string key, Action action)
        {
            if (_actionsDictionary.TryGetValue(key, out var actionsList))
            {
                actionsList.Remove(action);
            }
        }

        //Получаем из анимации
        public void ReceiveEvent(string actionKey)
        {

            if (_actionsDictionary.TryGetValue(actionKey, out var actionsList))
            {
                foreach (var action in actionsList)
                {
                    action?.Invoke();
                }
            }
        }
    }
