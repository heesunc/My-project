using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource music; // 음악 넣기
    public bool startPlaying; // 플레이 시작
    public BeatScroller beatsroller; // 스크롤 시작 컨트롤
    public static GameManager instance; // 싱글톤

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
            if(Input.anyKeyDown) // 아무런 키가 눌리면
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
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");
    }
}
