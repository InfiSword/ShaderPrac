using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;       // 이동 속도
    public float rotationSpeed = 200f; // 회전 속도
    private Rigidbody rb;

    void Start()
    {
        // Rigidbody 컴포넌트를 가져옵니다.
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody 컴포넌트가 필요합니다.");
            enabled = false; // Rigidbody가 없으면 스크립트를 비활성화합니다.
        }
    }

    void FixedUpdate()
    {
        // 수평 입력 (A, D 키 또는 왼쪽, 오른쪽 화살표)
        float horizontalInput = Input.GetAxis("Horizontal2");
        // 수직 입력 (W, S 키 또는 위, 아래 화살표)
        float verticalInput = Input.GetAxis("Vertical2");

        // 회전 처리
        if (horizontalInput != 0)
        {
            // Time.deltaTime을 곱하여 프레임 독립적인 회전을 만듭니다.
            float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, rotationAmount, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }

        // 이동 처리
        if (verticalInput != 0)
        {
            // 현재 방향을 기준으로 전진 또는 후진 방향을 계산합니다.
            Vector3 moveDirection = transform.forward * verticalInput;
            // Time.deltaTime을 곱하여 프레임 독립적인 이동을 만듭니다.
            Vector3 moveAmount = moveDirection * moveSpeed * Time.deltaTime;
            // Rigidbody.MovePosition을 사용하여 물리 엔진에 안전하게 이동시킵니다.
            rb.MovePosition(rb.position + moveAmount);
        }
    }
}