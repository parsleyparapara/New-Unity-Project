using UnityEngine;

public sealed class EnterMineAndDigForNugget :  FSMState<Miner> {
	
	//データメンバー(インスタンス)
	static readonly EnterMineAndDigForNugget instance = new EnterMineAndDigForNugget();
	//メンバー関数
	public static EnterMineAndDigForNugget Instance {
		get {
			return instance;
		}
	}
	static EnterMineAndDigForNugget() { }
	private EnterMineAndDigForNugget() { }
	
		
	public override void Enter (Miner m) {
		if (m.Location != Locations.goldmine) {
			Debug.Log("鉱山にはいるぞ！");
			m.ChangeLocation(Locations.goldmine);
		}
	}
	
	public override void Execute (Miner m) {		
		m.AddToGoldCarried(1);
		Debug.Log("金塊をほったぞ！" + m.GoldCarried);
		m.IncreaseFatigue();		
		if (m.PocketsFull())
			m.ChangeState(VisitBankAndDepositGold.Instance);
	}
	
	public override void Exit(Miner m) {
		Debug.Log("ポケットがいっぱいだ・・・離れよう...");
	}
}