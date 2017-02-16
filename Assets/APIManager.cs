using UnityEngine;
using System.Collections;
using LitJson;

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
	public IEnumerator GetState(System.Action<string> callback )
	{
		var url = "http://172.17.193.156:8000/GPIO/25/value";

		var www = new WWW(url);

		// 応答を待つ
		yield return www;

		Debug.Log("GetState" + www.text);

		callback(www.text);
	}

	/// <summary>
	/// 状態を変更
	/// </summary>
	/// <returns>The state.</returns>
	/// <param name="value">If set to <c>true</c> value.</param>
	/// <param name="callback">Callback.</param>
	public IEnumerator SetState( string value, System.Action<string> callback )
	{
		
		// POSTだけどURLにパラメータまで含める？
		var url = "http://172.17.193.156:8000/GPIO/25/value/" + value;

		// 送信開始

		// 何かセットしないとGET扱いになってエラーになる
		var form = new WWWForm();
		form.AddField("value", "1");
		var www = new WWW(url, form);

		// 応答を待つ
		yield return www;

		Debug.Log( "SetState" + www.text);

		callback(www.text);
	}
}
