using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    public Button nextButton;
    public Button outButton;
    public GameManager manager;

    public GameObject talkPanel;
    public GameObject joyStick;

    GameObject scanObject;


    void Awake()
    {
        scanObject = GameObject.Find("Player").GetComponent<Player_keyboard>().scanObject;
        talkData = new Dictionary<int, string[]>();
        GenerateData();
        nextButton.onClick.AddListener(() => NextTalk());
        outButton.onClick.AddListener(() => OutTalk());
    }


    void GenerateData()
    {
        talkData.Add(1000, new string[] { "�ȳ�", 
                                          "���� ���� �Ҿƹ�����",
                                          "�̼��� �ٰ�"});
        talkData.Add(2000, new string[] { "������ ����" });
        talkData.Add(3000, new string[] { "���� ä���� �ؾ߰ھ�!" });

        // Quest Talk
        // ����Ʈ ��ȣ + NPC Id
        talkData.Add(10 + 1000, new string[] { "�Ͼ����", 
                                               "�̼��� �ٰ�" });
        talkData.Add(11 + 2000, new string[] { "��Ḧ ������ �Դ�?",
                                               "���� �־�" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10)) // Get First Talk
                return GetTalk(id - id % 100, talkIndex);
            else
                return GetTalk(id - id % 10, talkIndex); // Get Quest First Talk
        }
        Debug.Log(id + talkIndex);
        // ������ ��ȭ���� ���� ��ư �� ���̰�
        if (talkIndex == talkData[id].Length - 1)
            nextButton.gameObject.SetActive(false);
        else
            nextButton.gameObject.SetActive(true);

        
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];

            

    }

    void NextTalk()
    {
        //�̰� �����ε�
        if (manager.isAction)
        {
            // ����Ʈ üũ�� ���� ����
            manager.Talk(manager.scanObject.GetComponent<ObjData>().id, manager.scanObject.GetComponent<ObjData>());
            manager.questManager.CheckQuest(manager.scanObject.GetComponent<ObjData>().id);
        }
    }

    void OutTalk()
    {
        talkPanel.SetActive(false);
        joyStick.gameObject.SetActive(true);
    }

}
