using UnityEngine;

public class OrbitalTarget : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float travelDuration;
    public float timer;
    public bool moveToB =  true;
    void Update()
    {

        timer += Time.deltaTime;
        float t = timer/travelDuration;

        Vector3 start = moveToB ? pointA.position : pointB.position;
        Vector3 target = moveToB ? pointA.position : pointB.position;

        transform.position += Vector3.Lerp(start, target, t);

        if (moveToB)
        {
            transform.position = Vector3.Lerp(
                pointA.position,
                pointB.position,
                t
            );
        }
        else
        {
            transform.position = Vector3.Lerp(
                pointB.position,
                pointA.position,
                t
            );
        }

       if(t > 1f)
        {
            timer = 0f;
            moveToB = !moveToB;
        }
    }

    public void OnMouseDown()
    {
        if(GameManager.Instance != null)
        {
        GameManager.Instance.AddScore(10);
        }
        
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HazardZone"))
        {
            GameManager.Instance.DeductScore(5);
        }
    }

   
}
