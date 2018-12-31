using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
 	public Transform target;
	public float smoothTime = .15f;

    private Vector3 offset;
	private Vector3 velocity;

    void Start()
    {
        offset = new Vector3(0, 0, -10f);
    }

	void LateUpdate()
	{
		if(target != null) {
			transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, smoothTime);
		}
	}

	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}
}
