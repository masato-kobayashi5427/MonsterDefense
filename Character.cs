using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Photon.Pun;

[RequireComponent(typeof(NavMeshAgent))]

public class Character : MonoBehaviourPun
{
    private CharacterController controller;
    private GameObject target;
    private NavMeshAgent agent;
    //ここから
    public int maxHp = 1000;
    public int hp; //(数字を設定する)
    public int attackrange;
    //ここまでInspectorで設定
    public Slider slider;
    Animator animator;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        this.animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        slider.maxValue = maxHp;
        slider.value = hp;
    }

    private void Update()
    {
        slider.value = hp;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(this.hp);
            //stream.SendNext(this.ChatText);
        }
        else
        {
            this.hp = (int)stream.ReceiveNext();
            //this.ChatText = (string)stream.ReceiveNext();
        }
    }
    public class SampleTransformView : MonoBehaviourPunCallbacks, IPunObservable
    {
        void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                // Transformの値をストリームに書き込んで送信する
                stream.SendNext(transform.localPosition);
                stream.SendNext(transform.localRotation);
                stream.SendNext(transform.localScale);
            }
            else
            {
                // 受信したストリームを読み込んでTransformの値を更新する
                transform.localPosition = (Vector3)stream.ReceiveNext();
                transform.localRotation = (Quaternion)stream.ReceiveNext();
                transform.localScale = (Vector3)stream.ReceiveNext();
            }
        }
    }
}
