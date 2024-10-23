using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo; // �������� �ӵ�
    public bool hasStarted; // ������ ȭ�� �Ʒ��� ��ũ�� ����

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beatTempo = beatTempo / 60f; // �ʴ� �󸶳� ���� �������� �ϴ���
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            // �ƹ� Ű�� ������ true�ǵ���
            /*if(Input.anyKeyDown)
            {
                hasStarted = true;
            }  */          
        }
        // ȭ��ǥ�� y������ �̵�
        else
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
    }
}
