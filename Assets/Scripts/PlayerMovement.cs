using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 2.0f; // �ӵ� ����
    private float h, v;

    private Animator anim;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); // Rigidbody ������Ʈ ��������
        anim.SetTrigger("Idle"); // �ʱ� ���� ����
    }

    // Update is called once per frame
    void Update()
    {
        // Ű���� �Է��� �ǽð����� ó��
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        // �̵� ���� �� �ӵ� ��� (���� ��� �� ����)
        Vector3 movement = new Vector3(h, 0, v).normalized;
        float movementSpeed = movement.magnitude;

        // �ִϸ��̼� �ӵ� ������Ʈ
        anim.SetFloat("Speed", movementSpeed);

        // ĳ���� ȸ�� �� �̵� ó��
        if (movementSpeed > 0.1f) // �̵� �ÿ��� ȸ�� �� �̵� ó��
        {
            // ȸ�� ó�� (Slerp ����� �ε巴��)
            Quaternion newRotation = Quaternion.LookRotation(movement);
            rb.MoveRotation(Quaternion.Slerp(transform.rotation, newRotation, 0.2f));

            // Rigidbody�� ����� �̵� ó��
            rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
        }
        else
        {
            // ���� �� Idle �ִϸ��̼� ���� ����
            anim.SetTrigger("Idle");
        }
    }
}
