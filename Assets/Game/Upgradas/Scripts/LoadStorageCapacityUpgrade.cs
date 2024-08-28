using Zenject;

namespace Upgrades
{
public sealed class LoadStorageCapacityUpgrade : Upgrade
{
	private ConveyorModel _conveyorModel;

	[Inject]
	public void Construct(ConveyorModel conveyorModel)
	{
		_conveyorModel = conveyorModel;
	}

	public LoadStorageCapacityUpgrade(UpgradeConfig config) : base(config)
	{
	}

	public override void OnLevelUp(int i)
	{
		_conveyorModel.LoadStorageCapacity.Value += i; // TODO make upgrade table if not too lazy
	}
}
}