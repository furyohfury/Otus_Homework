using UniRx;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public interface IUserPresenter : IPresenter
    {
        public ReactiveProperty<string> Name { get; }
        public ReactiveProperty<string> Description { get; }
        public ReactiveProperty<Sprite> Icon { get; }
    }
}