using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //�̱��� ȭ
    public static GameManager instance;

    public GameObject square;
    public Text timeText;
    public GameObject endPanel;
    public Text nowScore;
    public Text bestScore;

    float time = 0.0f;
    string key = "bestScore";

    bool isPlay = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("MakeSquare" , 0.0f , 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlay)
        {
            time += Time.deltaTime;
            timeText.text = time.ToString("N2");
        }
    }

    void MakeSquare()
    {
        Instantiate(square);
    }

    public void GameOver()
    {
        //������ ������ �ؾ��Ұ� ?
        //�ð� ���߰� , �ǳ� �����


        //���ӿ���
        Time.timeScale = 0.0f;
        isPlay = false;

        //�ð� ����
        nowScore.text = time.ToString("N2");

        //�ְ����� ����
        //�ְ� ������ �ִٸ�
            //�ְ� ���� < ���� ���� ��
                //���� ������ �ְ� ������ �����Ѵ�.
        //�ְ� ������ ���ٸ�
            //���� ������ �����Ѵ�
        if(PlayerPrefs.HasKey(key))
        {
            float best = PlayerPrefs.GetFloat(key);

            if(best < time)
            {
                PlayerPrefs.SetFloat(key, time);
                bestScore.text = time.ToString("N2");
            }
            else
            {
                bestScore.text = best.ToString("N2");
            }
        }
        else 
        {
            PlayerPrefs.SetFloat(key, time);
            bestScore.text = time.ToString("N2");
        }

        //�ǳ� ����
        endPanel.SetActive(true);
    }
}
