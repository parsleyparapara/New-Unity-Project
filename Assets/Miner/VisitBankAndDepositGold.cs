using UnityEngine;

public sealed class VisitBankAndDepositGold :  FSMState<Miner> {
	
	static readonly VisitBankAndDepositGold instance = new VisitBankAndDepositGold();
	//プロパティ
	public static VisitBankAndDepositGold Instance {
		get {
			return instance;
		}
	}
	static VisitBankAndDepositGold() { }
	private VisitBankAndDepositGold() { }
	
		
	public override void Enter (Miner m) {
		if (m.Location != Locations.bank) {
			Debug.Log("銀行にはいるぞ...");
			m.ChangeLocation(Locations.bank);
		}
	}
	
	public override void Execute (Miner m) {
		Debug.Log("Feeding The System with MY gold... " + m.MoneyInBank);
		m.AddToMoneyInBank(m.GoldCarried);	
		m.ChangeState(EnterMineAndDigForNugget.Instance);
	}
	
	public override void Exit(Miner m) {
		Debug.Log("銀行から出るぞ...");
	}
}