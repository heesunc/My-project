using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource music; // ���� �ֱ�
    public bool startPlaying; // �÷��� ����
    public BeatScroller beatsroller; // ��ũ�� ���� ��Ʈ��
    public static GameManager instance; // �̱���

    public int currentScore; // ���� �հ�
    public int scorePerNote = 100; // ��Ʈ ����

    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public int currentMultiplier; // ���� ���
    public int multiplierTracker; // ���� ��� ����
    public int[] multipleierThresholds;

    public Text scoreText; // UI�� ����� �ؽ�Ʈ�� ����
    public Text multiText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0"; // ó�� ���� �� ������ 0
        currentMultiplier = 1; // �⺻ ��, ���ؾ� �ϱ� ������ 1
    }

    // Update is called once per framed
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown) // �ƹ��� Ű�� ������
            {
                startPlaying = true;
                beatsroller.hasStarted = true; // ���� �Ŵ������� �� ���� �ذ�
                music.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit On Time");

        // ����� �迭�� ���̸� �ʰ����� �ʴ��� Ȯ��
        if (currentMultiplier - 1 < multipleierThresholds.Length)
        {
            multiplierTracker++; // ���� ���������� ����

            // ���� ����� ������Ű�� ���� ������ �����ϴ��� üũ
            if (multipleierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0; // �ʱ�ȭ
                currentMultiplier++; // ����
            }
        }

        // �޺� �ؽ�Ʈ UI�� ǥ��
        multiText.text = "Multiplier: x" + currentMultiplier;

        // currentScore += scorePerNote * currentMultiplier; // ���� = �⺻ �� * �޺� ��
        scoreText.text = "Score: " + currentScore; // ���� �ؽ�Ʈ UI�� ǥ��
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

        // ������ ��� �޺��� �ٽ� 0
        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x" + currentMultiplier;
    }
}
