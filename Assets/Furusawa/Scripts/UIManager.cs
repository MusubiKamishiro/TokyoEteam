using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//UIの管理をする
public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerStatus playerStatus;

    [SerializeField] Image lifeGage;
    [SerializeField] Image specialGage;

    void Start()
    {
        
    }


    void Update()
    {
        SetUI();
    }

    //UIの更新
    private void SetUI()
    {

        lifeGage.fillAmount = playerStatus.GetLifePercentage();
        specialGage.fillAmount = playerStatus.GetSpecialGage();

    }


}
