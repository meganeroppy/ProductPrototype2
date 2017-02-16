using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	public Button button;

	public Text buttonLabel;

	public Text statusLabel;

	private bool connected;
	private int waitCnt = 0;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine( LoopGetState() );
	}

	private IEnumerator LoopGetState()
	{
		var interval = 1f;
		var timer = 0f;
		while(true)
		{
			timer = 0;

			// 現在の状態を取得
			yield return StartCoroutine( APIManager.instance.GetState( res =>
				{
					connected = res.Equals("1");
			}));

			while( timer < interval )
			{
				timer += Time.deltaTime;
				yield return null;
			}
		}

	}
		
	void Update()
	{
		button.gameObject.SetActive( waitCnt <= 0 );
		statusLabel.text = "ステータス : " + ( waitCnt > 0 ? "応答待ち中" : "入力受付中" );
		buttonLabel.text = connected ? "ON" : "OFF";
	}

	/// <summary>
	/// ボタンが押された時のイベント
	/// </summary>
	public void PressConnectButton()
	{
		bool bNewState = !connected;

		waitCnt++;
		StartCoroutine( APIManager.instance.SetState(bNewState ? "1" : "0", res => 
			{
				// 現在の状態を更新			
				connected = res.Equals("1");
				waitCnt--;
		}) );
	}

}
