using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;

    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("���� �Ҿƹ����� ��ȭ�ϱ�", new int[] { 1000 }));
        questList.Add(20, new QuestData("�ܰ� �����ϱ�", new int[] { 1000 }));
        questList.Add(30, new QuestData("������ �����ϱ�", new int[] { 1000 }));
        questList.Add(40, new QuestData("������� �����ϱ�", new int[] { 1000 }));
        questList.Add(50, new QuestData("��ȭ�� �����ϱ�", new int[] { 1000, 2000 }));
        questList.Add(60, new QuestData("������ �����ϱ�", new int[] { 1000 }));
        questList.Add(70, new QuestData("����", new int[] { 1000 }));

        questList.Add(80, new QuestData("������", new int[] { 2000 }));
        /*
        questList.Add(10, new QuestData("���� �Ҿƹ����� ��ȭ�ϱ�", new int[] {1000, 2000}));
        questList.Add(20, new QuestData("���� ä���ϱ�", new int[] {1000, 2000}));
        */
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    // ���� ����Ʈ�� questActionIndex ���� ��ȯ�ϴ� �޼���
    public int GetQuestActionIndex()
    {
        return questActionIndex;
    }

    // ���� ����Ʈ�� npcId �迭�� ���̸� ��ȯ�ϴ� �޼���
    public int GetQuestNpcIdLength()
    {
        return questList[questId].npcId.Length;
    }

    public string CheckQuest(int id)
    {
        // �ش� NPC�� ID�� ���� ����Ʈ�� npcId�� ��ġ�ϴ� ���
        if (id == questList[questId].npcId[questActionIndex])
        {
            questActionIndex++; // questActionIndex�� ������Ű��
            // ���� ��� NPC�� �湮�ߴٸ� ���� ����Ʈ�� �Ѿ�ϴ�.
            if (questActionIndex == questList[questId].npcId.Length)
                NextQuest();
            // ���� ����Ʈ�� �̸��� ��ȯ�մϴ�.
            return questList[questId].questName;
        }
        else
        {
            // �ش� NPC�� ID�� ���� ����Ʈ�� npcId�� ��ġ���� �ʴ� ��� null�� ��ȯ�մϴ�.
            return null;
        }
    }

    public string CheckQuest()
    {
        return questList[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;

        Debug.Log("�������� �Ѿ��");
    }
}
