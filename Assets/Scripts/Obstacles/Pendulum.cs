using UnityEngine;

namespace Obstacles
{
	public class Pendulum : MonoBehaviour
	{
		public float speed = 1.5f;
		public float angleLimit = 75f; //Limit in degrees of the movement
		public bool randomStart; //If you want to modify the start position
		private float startAngle;

		// Start is called before the first frame update
		private void Awake()
		{
			if (randomStart)
				startAngle = Random.Range(-1f, 1f);
			else
			{
				float angle = transform.eulerAngles.z;
				if (angle <= angleLimit)
					startAngle = angle/angleLimit;
				else
				{
					startAngle = (transform.eulerAngles.z-360f) / angleLimit;
				}
			}
		}

		// Update is called once per frame
		private void Update()
		{
			float angle = angleLimit * Mathf.Sin((Time.time + startAngle) * speed);
			transform.localRotation = Quaternion.Euler(0, 0, angle);
		}
	}
}