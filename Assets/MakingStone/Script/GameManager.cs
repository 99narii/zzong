//using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public enum GameState
{
    success,
    fail,
    none
}

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject successModalObj;
    [SerializeField] GameObject failModalObj;
    [SerializeField] int successRate;

    public TalkManager talkManager;
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;
    public GameObject joyStick;
    public QuestManager questManager;

    GameState gameState = GameState.none;
    int rate = 0;

    private void Start()
    {
        Debug.Log(questManager.CheckQuest());
    }

    void Update()
    {
        if (gameState == GameState.success)
        {
            if (rate < (successRate / 10))
            {
                successModalObj.SetActive(true);
            }
            else
            {
                gameState = GameState.fail;
            }
        }
        else if (gameState == GameState.fail)
        {
            failModalObj.SetActive(true);
        }
    }

    public void SetGameResult(GameState result)
    {
        gameState = result;
    }

    public void SetSuccessRate()
    {
        rate = UnityEngine.Random.Range(0, 10);
    }

    public GameState GetGameResult()
    {
        return gameState;
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNPC);

        talkPanel.SetActive(isAction);
        joyStick.gameObject.SetActive(!isAction);
        Debug.Log("Action()");
    }

    public void Talk(int id, bool isNPC)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }

        StartCoroutine(TypeSentence(talkData));
        isAction = true;
        talkIndex++;
        Debug.Log(talkIndex);
    }

    IEnumerator TypeSentence(string sentence)
    {
        talkText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            talkText.text += letter;
            yield return new WaitForSeconds(0.15f);
        }
    }
}