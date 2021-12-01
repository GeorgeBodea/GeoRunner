using System.Collections;
using UnityEngine;

namespace Obstacles
{
	public class FallPlat : MonoBehaviour
	{
		public float fallTime = 0.5f;
		
		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.CompareTag("Player"))
			{
				StartCoroutine(Fall(fallTime));
			}
		}

		private IEnumerator Fall(float time)
		{
			yield return new WaitForSeconds(time);
			Destroy(gameObject);
		}
	}
}
