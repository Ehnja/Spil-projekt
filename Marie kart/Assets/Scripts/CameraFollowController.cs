using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset;
    public float followSpeed = 10;
    public float lookSpeed = 10;

    // Får kameraet til at kigge i retningen af objekt (bilen)
    void LookAtTarget()
    {
        Vector3 _lookDirection = objectToFollow.position - transform.position;
        Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);
    }

    // Får kameraet til at følge efter objekt (bilen)
    void MoveToTarget()
    {
        Vector3 _targetPos = objectToFollow.position +
                              objectToFollow.forward * offset.z +
                              objectToFollow.right * offset.x +
                              objectToFollow.up * offset.y;
        transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);
    }

    // Opdatere kameraets position
    private void FixedUpdate()
    {
        LookAtTarget();
        MoveToTarget();
    }
}
