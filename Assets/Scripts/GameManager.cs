using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource music; // 음악 넣기
    public bool startPlaying; // 플레이 시작
    public BeatScroller beatsroller; // 스크롤 시작 컨트롤
    public static GameManager instance; // 싱글톤

    public int currentScore; // 점수 합계
    public int scorePerNote = 100; // 노트 점수

    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public int currentMultiplier; // 점수 배수
    public int multiplierTracker; // 점수 배수 관리
    public int[] multipleierThresholds;

    public Text scoreText; // UI에 띄워줄 텍스트를 위함
    public Text multiText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0"; // 처음 시작 시 점수는 0
        currentMultiplier = 1; // 기본 값, 곱해야 하기 때문에 1
    }

    // Update is called once per framed
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown) // 아무런 키가 눌리면
            {
                startPlaying = true;
                beatsroller.hasStarted = true; // 게임 매니저에서 한 번에 해결
                music.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit On Time");

        // 배수가 배열의 길이를 초과하지 않는지 확인
        if (currentMultiplier - 1 < multipleierThresholds.Length)
        {
            multiplierTracker++; // 조건 충족했으니 증가

            // 현재 배수를 증가시키기 위해 조건을 만족하는지 체크
            if (multipleierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0; // 초기화
                currentMultiplier++; // 증가
            }
        }

        // 콤보 텍스트 UI에 표시
        multiText.text = "Multiplier: x" + currentMultiplier;

        // currentScore += scorePerNote * currentMultiplier; // 점수 = 기본 값 * 콤보 값
        scoreText.text = "Score: " + currentScore; // 점수 텍스트 UI에 표시
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
    }
    public void NoteMissed()
    {
        Debug.Log("Missed Note");

        // 놓쳤을 경우 콤보는 다시 0
        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x" + currentMultiplier;
    }
}
