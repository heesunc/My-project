using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 2.0f; // 속도 변수
    private float h, v;

    private Animator anim;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); // Rigidbody 컴포넌트 가져오기
        anim.SetTrigger("Idle"); // 초기 상태 설정
    }

    // Update is called once per frame
    void Update()
    {
        // 키보드 입력을 실시간으로 처리
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        // 이동 방향 및 속도 계산 (단일 계산 후 재사용)
        Vector3 movement = new Vector3(h, 0, v).normalized;
        float movementSpeed = movement.magnitude;

        // 애니메이션 속도 업데이트
        anim.SetFloat("Speed", movementSpeed);

        // 캐릭터 회전 및 이동 처리
        if (movementSpeed > 0.1f) // 이동 시에만 회전 및 이동 처리
        {
            // 회전 처리 (Slerp 사용해 부드럽게)
            Quaternion newRotation = Quaternion.LookRotation(movement);
            rb.MoveRotation(Quaternion.Slerp(transform.rotation, newRotation, 0.2f));

            // Rigidbody를 사용한 이동 처리
            rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
        }
        else
        {
            // 멈출 때 Idle 애니메이션 상태 유지
            anim.SetTrigger("Idle");
        }
    }
}
