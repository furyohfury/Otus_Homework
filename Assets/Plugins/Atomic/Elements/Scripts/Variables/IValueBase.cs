namespace Atomic.Elements
{
	public interface IValueBase
	{
		object GetValue();
		
		void SetValue(object value);
	}
}