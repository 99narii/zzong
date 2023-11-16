using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCQuestState
{
    HAVE_QUEST,
    SUCCESS_QUEST,
    PROCESS_QUEST,
    NONE
}

public class ObjData : MonoBehaviour
{
    public int id;
    public bool isNPC;
    public NPCQuestState npcQuestState = NPCQuestState.NONE;
    public string[] questTitleArr;
    public bool[] successArr;
    public int currentQuest;

    Player processingPlayer;

    private void Awake()
    {
        questTitleArr = new string[6];
        // questTitleArr[0] = "���忡�� ���ɱ�";
        questTitleArr[0] = "Making scratches"; // "�ܰ� �����ϱ�";
        questTitleArr[1] = "Making a stone axe"; // "������ �����ϱ�";
        questTitleArr[2] = "Making a Sumbetjigae"; // "������� �����ϱ�";
        questTitleArr[3] = "Making a Stone Arrow"; // "��ȭ�� �����ϱ�";
        questTitleArr[4] = "Making a Pickpick"; // "������ �����ϱ�";
        questTitleArr[5] = "Ending"; // "����";

        successArr = new bool[questTitleArr.Length];

        for(int i = 0; i < successArr.Length; ++i)
        {
            successArr[i] = false;
        }

        currentQuest = 0;
    }

    public int GetNPCId()
    {
        return id;
    }

    public NPCQuestState GetNPCQuestState()
    {
        return npcQuestState;
    }

    public void SetNPCQuestState(NPCQuestState state)
    {
        npcQuestState = state;
    }

    public int GetCurrentQuest()
    {
        return currentQuest;
    }

    public void IncreaseCurrentQuest()
    {
        currentQuest++;
    }

    public string GetQuestTitle(int index)
    {
        return questTitleArr[index];
    }

    public void SetProcessingPlayer(Player player)
    {
        processingPlayer = player;
    }

    public void SetSuccessArr(int index, bool isFinsh)
    {
        successArr[index] = isFinsh;
    }
}
