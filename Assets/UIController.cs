using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	public Button button;

	public Text buttonLabel;

	private bool connected;

	// Use this for initialization
	void Start () 
	{
		// 現在の状態を取得
		StartCoroutine( APIManager.instance.GetState( res =>
		{
				connected = res;
		}));
	}


	public void PressConnectButton()
	{
		bool newState = !connected;

		StartCoroutine( APIManager.instance.SetState(newState, res => 
			{
				if(res)
				{
					connected = res;
				}	
		}) );
	}

}
