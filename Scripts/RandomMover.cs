using UnityEngine;
using System.Collections;

public class RandomMover : MonoBehaviour 
{
	public float minSpeed;
	public float maxSpeed;
	
	void Start ()
	{
		rigidbody.velocity = transform.forward * -1 * Random.Range (minSpeed, maxSpeed);
	}
}
