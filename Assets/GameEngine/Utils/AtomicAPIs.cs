namespace GameEngine
{
    public static class MoveAPI
    {
        public const string MOVE_DIRECTION = nameof(MOVE_DIRECTION);
    }

    public static class LifeAPI
    {
        public const string TAKE_DAMAGE_ACTION = nameof(TAKE_DAMAGE_ACTION);
        public const string IS_ALIVE = nameof(IS_ALIVE);
        public const string HIT_POINTS = nameof(HIT_POINTS);
    }

    public class ShootAPI
    {
        public const string SHOOT_REQUEST = nameof(SHOOT_REQUEST);
    }

    public class RotateAPI
    {
        public const string LOOK_DIRECTION = nameof(LOOK_DIRECTION);
    }

    public class WeaponMagAPI
    {
        public const string CURRENT_BULLET_COUNT = nameof(CURRENT_BULLET_COUNT);
        public const string MAX_BULLET_COUNT = nameof(MAX_BULLET_COUNT);
    }

    public class PositionAPI
    {
        public const string ROOT_POSITION = nameof(ROOT_POSITION);
    }
}
