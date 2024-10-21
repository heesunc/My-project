using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSR; // 버튼에 대한 스프라이트 렌더러
    public Sprite defaultImage;
    public Sprite pressedImage;

    // 키보드로 노트를 누르도록
    public KeyCode keyToPress;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress)) // 키를 눌렀을 때
        {
            theSR.sprite = pressedImage; // 이미지가 바뀜
        }
        if(Input.GetKeyUp(keyToPress)) // 키를 뗐을 때
        {
            theSR.sprite = defaultImage; // 기본 이미지로 돌아옴
        }
    }
}
