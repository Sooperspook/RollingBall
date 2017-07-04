using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    
    public Transform lookAtPlayer, baseTransform;
    public float slerpRate = 1;
    public float distLerpRate = 1;
    public float minDist = 10, maxDist = 20;

	
	
	void LateUpdate () {
        AdjustDistance();
        AdjustView();
    }

    void AdjustDistance()
    {
        var dir = lookAtPlayer.position - baseTransform.position;
        dir.y = 0;

        var dirLen = dir.magnitude;
        dir /= dirLen;

        var constrainedDist = Mathf.Clamp(dirLen, minDist, maxDist);
        var stepDist = Mathf.LerpUnclamped(dirLen, constrainedDist, Time.deltaTime * distLerpRate);

        baseTransform.position = lookAtPlayer.position - dir * stepDist;
    }

    void AdjustView()
    {
        var dir = lookAtPlayer.position - transform.position;
        dir = dir.normalized;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), slerpRate * Time.deltaTime);
    }
}

