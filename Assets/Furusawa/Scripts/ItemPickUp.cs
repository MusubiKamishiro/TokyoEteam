using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アイテム取得用スクリプト
public class ItemPickUp : MonoBehaviour
{
    public enum ItemEffect
    {
        Item1,
        Item2,
        Item3
    }


    [SerializeField] ItemEffect itemEffect;


    //触れた時
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UseEffect(itemEffect);
        }
    }

    //効果発動と消滅
    public void UseEffect(ItemEffect effect)
    {
        switch (effect)
        {
            case ItemEffect.Item1:
                Debug.Log("一のアイテム");
                break;

            case ItemEffect.Item2:
                Debug.Log("2のアイテム");
                break;

            case ItemEffect.Item3:
                Debug.Log("3のアイテム");
                break;
        }
        
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        //ここから呼び出した方がいいかも
    }


}
