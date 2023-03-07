using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NetworkMaker : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject PlayerMove;
    [SerializeField] private GameObject PlayerCastle;
    [SerializeField] private GameObject EnemyCastle;

    // Update is called once per frame
    void Start()
    {
        PhotonNetwork.Instantiate(PlayerMove.name, Vector3.zero, Quaternion.identity, 0);
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(PlayerCastle.name, Vector3.zero, Quaternion.identity, 0);
        }
        else
        {
            PhotonNetwork.Instantiate(EnemyCastle.name, new Vector3(0, -1, 24), Quaternion.identity, 0);
        }
    }
}
