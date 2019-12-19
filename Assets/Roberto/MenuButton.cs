using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
[RequireComponent(typeof(AudioSource))]
public class MenuButton : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip clip;
    public string sceneName;
    public buttonType type=buttonType.gameDirector;
    public delegate void buttonAction();
    public buttonAction newAction;
    
    private void Start()
    {
        buttonSettings();
    }
   
    public void Click()
    {
        audio.PlayOneShot(clip);
        newAction();
    }

    public void buttonSettings()
    {
        switch (type)
        {
            case buttonType.gameDirector:
                newAction = gameDirector;
                break;
            case buttonType.applicationQuit:
                newAction = quit;
                break;
            case buttonType.Pause:
                newAction = pause;
                break;
            case buttonType.sceneChange:
                newAction = sceneChange;
                break;


        }
    }

    void gameDirector(){ GameDirector gd = FindObjectOfType<GameDirector>();
        gd.GameStart();
    }
    void quit(){

#if UNITY_EDITOR
        //Editor上ならこっちの処理
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
        //Buildした後ならこっちの処理
        UnityEngine.Application.Quit();
#endif
    }
    void pause() { Debug.Log("pause"); }
    void sceneChange()
    {
        Fader fader = FindObjectOfType<Fader>();
        fader.FadeOut();
        Invoke("SceneChangeInvoke", 1f);
    }

    void SceneChangeInvoke()
    {
        SceneManager.LoadScene(sceneName);

    }
}
public enum buttonType
{
    sceneChange,
    gameDirector,
    applicationQuit,
    Pause,
}
/* public void giveAction(buttonAction ac)
    {
        newAction = ac;
    }*/
