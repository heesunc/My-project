using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f; // �ӵ�
    float h, v;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // Point 1.
        h = Input.GetAxis("Horizontal");        // ������
        v = Input.GetAxis("Vertical");          // ������

        // Point 2.
        transform.position += new Vector3(h, 0, v) * speed * Time.deltaTime;
    }
}
