using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Photon.Pun;

public class SceneCamera : MonoBehaviour
{
    internal object photonView;

    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            
        }
        else
        {
            Debug.Log("aa");
            this.transform.position += new Vector3(0, 0, 29);
            transform.Rotate(new Vector3(150, 180, 0));
        }
    }
}