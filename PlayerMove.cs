using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerMove : MonoBehaviourPun
{
    [SerializeField] private GameObject BatMaskTint;
    [SerializeField] private GameObject Dragon;
    [SerializeField] private GameObject TurtleShell;
    [SerializeField] private GameObject EvilMage;
    [SerializeField] private GameObject Orc;
    [SerializeField] private GameObject Golem;
    [SerializeField] private GameObject BatMaskTint2;
    [SerializeField] private GameObject Dragon2;
    [SerializeField] private GameObject TurtleShell2;
    [SerializeField] private GameObject EvilMage2;
    [SerializeField] private GameObject Orc2;
    [SerializeField] private GameObject Golem2;
    [SerializeField] private GameObject Skeleton_Purple;
    [SerializeField] private GameObject Skeleton_Green;
    [SerializeField] private GameObject Werewolf_Black;
    [SerializeField] private GameObject Werewolf_Grey;
    [SerializeField] private GameObject Fairy_Autumn;
    [SerializeField] private GameObject Fairy_Summer;

    bool isCalledOnce = false;
    //ここからコスト
    private float time;
    public int maxMP;
    public int MP;
    public int BatMaskTintcost;
    public int Dragoncost;
    public int TurtleShellcost;
    public int EvilMagecost;
    public int Orccost;
    public int Golemcost;
    public int Skeletoncost;
    public int Werewolfcost;
    public int Fairycost;
    int num = 0;

    void Start()
    {
        MP = maxMP;
    }
    void Update()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }
        if (PhotonNetwork.IsMasterClient)
        {
            bool cancel = false;
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();

                if ((Physics.Raycast(ray, out hit)) && (cancel = true))
                {
                    if (hit.collider.CompareTag("BatMaskTint"))
                    {
                        num = 1;
                        Debug.Log("num=1");
                    }
                    else if (hit.collider.CompareTag("Dragon"))
                    {
                        num = 2;
                        Debug.Log("num=2");
                    }
                    else if (hit.collider.CompareTag("TurtleShell"))
                    {
                        num = 3;
                        Debug.Log("num=3");
                    }
                    else if (hit.collider.CompareTag("EvilMage"))
                    {
                        num = 4;
                        Debug.Log("num=4");
                    }
                    else if (hit.collider.CompareTag("Orc"))
                    {
                        num = 5;
                        Debug.Log("num=5");
                    }
                    else if (hit.collider.CompareTag("Golem"))
                    {
                        num = 6;
                        Debug.Log("num=6");
                    }
                    else if (hit.collider.CompareTag("Skeleton"))
                    {
                        num = 7;
                        Debug.Log("num=7");
                    }
                    else if (hit.collider.CompareTag("Werewolf"))
                    {
                        num = 8;
                        Debug.Log("num=8");
                    }
                    else if (hit.collider.CompareTag("Fairy"))
                    {
                        num = 9;
                        Debug.Log("num=9");
                    }

                    else if (hit.collider.CompareTag("PlayerStage"))
                    {
                        Debug.Log(num);
                        if (num == 1)
                        {
                            if (MP < BatMaskTintcost) return;
                            MP -= BatMaskTintcost;
                            PhotonNetwork.Instantiate(BatMaskTint.name, hit.point, Quaternion.identity);
                        }
                        if (num == 2)
                        {
                            if (MP < Dragoncost) return;
                            MP -= Dragoncost;
                            PhotonNetwork.Instantiate(Dragon.name, hit.point, Quaternion.identity);
                        }
                        if (num == 3)
                        {
                            if (MP < TurtleShellcost) return;
                            MP -= TurtleShellcost;
                            PhotonNetwork.Instantiate(TurtleShell.name, hit.point, Quaternion.identity);
                        }
                        if (num == 4)
                        {
                            if (MP < EvilMagecost) return;
                            MP -= EvilMagecost;
                            PhotonNetwork.Instantiate(EvilMage.name, hit.point, Quaternion.identity);
                        }
                        if (num == 5)
                        {
                            if (MP < Orccost) return;
                            MP -= Orccost;
                            PhotonNetwork.Instantiate(Orc.name, hit.point, Quaternion.identity);
                        }
                        if (num == 6)
                        {
                            if (MP < Golemcost) return;
                            MP -= Golemcost;
                            PhotonNetwork.Instantiate(Golem.name, hit.point, Quaternion.identity);
                        }
                        if (num == 7)
                        {
                            if (MP < Skeletoncost) return;
                            MP -= Skeletoncost;
                            PhotonNetwork.Instantiate(Skeleton_Purple.name, hit.point, Quaternion.identity);
                        }
                        if (num == 8)
                        {
                            if (MP < Werewolfcost) return;
                            MP -= Werewolfcost;
                            PhotonNetwork.Instantiate(Werewolf_Black.name, hit.point, Quaternion.identity);
                        }
                        if (num == 9)
                        {
                            if (MP < Fairycost) return;
                            MP -= Fairycost;
                            PhotonNetwork.Instantiate(Fairy_Autumn.name, hit.point, Quaternion.identity);
                        }
                    }
                }
            }
        }
        else
        {
            bool cancel = false;
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();

                if ((Physics.Raycast(ray, out hit)) && (cancel = true))
                {
                    if (hit.collider.CompareTag("BatMaskTint"))
                    {
                        num = 10;
                        Debug.Log(num);
                    }
                    else if (hit.collider.CompareTag("Dragon"))
                    {
                        num = 11;
                        Debug.Log(num);
                    }
                    else if (hit.collider.CompareTag("TurtleShell"))
                    {
                        num = 12;
                        Debug.Log(num);
                    }
                    else if (hit.collider.CompareTag("EvilMage"))
                    {
                        num = 13;
                        Debug.Log("num=13");
                    }
                    else if (hit.collider.CompareTag("Orc"))
                    {
                        num = 14;
                        Debug.Log("num=14");
                    }
                    else if (hit.collider.CompareTag("Golem"))
                    {
                        num = 15;
                        Debug.Log("num=15");
                    }
                    else if (hit.collider.CompareTag("Skeleton"))
                    {
                        num = 16;
                        Debug.Log("num=16");
                    }
                    else if (hit.collider.CompareTag("Werewolf"))
                    {
                        num = 17;
                        Debug.Log("num=17");
                    }
                    else if (hit.collider.CompareTag("Fairy"))
                    {
                        num = 18;
                        Debug.Log("num=18");
                    }

                    else if (hit.collider.CompareTag("EnemyStage"))
                    {

                        Debug.Log(num);
                        if (num == 10)
                        {
                            if (MP < BatMaskTintcost) return;
                            MP -= BatMaskTintcost;
                            PhotonNetwork.Instantiate(BatMaskTint2.name, hit.point, Quaternion.Euler(0, 180, 0));
                        }
                        if (num == 11)
                        {
                            if (MP < Dragoncost) return;
                            MP -= Dragoncost;
                            PhotonNetwork.Instantiate(Dragon2.name, hit.point, Quaternion.Euler(0, 180, 0));
                        }
                        if (num == 12)
                        {
                            if (MP < TurtleShellcost) return;
                            MP -= TurtleShellcost;
                            PhotonNetwork.Instantiate(TurtleShell2.name, hit.point, Quaternion.Euler(0, 180, 0));
                        }
                        if (num == 13)
                        {
                            if (MP < EvilMagecost) return;
                            MP -= EvilMagecost;
                            PhotonNetwork.Instantiate(EvilMage2.name, hit.point, Quaternion.Euler(0, 180, 0));
                        }
                        if (num == 14)
                        {
                            if (MP < Orccost) return;
                            MP -= Orccost;
                            PhotonNetwork.Instantiate(Orc2.name, hit.point, Quaternion.Euler(0, 180, 0));
                        }
                        if (num == 15)
                        {
                            if (MP < Golemcost) return;
                            MP -= Golemcost;
                            PhotonNetwork.Instantiate(Golem2.name, hit.point, Quaternion.Euler(0, 180, 0));
                        }
                        if (num == 16)
                        {
                            if (MP < Skeletoncost) return;
                            MP -= Skeletoncost;
                            PhotonNetwork.Instantiate(Skeleton_Green.name, hit.point, Quaternion.identity);
                        }
                        if (num == 17)
                        {
                            if (MP < Werewolfcost) return;
                            MP -= Werewolfcost;
                            PhotonNetwork.Instantiate(Werewolf_Grey.name, hit.point, Quaternion.identity);
                        }
                        if (num == 18)
                        {
                            if (MP < Fairycost) return;
                            MP -= Fairycost;
                            PhotonNetwork.Instantiate(Fairy_Summer.name, hit.point, Quaternion.identity);
                        }
                    }
                }
            }
        }
    if (MP < maxMP)
    {
        time += Time.deltaTime;
        if (time >= 1.0)
        {
            MP += 5;
            time = 0.0f;
        }
    }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(this.MP);
            //stream.SendNext(this.ChatText);
        }
        else
        {
            this.MP = (int)stream.ReceiveNext();
            //this.ChatText = (string)stream.ReceiveNext();
        }
    }
}