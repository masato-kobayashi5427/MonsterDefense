using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerStatusUI : MonoBehaviourPun
{
    public Vector3 ScreenOffset = new Vector3(0f, 30f, 0f);
    public Text PlayerNameText;
    public Slider PlayerHPSlider;
    public Castle castle;
    public Text HPText;
    #region Public Properties
    [Tooltip("UI Text to display Player's Name")]
    

    #endregion

    #region Private Properties
    Castle _target;
    Transform _targetTransform;
    #endregion

    private void Awake()
    {
        this.GetComponent<Transform>().SetParent(GameObject.Find("CanvasUI").GetComponent<Transform>());
    }
    void Update()
    {
        HPText.text = $"HP:{_target.Hp}/{_target.maxHp}";
        //もしPlayerがいなくなったらこのオブジェクトも削除
        if (_target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        // 現在のHPをSliderに適用
        if (PlayerHPSlider != null)
        {
            PlayerHPSlider.value = _target.Hp;
        }
    }

    public void SetTarget(Castle target)
    {
        if (target == null)
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> PlayMakerManager target for PlayerUI.SetTarget.", this);
            return;
        }
        // Cache references for efficiency
        _target = target;
        _targetTransform = _target.GetComponent<Transform>();
        if (PlayerNameText != null)
        {
            Debug.Log("名前");
            Debug.Log("_target.photonView.Owner.NickName");
            PlayerNameText.text = _target.photonView.Owner.NickName;
        }
        if(PlayerHPSlider != null)
        {
            PlayerHPSlider.value = _target.Hp;
        }
    }
}