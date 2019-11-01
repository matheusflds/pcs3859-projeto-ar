using UnityEngine;

public class FollowGyro : MonoBehaviour
{

    [Header("Tweaks")]
    [SerializeField] private Quaternion baseRotation = new Quaternion(0,0,1,0);

    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        GyroManager.Instance.EnableGyro();
    }

    private void FixedUpdate() {
    // transform.rotation = GyroManager.Instance.GetGyroRotation() * baseRotation;
        transform.rotation = new Quaternion(0.5f, 0.5f, -0.5f, 0.5f) * GyroManager.Instance.GetGyroRotation() * baseRotation;

        // transform.rotation = new Quaternion(0.5f, 0.5f, -0.5f, 0.5f) * GyroManager.Instance.GetGyroRotation() * baseRotation;
        Vector3 velocity = rb.velocity;
        // rb.velocity = Vector3.ClampMagnitude(velocity, 5f);

    }

}
