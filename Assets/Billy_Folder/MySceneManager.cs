using Cinemachine;
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
        MENU,
        CRAFT,
        FIGHT,
        RESULT,
        count,
    }
    public enum State
    {
        IDLE,
        START,
        WORK,
        EXIT,
    }

    readonly string[] sceneName = { "car_control", "car_control", "car_control", "car_control" };

    public SceneStep sceneStep;//當前階段
    public Dictionary<int, State> GameState = new Dictionary<int, State>();//每個階段的狀態
    public Animator sceneFSM;
    //public GameObject canvasBase;//UI的集合
    public GameObject[] UIPanels;
    public static MySceneManager instance;//單例
    public AudioSource mAudio;//可使用的Audio
    public AudioSource mAudioBGM;//可使用的Audio
    public TetrisManager tetrisManager;//CraftStep的控制腳本
    public BattleManager battleManager;//FightStep的控制腳本
    public Settlement resultScript;//ResultStep的控制腳本
    public CinemachineVirtualCamera virtualCamera;
    public GameObject bombFX;
    

    private void Awake()
    {
        instance = this;
        for (int i = 0; i < (int)SceneStep.count; i++)//初始化所有狀態
        {
            GameState.Add(i, State.IDLE);
        }
        tetrisManager.enabled = false;
        FindObjectOfType<PlayerHitChecker>().HitPlayerEvent += playBomb;
    }
    private void Start()
    {
        //CreateModel();
    }
    public void SetSceneStep(int sceneNum)
    {
        sceneStep = (SceneStep)sceneNum;
        sceneFSM.SetTrigger(sceneStep.ToString());
        //EnterScene();
    }
    public void ToMenuScene()
    {
        setUIPanel(0);
    }
    public void ToCraftScene()//設置在MenuScene的Button上
    {
        StartCoroutine(DoCraftScene());
    }
    IEnumerator DoCraftScene()
    {
        yield return new WaitForSeconds(2f);
        setUIPanel(1);
        sceneStep = SceneStep.CRAFT;
        tetrisManager.enabled = true;
        tetrisManager.RunTetrisInstantiate();
    }

    public void ToFightScene()//設置在TetrisManager，時間到的時候
    {
        setUIPanel();
        sceneStep = SceneStep.FIGHT;

        var tos = GameObject.FindObjectsOfType<TextObject>();
        foreach(var to in tos) { Destroy(to.gameObject); }
        var pcs = GameObject.FindObjectsOfType<PartCollector>();
        foreach (var pc in pcs) { pc.GetComponent<Collider>().enabled = false; }

        tetrisManager.crashEvent.CRASH();//打開牆壁
        virtualCamera.enabled = true;
        tetrisManager.enabled = false;
        battleManager.EndEvent += ToResultScene;
        battleManager.Run();
        //StartCoroutine(DoFightScene());
    }
    public void ToResultScene(PartCollector part1, PartCollector part2)
    {
        setUIPanel(2);
        sceneStep = SceneStep.RESULT;
        resultScript.Run(part1, part2);
        playAudioBGM("BattleEndMusic");
    }
    void setUIPanel(int num = -1)
    {
        for (int i = 0; i < UIPanels.Length; i++)
        {
            UIPanels[i].SetActive(false);
        }
        if (num > -1)
        {
            UIPanels[num].SetActive(true);
        }
    }
    public void EnterStep()
    {
        Debug.Log("進入場景");
    }
    public void StayStep()
    {
        
    }
    public void ExitStep()
    {

        Debug.Log("離開場景");
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    canvasBase.SetActive(!canvasBase.activeSelf);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    CreateModel();
        //}
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("car_control");
        }
    }
    public void playAudio(string audioName)
    {
        mAudio.PlayOneShot(Resources.Load<AudioClip>(audioName));
    }
    public void playAudioBGM(string audioName)
    {
        mAudioBGM.clip = Resources.Load<AudioClip>(audioName);
        mAudioBGM.Play();
    }
    void playBomb()
    {
        Instantiate(bombFX);
    }

    #region 模型檔名
    //public void CreateModel()
    //{
    //    //var obj = Instantiate(Resources.Load(ModelName[0]) as GameObject);
    //    Instantiate(Resources.Load($"3DModel/{ModelName[Random.Range(0,ModelName.Length)]}"));
    //}
    //private readonly string[] ModelName = new string[] {
    //    "2ac71a665dc6_fried_chicken__3d_a",
    //    "0d24902d7ab2_monopoly_board_game",
    //    "fdc084038d2c_Taiwan__3d_asset_0_",
    //    "f9702fff9384_gun__3d_asset_0_glb",
    //    "99932562e022_warriar_Confucius__",
    //    "a0a6f50c88c3_PBR_wooden_log_benc",
    //    "88f238c656ee_Magic_Car__3d_asset",
    //    "f5057f913162_DnD_D20_dice__3d_as",
    //    "78d2efe1fee2_Buddha_says__life_i",
    //    "daf74742b72d_Confucius_in_skippi",
    //    "ec4597bf60c2_monopoly_board_game",
    //    "fb51ae56e7e9_a_mythical_battle_a",
    //    "cdfce05ea695_DnD_D20_dice__3d_as",
    //    "a9820209ff3a_DnD_D20_dice__3d_as",
    //    "3fcdf48ef103_Hawai_i__Pizza__3d_",
    //    "5148c9aae9c5_iPhone__3d_asset_0_",
    //    "2669d99ed6ce_Nitendo_N64__3d_ass",
    //    "eec3f4a482be_Orange__3d_asset_0_",
    //    "fda175092db4_Guan_Yu_riding_a_mo",
    //    "318a74c4cb04_Garena_Game_Jam__3d"
    //};

    #endregion

}
