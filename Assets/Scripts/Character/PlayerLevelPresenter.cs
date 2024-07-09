using System;
using Sirenix.OdinInspector;
using UniRx;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerLevelPresenter
    {
        public ReactiveProperty<int> Level {get; private set; } = new();
        public ReactiveProperty<string> Experience {get; private set; } = new();

        
    }
}