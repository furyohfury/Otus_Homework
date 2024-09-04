using UI;

namespace Entities
{
    public sealed class HeroViewComponent : IComponent
    {
        public readonly HeroView HeroView;

        public HeroViewComponent(HeroView view)
        {
            HeroView = view;
        }
    }
}