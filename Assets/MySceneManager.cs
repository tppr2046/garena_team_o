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
        MainScene,
        CraftScene,
        FightScene,
        ResultScene,
    }


}
