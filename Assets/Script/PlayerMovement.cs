using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;       // �̵� �ӵ�
    public float rotationSpeed = 200f; // ȸ�� �ӵ�
    private Rigidbody rb;

    void Start()
    {
        // Rigidbody ������Ʈ�� �����ɴϴ�.
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody ������Ʈ�� �ʿ��մϴ�.");
            enabled = false; // Rigidbody�� ������ ��ũ��Ʈ�� ��Ȱ��ȭ�մϴ�.
        }
    }

    void FixedUpdate()
    {
        // ���� �Է� (A, D Ű �Ǵ� ����, ������ ȭ��ǥ)
        float horizontalInput = Input.GetAxis("Horizontal2");
        // ���� �Է� (W, S Ű �Ǵ� ��, �Ʒ� ȭ��ǥ)
        float verticalInput = Input.GetAxis("Vertical2");

        // ȸ�� ó��
        if (horizontalInput != 0)
        {
            // Time.deltaTime�� ���Ͽ� ������ �������� ȸ���� ����ϴ�.
            float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, rotationAmount, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }

        // �̵� ó��
        if (verticalInput != 0)
        {
            // ���� ������ �������� ���� �Ǵ� ���� ������ ����մϴ�.
            Vector3 moveDirection = transform.forward * verticalInput;
            // Time.deltaTime�� ���Ͽ� ������ �������� �̵��� ����ϴ�.
            Vector3 moveAmount = moveDirection * moveSpeed * Time.deltaTime;
            // Rigidbody.MovePosition�� ����Ͽ� ���� ������ �����ϰ� �̵���ŵ�ϴ�.
            rb.MovePosition(rb.position + moveAmount);
        }
    }
}