namespace EventBus
{   
    public sealed class FreezeHandler : BaseHandler<FreezeEvent>
	{
		[Inject]
		public FreezeHandler(EventBus eventBus) : base(eventBus)
		{
		}

		protected override void OnHandleEvent(FreezeEvent evt)
		{
			Debug.Log($"Freeze handled.Target: {evt.Target.gameObject.name}");
            evt.Target.AddData(new FreezeComponent());
		}
	}
}