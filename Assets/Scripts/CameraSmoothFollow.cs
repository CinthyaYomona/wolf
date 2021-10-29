using UnityEngine;
using System.Collections;

public class CameraSmoothFollow : MonoBehaviour {

    public Transform target;
    public float	 distance = 10.0f;
    public float 	 height = 3.0f;
	public float 	 baseDistance = 0.0f;
	public bool 	 followBehind = true;


	public float damping = 5.0f;
	public bool  smoothRotation = true;
    public float rotationDamping = 10.0f;

    void FixedUpdate()
    {
		Vector3 wantedPosition, targetPosition;
		targetPosition = target.transform.position + new Vector3 (0, baseDistance, 0);
        if (followBehind)
			wantedPosition = target.TransformPoint (0, height, -distance);
        else
			wantedPosition = target.TransformPoint(0, height, distance) + new Vector3 (0, 2, 0) ;

        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

        if (smoothRotation)
        {
            Quaternion wantedRotation = Quaternion.LookRotation(targetPosition - transform.position, target.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
        }
        else transform.LookAt(targetPosition, target.up);
    }

	public void setTarget( Transform tar )
	{
		target = tar;
	} 

	public Transform getTarget( )
	{
		return target;
	} 


	public void setFollowBehind( bool behind )
	{
		followBehind = behind;
	}

	public bool getFollowBehind() {
		return followBehind;
	}

	public void setDistance( float dist ) {
		distance = dist;
	}

	public void addDistance( float dist ) {
		distance += dist;
	}

	public float getDistance() {
		return distance;
	}

	public void setHeight( float hei ) {
		height = hei;
	}

	public void addHeight( float hei ) {
		height += hei;
	}

	public float getHeight() {
		return height;
	}

	public bool changeView() {
		followBehind = !followBehind;
		return followBehind;
	}


}
