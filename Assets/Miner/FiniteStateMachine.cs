//全般的なステート変更を請け負うクラス
//どのキャラクターもこのクラスのメソッドを使ってステートを変更する
public class FiniteStateMachine <T>  {
	//ステートを実行して行動するキャラクターを入れる
	private T Owner;
	//現在のステート
	private FSMState<T> CurrentState;
	//前のステート
	private FSMState<T> PreviousState;
	//フラグがたった時はいつでも行いたいステート
	private FSMState<T> GlobalState;
	
	public void Awake()
	{		
		CurrentState = null;
		PreviousState = null;
		GlobalState = null;
	}
	
	//ステートの初期設定メソッド、ownerと初期ステートを確定させる。
	public void Configure(T owner, FSMState<T> InitialState) {
		Owner = owner;
		ChangeState(InitialState);
	}

	//Ownerの実行メソッドを実行する
	public void  Update()
	{
		if (GlobalState != null)  GlobalState.Execute(Owner);
		if (CurrentState != null) CurrentState.Execute(Owner);
	}

	//ステート切り替えメソッド
	//現在のステートの終了メソッドを行ってから、現在のステートを切り替える
	public void  ChangeState(FSMState<T> NewState)
	{	
		PreviousState = CurrentState;
 
		if (CurrentState != null)
			CurrentState.Exit(Owner);
 
		CurrentState = NewState;
 
		if (CurrentState != null)
			CurrentState.Enter(Owner);
	}

	//前のステートに戻すメソッド
	public void  RevertToPreviousState()
	{
		if (PreviousState != null)
			ChangeState(PreviousState);
	}
};