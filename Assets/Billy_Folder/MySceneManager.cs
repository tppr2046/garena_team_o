using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    readonly string[] sceneName = {"GameScene", "TetrisDemo", "PartEntryExitTest", "PartEntryExitTest" };
    public SceneStep sceneStep;
    public Animator sceneFSM;
    public GameObject canvasBase;
    public static MySceneManager instance;
    public AudioSource mAudio;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(canvasBase);
        canvasBase.SetActive(false);
    }
    public void SetScene(int sceneNum)
    {
        sceneStep = (SceneStep)sceneNum;
        sceneFSM.SetTrigger(sceneStep.ToString());
        //EnterScene();
    }
    public void ToCraftScene()
    {
        sceneStep = SceneStep.CraftScene;
        //把TetrisDemo加載
        SceneManager.LoadScene(sceneName[(int)sceneStep], LoadSceneMode.Additive);
        CleanScen();
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            canvasBase.SetActive(!canvasBase.activeSelf);
        }
    }
    public void playAudio(string audioName)
    {
        mAudio.PlayOneShot(Resources.Load<AudioClip>(audioName));

    }
    void CleanScen()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(i));
        }
    }

}
