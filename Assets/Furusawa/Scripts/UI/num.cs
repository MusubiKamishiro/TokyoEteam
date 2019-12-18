using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class num : MonoBehaviour
{
    public Sprite[] numimage;
    public List<int> number = new List<int>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            RandomScore();
        }
    }
    public void RandomScore()
    {
        //クリックされるたびにrandomでスコアを変動
        var random = Random.Range(1, 90000);
        //いままで表示されてたスコアオブジェクト削除
        var objs = GameObject.FindGameObjectsWithTag("score");
        foreach (var obj in objs)
        {
            if (0 <= obj.name.LastIndexOf("Clone"))
            {
                Destroy(obj);
            }
        }
        View(random);
    }
    //スコアを表示するメソッド
    void View(int score)
    {
        var digit = score;
        //要素数0には１桁目の値が格納
        number = new List<int>();
        while (digit != 0)
        {
            score = digit % 10;
            digit = digit / 10;
            number.Add(score);
        }

        GameObject.Find("ScoreImage").GetComponent<Image>().sprite = numimage[number[0]];
        for (int i = 1; i < number.Count; i++)
        {
            //複製
            RectTransform scoreimage = (RectTransform)Instantiate(GameObject.Find("ScoreImage")).transform;
            scoreimage.SetParent(this.transform, false);
            scoreimage.localPosition = new Vector2(
                scoreimage.localPosition.x - scoreimage.sizeDelta.x * i,
                scoreimage.localPosition.y);
            scoreimage.GetComponent<Image>().sprite = numimage[number[i]];
        }
    }
}