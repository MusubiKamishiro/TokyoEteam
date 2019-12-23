using System.Collections;
using UnityEngine;

//カメラを揺らすスクリプト
public class CameraShake : MonoBehaviour
{
    [SerializeField,Tooltip("揺れをカーブで調整する")] AnimationCurve curve = AnimationCurve.Linear(0,1,1,1);
    [SerializeField,Tooltip("時間の速さ(一秒でどれくらい進むか)")] float _TimeRate = 1;
    [SerializeField, Tooltip("揺れる時間（1なら一秒間揺れる)")] float _Duration = 1;
    [SerializeField,Tooltip("揺れの強さ(距離)")] private float shakePow = 1;  

    private float timeScale = 0;    //現在のグラフの進み具合
    private float shakeValue;       //現在の時間での揺れの強さ


    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(DoShake(duration, magnitude));
    }

    public void ShakeOther()
    {
        StartCoroutine(DoShake(_Duration, shakePow));

    }

    private void Start()
    {
        //StartCoroutine(ShakeMethod(_Duration));
    }


    private void Update()
    {
        //timeScale += (Time.deltaTime * _TimeRate);           //時間の速さを計算
        //timeScale = Mathf.Clamp(timeScale, 0, _Duration);   //0から_Durationの値に正しくする

        //shakeValue = curve.Evaluate(timeScale);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(ShakeMethod(_Duration));
            Debug.Log("レッツシェイク");
        }

    }

   

    private IEnumerator ShakeMethod(float duration)
    {
        //初期位置を保存
        var pos = Camera.main.transform.localPosition;
        var elapsed = 0f;
        timeScale = 0f;

        while(elapsed < duration)              
        {
            timeScale += (Time.deltaTime * _TimeRate);           //時間の速さを計算
            timeScale = Mathf.Clamp(timeScale, 0, _Duration);   //0から_Durationの値に正しくする
            Debug.Log(timeScale);
            shakeValue = curve.Evaluate(timeScale);

            var x = pos.x + Random.Range(-shakePow, shakePow) * shakeValue;
            var y = pos.y + Random.Range(-shakePow, shakePow) * shakeValue;

            Camera.main.transform.localPosition = new Vector3(x, y, pos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        Camera.main.transform.localPosition = pos;



    }




    private IEnumerator DoShake(float duration, float magnitude)
    {
        var pos = transform.localPosition;

        var elapsed = 0f;

        while (elapsed < duration)
        {
            var x = pos.x + Random.Range(-1f, 1f) * magnitude;
            var y = pos.y + Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, pos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = pos;
    }
}