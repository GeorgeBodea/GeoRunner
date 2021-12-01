using UnityEngine;

namespace Obstacles
{
	public class MovableObs : MonoBehaviour
	{
		public float distance = 5f; //Distance that the object moves 
		public bool horizontal = true; //If the movement is horizontal or vertical
		public float speed = 3f;
		public float offset; //If yo want to modify the position at the start 

		private bool isForward = true; //If the movement is out
		private Vector3 startPos;
   
		private void Awake()
		{
			startPos = transform.position;
			if (horizontal)
				transform.position += Vector3.right * offset;
			else
				transform.position += Vector3.forward * offset;
		}

		// Update is called once per frame
		private void Update()
		{
			if (horizontal)
			{
				if (isForward)
				{
					if (transform.position.x < startPos.x + distance)
					{
						transform.position += Time.deltaTime * speed * Vector3.right;
					}
					else
						isForward = false;
				}
				else
				{
					if (transform.position.x > startPos.x)
					{
						transform.position -= Time.deltaTime * speed * Vector3.right ;
					}
					else
						isForward = true;
				}
			}
			else
			{
				if (isForward)
				{
					if (transform.position.z < startPos.z + distance)
					{
						transform.position += Time.deltaTime * speed * Vector3.forward;
					}
					else
						isForward = false;
				}
				else
				{
					if (transform.position.z > startPos.z)
					{
						transform.position -= Time.deltaTime * speed * Vector3.forward ;
					}
					else
						isForward = true;
				}
			}
		}
	}
}