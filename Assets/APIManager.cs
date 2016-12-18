using UnityEngine;
using System.Collections;

public class APIManager : MonoBehaviour {

	public static APIManager instance;

	// Use this for initialization
	void Start () {
		instance = this;
	}

	/// <summary>
	/// 現在の接続状態を取得
	/// </summary>
	/// <returns>The state.</returns>
	/// <param name="callback">Callback.</param>
	public IEnumerator GetState(System.Action<bool> callback )
	{
		// 応答を待つ
		yield return new WaitForSeconds(3);

		callback(false);
	}

	/// <summary>
	/// 状態を変更
	/// </summary>
	/// <returns>The state.</returns>
	/// <param name="value">If set to <c>true</c> value.</param>
	/// <param name="callback">Callback.</param>
	public IEnumerator SetState( bool value, System.Action<bool> callback )
	{
		// 応答を待つ
		yield return new WaitForSeconds(3);

		callback(value);
	}
}
