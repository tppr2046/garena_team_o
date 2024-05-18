using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySceneManager : MonoBehaviour
{
//遊戲流程
//1.主選單
//2.組裝階段
//3.戰鬥階段
//4.結算→Loop

    public enum SceneStep 
    { 
        MenuScene,
        CraftScene,
        FightScene,
        ResultScene,
    }
    public SceneStep sceneStep;
    public Animator sceneFSM;
    public static MySceneManager instance;
    private void Awake()
    {
        instance = this;
    }
    public void SetScene(int sceneNum)
    {
        sceneStep = (SceneStep)sceneNum;
        sceneFSM.SetTrigger(sceneStep.ToString());
        //EnterScene();
    }
    public void EnterScene()
    {
        Debug.Log("進入場景");
    }
    public void StayScene()
    {

    }
    public void ExitScene()
    {

        Debug.Log("離開場景");
    }

}
