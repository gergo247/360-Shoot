using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 10f;
    public Vector3 offset;

    private Vector3 velocity;
    //after update
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed*Time.deltaTime);
        transform.position = smoothedPosition;
        transform.LookAt(target);
      }


    //private Vector2 velocity;
    //
    //public float smoothTimeX;
    //public float smoothTimeY;
    //
    //// Update is called once per frame
    //void LateUpdate()
    //{
    //    float posx = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref velocity.x, smoothTimeX);
    //    float posy = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref velocity.y, smoothTimeY);
    //
    //    transform.position = new Vector3(posx, posy, transform.position.z);
    //}
}
