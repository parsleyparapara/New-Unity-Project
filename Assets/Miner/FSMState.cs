//抽象ジェネリッククラス、ここでステートに入るとき、実行中、出るときの動作を決める
//それぞれのステートが継承する基底クラスになっている。
abstract public class FSMState <T>   {

	//ステート開始時
	abstract public void Enter (T entity);
	//ステート実行中
		
	abstract public void Execute (T entity);
	//ステート終了時
	abstract public void Exit(T entity);
}
