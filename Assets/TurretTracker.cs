using UnityEngine;

public class TurretTracker : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed;

    private void Update()
    {
        if (target == null)
            return;

        Vector3 directionToTarget =
            (target.position - transform.position).normalized;

        Quaternion targetRotation =
            Quaternion.LookRotation(directionToTarget);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }

}

