using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource music; // ���� �ֱ�
    public bool startPlaying; // �÷��� ����
    public BeatScroller beatsroller; // ��ũ�� ���� ��Ʈ��
    public static GameManager instance; // �̱���

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;    
    }

    // Update is called once per framed
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown) // �ƹ��� Ű�� ������
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
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");
    }
}
