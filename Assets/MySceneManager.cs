using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySceneManager
{
//�C���y�{
//1.�D���
//2.�ո˶��q
//3.�԰����q
//4.�����Loop

    public enum SceneStep 
    { 
        MainScene,
        CraftScene,
        FightScene,
        ResultScene,
    }
    public SceneStep sceneStep;
    public Animator sceneFSM;

    public void SetScene(int sceneNum)
    {
        sceneStep = (SceneStep)sceneNum;
        sceneFSM.SetTrigger(sceneStep.ToString());
        //EnterScene();
    }
    public void EnterScene()
    {

    }
    public void StayScene()
    {

    }
    public void ExitScene()
    {

    }

}
