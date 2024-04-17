using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //게임메니저가 레벨업 같이 변하는 정보들 죄다 취급할탠데 이걸 스태틱선언하고 다 때려박아서 쓰는게 낫지않을까?

    string m_s_GameVersion = "1.00.00";
    public GameObject m_ugo_VersionView;

    public float m_PlayerHp;
    public float m_PlayerMp;
    public float m_PlayerFireRate;
    public PlayerMovement player;
    static public GameManager gameManager;
    public float m_PlayerExp;
    public int m_PlayerLevel;
    public List<float> m_NeedExp;
    public float m_Need;
    public List<float> m_TimeStamp;
    public int m_TimeStampLevel;

    public string sceneToRestart;

    public List<GameObject> listGUIScenes;
    public int curGUIState;

    public enum m_GameState {TITLE, GamePlaye, Fails, Ending, __count};

    public volatile bool gameStart = false;
    private float startTime;
    public float elapsedTime;    

    public ItemIventory itemIventory;

    public ButtonIcon buttonIcon;

    public bool m_CanUse;

    public GameObject m_LvUpGUI;

    public GameObject boss;
    public Transform m_TrnBoss;
    public bool m_bIsBossLive = false;

    public EffectManager effect;

    

    private void Awake()
    {
        gameManager = this;
        m_PlayerExp = 0;
        m_PlayerLevel = 1;

        TextMeshProUGUI m_ut_VersionView = m_ugo_VersionView.GetComponent<TextMeshProUGUI>();
        m_ut_VersionView.text = m_s_GameVersion;
    }

    public string Timmer()
    {   
        elapsedTime = Time.time - startTime;
        //Debug.Log("시간: " + Mathf.FloorToInt(elapsedTime / 60f) + " : " + Mathf.FloorToInt(elapsedTime % 60f));
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        if(m_TimeStampLevel != 7 )
        {
            if((int)elapsedTime == (int)m_TimeStamp[m_TimeStampLevel-1])
            {
                m_TimeStampLevel++;
            }
        }

        if (minutes == 3 && m_bIsBossLive == false)
            SummonBoss();

        // 포맷에 맞게 문자열을 반환
        return string.Format("{0:D2} : {1:D2}", minutes, seconds);
        

    }

    public void GameClear()
    {        
        Invoke("PauseGameAMin", 2.6f);
    }

    public void PauseGameAMin()
    {
        SetGUIScene(m_GameState.Ending); 
        Time.timeScale = 0f;
    }

    public void SummonBoss()
    {
        if (boss.activeSelf)
            return;
        boss.SetActive(true);
        boss.transform.position = m_TrnBoss.position;
        m_bIsBossLive = true;
    }

    private void Update()
    {
        if (!gameStart)
        {
            startTime = Time.time;
        }
        if (boss == null)
            GameClear();

        if(Input.GetKeyDown(KeyCode.F2))
            CheatCode();

    }

    public void GetExp(float exp)
    {
        m_PlayerExp += exp;
        effect.PlayEffect(0);
    }

    public void CheckExp()
    {
        if (m_PlayerLevel > m_NeedExp.Count)
            return;
        m_Need = m_NeedExp[m_PlayerLevel - 1];
        if (m_PlayerExp / m_Need >= 1)//레벨업 체크
        {
            LvUp();
            
            m_PlayerExp = 0;
        }
    }

    public void CheatCode()
    {
        LvUp();
    }

    public void LvUp()
    {
        m_PlayerLevel += 1;
        m_LvUpGUI.SetActive(true);
        Time.timeScale = 0f;
        effect.PlayEffect(3);
    }

    void Start()
    {   
        SetGUIScene(ConvertingEnum(0));
    }

    public void EventChangeScene(int stateNumber)
    {
        SetGUIScene(ConvertingEnum(stateNumber));
    }

    public m_GameState ConvertingEnum(int num)
    {
        m_GameState gameState = m_GameState.__count;

        gameState = (m_GameState)num;
       
        return gameState;
    }
    

    public void ShowScene(int state)
    {
        for (int i = 0; i < listGUIScenes.Count; i++)
        {
            if (i == state)
                listGUIScenes[i].SetActive(true);
            else
                listGUIScenes[i].SetActive(false);
        }
    }

    public void SetGUIScene(m_GameState gameState)
    {
        switch (gameState)
        {
            case m_GameState.TITLE: // TITLE                
               
                break;
            case m_GameState.GamePlaye: // GamePlaye
                gameStart = true;                
                break;
            case m_GameState.Fails: // Fails
                gameStart = false;
                break;
            case m_GameState.Ending: // Ending
                gameStart = false;
                break;
        }
        ShowScene((int)gameState);
        curGUIState = (int)gameState;
        //Debug.Log(curGUIState);
    }



    public void UpdateState()
    {
        switch (ConvertingEnum(curGUIState))
        {
            case m_GameState.TITLE: // TITLE                

                break;
            case m_GameState.GamePlaye: // GamePlaye
                //Skills.m_BulletLv = 1;
                break;
            case m_GameState.Fails: // Fails

                break;
            case m_GameState.Ending: // Ending

                break;
        }
    }

    public void EventUpdateStatus()
    {
        
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        // 현재 씬을 다시 로드
        ResetStatic();
        SceneManager.LoadScene(sceneToRestart);
    }

    public void ResetStatic()
    {
        Skills.m_BulletLv = 0;
        Skills.m_ObitLv = 0;
        Skills.m_DropSkillLv = 0;
    }

    public void SetIventory(Item.ITEM_KIND item)
    {
        itemIventory.AddItemToInventory(item);
        
        switch(item)
        {
            case Item.ITEM_KIND.POTION:
                buttonIcon.SetIcon1();
                break;
            case Item.ITEM_KIND.GATHERING_EXP:
                buttonIcon.SetIcon2();
                break;
                

        }
    }

    public Item GetIventory()
    {
        Item i = itemIventory.listItems[0];
        return i;
    }

    public bool CheckInventory()
    {
        return itemIventory.CheckInventory();
    }

    public void UseItem()
    {
        m_CanUse = player.m_PlayerHP <= 0;
        //캐릭터 죽은걸 확인해서 아이템 사용을 막기
        if (m_CanUse)
            return;
        
        bool checkEmpty = GameManager.gameManager.CheckInventory();
        if (checkEmpty)
        {
            Debug.Log("인벤토리가 비어있습니다.");
            return;
        }
        buttonIcon.ClearIcon();
        Item someItem = GetIventory();
        Item.ITEM_KIND itemKind = someItem.item_kind;
        bool v = someItem.UseItem(itemKind);
        if (itemKind == Item.ITEM_KIND.POTION)
            effect.PlayEffect(1);
        if (itemKind == Item.ITEM_KIND.GATHERING_EXP)
            effect.PlayEffect(2);
        itemIventory.RemoveItemToIventory(someItem);
        
    }

}

        


/*
    float Damaged(float targetHP, float sourceAtk)
    {
        float totalDamage;
        totalDamage = targetHP - sourceAtk;

        return totalDamage;
    }

    void DamagedPlayer(float sourceAtk)
    {
        m_PlayerHp -= sourceAtk;        
    }

    void Attack()
    {

    } 

 */