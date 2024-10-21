using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSR; // ��ư�� ���� ��������Ʈ ������
    public Sprite defaultImage;
    public Sprite pressedImage;

    // Ű����� ��Ʈ�� ��������
    public KeyCode keyToPress;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress)) // Ű�� ������ ��
        {
            theSR.sprite = pressedImage; // �̹����� �ٲ�
        }
        if(Input.GetKeyUp(keyToPress)) // Ű�� ���� ��
        {
            theSR.sprite = defaultImage; // �⺻ �̹����� ���ƿ�
        }
    }
}
