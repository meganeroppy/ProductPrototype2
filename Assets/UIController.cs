using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	public Button button;

	public Text buttonLabel;

	public Text statusLabel;

	private bool connected;
	private bool waiting = false;

	// Use this for initialization
	void Start () 
	{
		// 現在の状態を取得
		StartCoroutine( APIManager.instance.GetState( res =>
		{
				connected = res;
				waiting = false;
		}));
		waiting = true;
	}
		
	void Update()
	{
		button.gameObject.SetActive( !waiting );
		statusLabel.text = "ステータス : " + ( waiting ? "応答待ち中" : "入力受付中" );
	}

	/// <summary>
	/// ボタンが押された時のイベント
	/// </summary>
	public void PressConnectButton()
	{
		bool newState = !connected;

		StartCoroutine( APIManager.instance.SetState(newState, res => 
			{
				// 現在の状態を更新			
				connected = res;
				buttonLabel.text = connected ? "ON" : "OFF";
				waiting = false;
		}) );
		waiting = true;
	}

}
