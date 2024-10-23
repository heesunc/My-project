using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo; // 떨어지는 속도
    public bool hasStarted; // 누르면 화면 아래로 스크롤 시작

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beatTempo = beatTempo / 60f; // 초당 얼마나 빨리 움직여야 하는지
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            // 아무 키나 누르면 true되도록
            /*if(Input.anyKeyDown)
            {
                hasStarted = true;
            }  */          
        }
        // 화살표가 y축으로 이동
        else
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
    }
}
