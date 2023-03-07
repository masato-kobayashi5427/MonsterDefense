using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class MPUI : MonoBehaviourPun
{
    public PlayerMove playermove;
    public Text MPText;

    #region Private Properties
    #endregion
    void Start()
    {
        if (!photonView.IsMine) //このオブジェクトがLocalでなければ実行しない
        {
            Destroy(this.gameObject);
            return;
        }
        MPText.text = $"MP:{playermove.MP}/{playermove.maxMP}";
    }
    void Update()
    {
        if (!photonView.IsMine) //このオブジェクトがLocalでなければ実行しない
        {
            return;
        }
        MPText.text = $"MP:{playermove.MP}/{playermove.maxMP}";
    }
}