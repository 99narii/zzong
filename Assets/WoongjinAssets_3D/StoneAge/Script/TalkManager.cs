using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    public Button nextButton;
    public Button outButton;
    public GameManager manager;


    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();

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
        
        if (talkIndex == talkData[id].Length)
            return null;
        else 
            return talkData[id][talkIndex];
    }

    //public void OnClick()
    //{
    //    if (manager.isAction)
    //    {
    //        //manager.TalkNext();
    //    }
    //}
}
