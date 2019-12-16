using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//シーン遷移
public class SceneChange : MonoBehaviour
{
    public string sceneName;

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        //Editor上ならこっちの処理
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
        //Buildした後ならこっちの処理
        UnityEngine.Application.Quit();
#endif
    }

}
