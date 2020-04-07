using UnityEngine;

public enum Locations { goldmine, bar, bank, home };

//Minerクラスは全ステート共通でMinerだけが行う行動を宣言している。
//
//具体的なステートごとに行うものは別スクリプト定義
public class Miner : MonoBehaviour {
	
	private FiniteStateMachine<Miner> FSM;
	
	public Locations         	Location = Locations.goldmine;
	public int                   GoldCarried = 0;
	public int                   MoneyInBank  = 0;
	public int                   Thirst = 0;
	public int                   Fatigue = 0;　//疲労
	
	public void AddToGoldCarried(int amount) {
		GoldCarried += amount;
	}
	
	public void AddToMoneyInBank(int amount ) {
		MoneyInBank += amount;
		GoldCarried = 0;
	}
	
	public bool RichEnough() {
		return false;
	}
	
	public bool PocketsFull() {
		bool full = GoldCarried ==  2 ? true : false;
		return full;
	}
	
	public bool Thirsty() {
		bool thirsty = Thirst == 10 ? true : false;
		return thirsty;
	}
	
	public void IncreaseFatigue() {
		Fatigue++;
	}
	
	public void ChangeState(FSMState<Miner> e) {
		FSM.ChangeState(e);		
	}
	
	public void Awake() {
		Debug.Log("Miner awakes...");
		FSM = new FiniteStateMachine<Miner>();
		FSM.Configure(this, EnterMineAndDigForNugget.Instance);
	}

	//FSMアップデートメソッドで、現在ステートとGlobalステートのExecuteメソッドを実行する。
	public void Update() {
		Thirst++;
		FSM.Update();
	}
	
	public void ChangeLocation(Locations l) {
		Location = l;
	}
}


