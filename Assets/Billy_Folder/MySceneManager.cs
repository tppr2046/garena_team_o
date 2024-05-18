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
    public enum State
    {
        IDLE,
        START,
        WORK,
        EXIT,
    }

    readonly string[] sceneName = { "car_control", "car_control", "car_control", "car_control" };

    public SceneStep sceneStep;
    public Dictionary<SceneStep, State> GameState = new Dictionary<SceneStep, State>();
    public Animator sceneFSM;
    public GameObject canvasBase;
    public static MySceneManager instance;
    public AudioSource mAudio;
    public BattleManager battleManager;
    public Settlement resultScript;
    public GameObject everySystem;
    private void Awake()
    {
        instance = this;
        //DontDestroyOnLoad(this);
        //DontDestroyOnLoad(canvasBase);
        //canvasBase.SetActive(false);
    }
    private void Start()
    {
        //CreateModel();
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
        StartCoroutine(DoCraftScene());

        //CleanScen();
    }
    public IEnumerator DoCraftScene()
    {
        SceneManager.LoadScene(sceneName[(int)sceneStep], LoadSceneMode.Additive);
        var Game_scene = SceneManager.GetSceneByName(sceneName[(int)sceneStep]);

        while (!Game_scene.isLoaded)
        {
            yield return null;
        }

        SceneManager.SetActiveScene(Game_scene);
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("GameScene"));
        canvasBase.SetActive(false);

        //初始化
        battleManager = GetComponent<BattleManager>();

        yield break;

    }
    public void ToFightScene()
    {
        sceneStep = SceneStep.FightScene;
        battleManager.Run();
        
        //StartCoroutine(DoFightScene());
    }
    public void ToResultScene(PartCollector part1, PartCollector part2)
    {
        sceneStep = SceneStep.ResultScene;
        resultScript.Run(part1, part2);
    }

    public IEnumerator DoFightScene()
    {
        SceneManager.LoadScene(sceneName[(int)sceneStep], LoadSceneMode.Additive);
        var Game_scene = SceneManager.GetSceneByName(sceneName[(int)sceneStep]);

        while (!Game_scene.isLoaded)
        {
            yield return null;
        }

        SceneManager.SetActiveScene(Game_scene);
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("car_control"));
        canvasBase.SetActive(false);

        yield break;

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
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CreateModel();
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

    #region 模型檔名
    public void CreateModel()
    {
        //var obj = Instantiate(Resources.Load(ModelName[0]) as GameObject);
        Instantiate(Resources.Load($"3DModel/{ModelName[Random.Range(0,ModelName.Length)]}"));
    }
    private readonly string[] ModelName = new string[] {
        "2ac71a665dc6_fried_chicken__3d_a",
        "0d24902d7ab2_monopoly_board_game",
        "fdc084038d2c_Taiwan__3d_asset_0_",
        "f9702fff9384_gun__3d_asset_0_glb",
        "99932562e022_warriar_Confucius__",
        "a0a6f50c88c3_PBR_wooden_log_benc",
        "88f238c656ee_Magic_Car__3d_asset",
        "f5057f913162_DnD_D20_dice__3d_as",
        "78d2efe1fee2_Buddha_says__life_i",
        "daf74742b72d_Confucius_in_skippi",
        "ec4597bf60c2_monopoly_board_game",
        "fb51ae56e7e9_a_mythical_battle_a",
        "cdfce05ea695_DnD_D20_dice__3d_as",
        "a9820209ff3a_DnD_D20_dice__3d_as",
        "3fcdf48ef103_Hawai_i__Pizza__3d_",
        "5148c9aae9c5_iPhone__3d_asset_0_",
        "2669d99ed6ce_Nitendo_N64__3d_ass",
        "eec3f4a482be_Orange__3d_asset_0_",
        "fda175092db4_Guan_Yu_riding_a_mo",
        "318a74c4cb04_Garena_Game_Jam__3d"
    };

    #endregion

}
