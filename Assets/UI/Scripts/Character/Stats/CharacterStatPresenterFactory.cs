namespace Lessons.Architecture.PM
{
    public sealed class CharacterStatPresenterFactory
    {
        public CharacterStatPresenter Create(CharacterStat characterStat) => new CharacterStatPresenter(characterStat);
    }
}