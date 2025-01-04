namespace Atomic.Elements
{
    public interface IVariable<T> : IValue<T>, ISetter<T>, IValueBase
    {
        new T Value { get; set; }

        T IValue<T>.Value
        {
            get { return this.Value; }
        }

        T ISetter<T>.Value
        {
            set => this.Value = value;
        }
        
        object IValueBase.GetValue() => Value;
        
        void IValueBase.SetValue(object value) => Value = (T) value;
    }
}