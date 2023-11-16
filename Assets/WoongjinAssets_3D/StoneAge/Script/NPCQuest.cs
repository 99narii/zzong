using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQuest : MonoBehaviour
{
    
    public GameObject questionMark; // ����ǥ ������Ʈ
    public GameObject exclamationMark; // ����ǥ ������Ʈ

    public QuestManager questManager; // QuestManager�� ���� ����

    // NPC�� ID
    public int npcId;

    void Update()
    {
        // ���� NPC�� ���� ���� ����Ʈ�� ������ �ִ��� Ȯ��
        bool isRelatedToCurrentQuest = questManager.CheckQuest(npcId) != null;
        // ���� NPC�� ���� ���� ����Ʈ�� �Ϸ��ߴ��� Ȯ��
        bool hasCompletedCurrentQuest = questManager.GetQuestActionIndex() == questManager.GetQuestNpcIdLength();

        if (isRelatedToCurrentQuest)
        {
            if (hasCompletedCurrentQuest)
            {
                // ����Ʈ �Ϸ�: ����ǥ Ȱ��ȭ, ����ǥ ��Ȱ��ȭ
                questionMark.SetActive(true);
                exclamationMark.SetActive(false);
            }
            else
            {
                // ����Ʈ ���� ��: ����ǥ ��Ȱ��ȭ, ����ǥ Ȱ��ȭ
                questionMark.SetActive(false);
                exclamationMark.SetActive(true);
            }
        }
        else
        {
            // ���� ����Ʈ�� ������ ���� ���: �� �� ��Ȱ��ȭ
            questionMark.SetActive(false);
            exclamationMark.SetActive(false);
        }
    }
}