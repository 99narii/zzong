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
    public Gamemanager manager;

    public GameObject talkPanel;
    public GameObject joyStick;

    GameObject scanObject;


    void Awake()
    {
        scanObject = GameObject.Find("Player").GetComponent<Player>().scanObject;
        talkData = new Dictionary<int, string[]>();
        GenerateData();
        nextButton.onClick.AddListener(() => NextTalk());
        outButton.onClick.AddListener(() => OutTalk());
    }


    void GenerateData()
    {

        // �ι�NPC ���

        // ����
        talkData.Add(1000, new string[] { "���� : ����� �����ΰ�?",
                                          "���� : �����־� ����... ���� ������ �ǳ�..."});

        // �찡
        talkData.Add(2000, new string[] { "������ ����" });

        //��?��
        talkData.Add(3000, new string[] { "���� ä���� �ؾ߰ھ�!" });

        // ����NPC ���


        // ������
        talkData.Add(100, new string[] { "ũ�ƾ�!",
                                         "...",
                                         "�������ʹ� ��� ô�̶� �ش޶��."});

        // ��������
        talkData.Add(200, new string[] { "����, ����",
                                         "Ȥ�� ��, ������ ���� ���� ���������� ������?",
                                         "��, ���Ⱑ �ƴѰ�"});

        //�䲤��
        talkData.Add(300, new string[] { "���� �� ��",
                                         "��~��~��~",
                                         "�װ� �� ���̳�?"});

        //���ϻ���
        talkData.Add(400, new string[] { "����!",
                                         "�� �� ������ �ʴ�?",
                                         "�ƾ�, �Դ� �� �ƴϴϱ� �ǵ帮���� ��"});

        //��
        talkData.Add(500, new string[] { "����~~~",
                                         "...",
                                         "�׳� ���������� �����ϱ� ��������."});

        // Quest Talk
        // ����Ʈ ��ȣ + NPC Id
        talkData.Add(10 + 1000, new string[] {  "���� : "+ "�ƶ���˾ƶ�����ƶ�����˾ƶ���ƶ�����˾ƶ��������Ʒ�ų�ù̷�����ų�������뿬���гʤо�����դ���",});

        talkData.Add(20 + 1000, new string[] {  "���� : ��... ��������...",
                                                "���� : ��! ���� �ϼ��߳�?",
                                                "���� : �ڳ״� ������ ��������!",
                                                "���� : �ϴ� �����ֽŰŶ� �ִ��� ����ϰ� �غôµ�...",
                                                "�ϼ��� �ָԵ����� �ǳ��ش�.",
                                                "���� : �׷� ��� �� �� ����?",
                                                "���� : (�αٵα�)",
                                                "���� : ��...",
                                                "���� : (�αٵα�)",
                                                "���� : ��...",
                                                "���� : (ǥ���� �� ���ƺ��δ�...)",
                                                "���� : (�� �̴�� ��Ⱑ �Ǵ� �ǰ�...)",
                                                "���� : ���...",
                                                "���� : (����, �ƺ� ����ؿ�.�� ��������ΰ�����...)",
                                                "���� : �ƴ�! �ڳ�!",
                                                "���� : (���̴�...)",
                                                "���� : �Ǹ��� �ؾ�����!�����߿� �� ��°�� ���� �ָԵ�����!",
                                                "���� : �׷� ù ��°��?",
                                                "���� : �翬�� ����.",
                                                "���� : ��, ��.",
                                                "���� : �׺��� �ڳ� �� �������� �� �����ִ� �༮�̱���.",
                                                "���� : �� ���� �ָԵ����� �Ƹ� �ٸ� �������鵵 �ڳ׸� �����Ұž�.",
                                                "���� : �����մϴ�.",
                                                "���� : ��... �׷��� ���ε�",
                                                "���� : �׷��� ���ε�?",
                                                "���� : �ڳװ� �츮���� �ʿ��� ���⸦ ����� ������ ���ھ�.",
                                                "���� : ������ �Ͽ����� �޾Ƶ帮�ڴٴ� ������!",
                                                "���� : ��, ������ �����մϴ�. ������ ����...",
                                                "���� : �����Ծ�?",
                                                "���� : �ƴ� �����ϴ�.",
                                                "���� : (�Ž����ٰ� ��Ⱑ ���� ����...)",
                                                "���� : �׷� �׷� �׷�����! ������ �ڳ׿��� ���������� �ñ�ڳ�." ,
                                                "���� : �׷� �ǹ̿��� ���ο� ��Ź�� �ϳ� ����.",
                                                "���� : � ��Ź�ϱ��?",
                                                "���� : ����� ����� ������ ���ܾ� �ϴµ� �� �ָԵ����δ� �Ѱ谡 �ִ� �� ����.",
                                                "���� : ���� ������ �� ���� �� �ִ� ���Ⱑ ������ �����ϱ� �� �����ٵ�...",
                                                "���� : �ڳװ� �� �� ����� ���� �� �?",
                                                "���� : (�Ƹ��� �ܰ��� ����ϴ� �� ����.)",
                                                "���� : (���������� ������ �ô뿡�� ȿ�ڼ��� �־��İ� �峭�ƴ� �� ����� ��.)",
                                                "���� : ��, �ð��ּ���.",
                                                "���忡�� �ٵ������ ���� ���� �ǳ׹޾Ҵ�.",
                                                "���� : �� ��, �׷��� �������� �ڳװ� ���� ������ �ϴ� ���� ���߷ȴٸ�,",
                                                "���� : ��ƸԳ���?",
                                                "���� : ������ζ�� �׷���. ������ �ٸ� ��⸦ �Ϸ��� �ߴ��ž�.",
                                                "���� : ����()�ʿ� ���̴� ��ġ ����? ���༮�� ��Ḧ ��ƿ��� ���� ����ϰ� �־�.",
                                                "���� : �� �༮���� �߰� ��Ḧ ���� �� �־�.",
                                                "���� : ��, �����մϴ�.",
                                                "���� : �ʹ� ���� ���߸��� ��Ƹ����ž�.",
                                                "���� : (��!)",
                                                "���� : �峭�̾� �峭!�׷� � ���� ���⸦ ������ְ�!" });
        /*
        talkData.Add(11 + 2000, new string[] { "��Ḧ ������ �Դ�?",
                                               "���� �־�" });
        */
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10)) // Get First Talk
                return GetTalk(id - id % 100, talkIndex);
            //else
                //return GetTalk(id - id % 10, talkIndex); // Get Quest First Talk
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
       
            // manager.Action(scanObject);
            Debug.Log("NextTalk()");
        
        /*
        //�̰� �����ε�
        if (manager.isAction)
        {
            // ����Ʈ üũ�� ���� ����
            manager.Talk(manager.scanObject.GetComponent<ObjData>().id, manager.scanObject.GetComponent<ObjData>());
            manager.questManager.CheckQuest(manager.scanObject.GetComponent<ObjData>().id);
        }
        */
    }

    void OutTalk()
    {
        talkPanel.SetActive(false);
        joyStick.gameObject.SetActive(true);
        // manager.talkIndex = 0;
    }

}
