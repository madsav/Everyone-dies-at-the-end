
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 distance = new Vector3(-30, 20,-60);
    [SerializeField] float distanceDamp = 10f;
    [SerializeField] float rotationalDamp = 10f;
    Transform mytransform;

   void Awake()
    {
        mytransform = transform;
    }

    void LateUpdate()
    {
        Vector3 toPosition = player.position + (player.rotation * distance);
        Vector3 currentPosition = Vector3.Lerp(mytransform.position, toPosition, distanceDamp * Time.deltaTime);
        mytransform.position = currentPosition;

        Quaternion toRotation = Quaternion.LookRotation(player.position - mytransform.position, player.up);
        Quaternion currentRotation = Quaternion.Slerp(mytransform.rotation, toRotation, rotationalDamp * Time.deltaTime);
        mytransform.rotation = currentRotation;
    }

}
