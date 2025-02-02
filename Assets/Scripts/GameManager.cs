using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //싱글톤 화
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
        //게임이 끝날때 해야할것 ?
        //시간 멈추고 , 판넬 띄우자


        //게임오버
        Time.timeScale = 0.0f;
        isPlay = false;

        //시간 설정
        nowScore.text = time.ToString("N2");

        //최고점수 설정
        //최고 점수가 있다면
            //최고 점수 < 현재 점수 비교
                //현재 점수를 최고 점수에 저장한다.
        //최고 점수가 없다면
            //현재 점수를 저장한다
        if(PlayerPrefs.HasKey(key))     // 최고 점수가 있다면
        {
            float best = PlayerPrefs.GetFloat(key);
            
            // 최고 점수와 현재 점수를 비교
            if (best < time)             
            {
                PlayerPrefs.SetFloat(key, time);        // 현재 점수가 최고 점수보다 높으면
                bestScore.text = time.ToString("N2");   // 최고점수 키값을 갱신해준다
            }
            else
            {
                bestScore.text = best.ToString("N2");   // 아니면 최고점수로 다시 출력
            }
        }
        else 
        {
            PlayerPrefs.SetFloat(key, time);            // 기록된 최고점수가 없을 경우
            bestScore.text = time.ToString("N2");       // 현재 점수를 최고점수로 갱신
        }

        //판넬 띄우기
        endPanel.SetActive(true);
    }
}
