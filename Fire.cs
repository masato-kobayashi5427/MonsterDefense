using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Fire : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private string AttackTag;
    public int damage;
    public float life_time = 1.5f;
    float time = 0f;


    private void Start()
    {
        time = 0;
    }
    void Update()
    {
        time += Time.deltaTime;
        if(time>life_time)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (col.tag == "Enemy")
            {
                Debug.Log("当たった");

                if (col.gameObject.GetComponent<Character>().hp > 0)
                {
                    col.gameObject.GetComponent<Character>().hp -= damage;
                }
                if (col.gameObject.GetComponent<Castle>().Hp > 0)
                {
                    target.GetComponent<Castle>().Hp -= damage;
                }
                if (col.gameObject.GetComponent<Character>().hp <= 0)
                {
                    Destroy(col.gameObject);
                }
            }
        }
        else
        {
            if (col.tag == "Player")
            {
                Debug.Log("当たった");

                if (col.gameObject.GetComponent<Character>().hp > 0)
                {
                    col.gameObject.GetComponent<Character>().hp -= damage;
                }
                if (col.gameObject.GetComponent<Castle>().Hp > 0)
                {
                    target.GetComponent<Castle>().Hp -= damage;
                }
                if (col.gameObject.GetComponent<Character>().hp <= 0)
                {
                    Destroy(col.gameObject);
                }
            }
        }
    }
}
