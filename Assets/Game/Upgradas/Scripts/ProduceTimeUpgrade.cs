using Zenject;

namespace Upgrades
{
public sealed class ProduceTimeUpgrade : Upgrade
{
	private ConveyorModel _conveyorModel;

	[Inject]
	public void Construct(ConveyorModel conveyorModel)
	{
		_conveyorModel = conveyorModel;
	}

	public ProduceTimeUpgrade(UpgradeConfig config) : base(config)
	{
	}

	public override void OnLevelUp(int i)
	{
		_conveyorModel.ProduceTime.Value -= i; // TODO make upgrade table if not too lazy
	}
}
}