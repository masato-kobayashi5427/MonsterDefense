using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using Photon.Pun;
using System;

public class Castle : MonoBehaviourPun
{
	//頭上のUIのPrefab
	public GameObject PlayerUiPrefab;
	public int Hp = 100;
	public int maxHp = 100;
	public Slider slider;
	//Localのプレイヤーを設定
	public static GameObject LocalPlayerInstance;

	//頭上UIオブジェクト
	GameObject _uiGo;

	#region 頭上UIの生成
	void Start()
	{
		slider.maxValue = maxHp;    // Sliderの最大値を敵キャラのHP最大値と合わせる
		Hp = maxHp;      // 初期状態はHP満タン
		slider.value = Hp;   // Sliderの初期状態を設定（HP満タン）
		if (PlayerUiPrefab != null)
		{
			if (!photonView.IsMine) //このオブジェクトがLocalでなければ実行しない
			{
				return;
			}
			//Playerの頭上UIの生成とPlayerUIScriptでのSetTarget関数呼出
			_uiGo = Instantiate(PlayerUiPrefab) as GameObject;
			_uiGo.SendMessage("SetTarget", this, SendMessageOptions.RequireReceiver);
		}
		else
		{
			Debug.LogWarning("<Color=Red><a>Missing</a></Color> PlayerUiPrefab reference on player Prefab.", this);
		}
	}
	#endregion

	void Update()
	{
		
		slider.value = Hp;   // Sliderの初期状態を設定（HP満タン）

		if (!photonView.IsMine) //このオブジェクトがLocalでなければ実行しない
		{
			return;
		}
		slider.value = Hp;   // Sliderの初期状態を設定（HP満タン）
		// Sliderが最小値になったら（例：ボスキャラを倒したら）
		if (slider.value <= 0)
		{
			Destroy(gameObject);            // 物体を消去
			Destroy(GameObject.Find("Slider")); // Sliderも消去
		}
	}
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.IsWriting)
		{
			stream.SendNext(this.Hp);
			//stream.SendNext(this.ChatText);
		}
		else
		{
			this.Hp = (int)stream.ReceiveNext();
			//this.ChatText = (string)stream.ReceiveNext();
		}
	}
}