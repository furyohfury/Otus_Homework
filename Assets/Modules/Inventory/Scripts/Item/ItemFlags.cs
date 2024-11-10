using System;

namespace Lessons.Meta.Lesson_Inventory
{
    [Flags]
    public enum ItemFlags
    {
        None = 0,
        Consumable = 1,
        Stackable = 2,
        Effectible = 4,
    }
}