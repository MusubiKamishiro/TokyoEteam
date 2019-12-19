using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    itemType type;
    [SerializeField]
    float value = 1;

    private GameDirector gd;
    private PlayerStatus ps;

    //サウンド
    public AudioClip PickSE;
    AudioSource audioSource4;

    private void Start()
    {
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        ps = GameObject.Find("Mametarou").GetComponent<PlayerStatus>();

        audioSource4 = GetComponent<AudioSource>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audioSource4.PlayOneShot(PickSE);
            switch (type)
            {
                //スコアアップ
                case itemType.scoreUp:
                    gd.currentCombo += (int)value;
                    break;
                    //時間アップ
                case itemType.TimeUp:
                    gd.currentTime += value;
                    break;
                    //回復
                case itemType.Healing:
                    ps.playerCurrentLife++;
                    break;
            }
            
            
            Destroy(gameObject);
        }

    }

    public enum itemType
{
    scoreUp,
    TimeUp,
    Healing
}
}