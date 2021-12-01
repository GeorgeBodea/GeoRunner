using UnityEngine;

namespace Obstacles
{
    public class Bounce : MonoBehaviour
    {
        public float force = 10f;
        public float stunTime = 0.5f;
        private Vector3 hitDir;

        private void OnCollisionEnter(Collision collision)
        {
            foreach (var contact in collision.contacts)
                if (collision.gameObject.CompareTag("Player"))
                {
                    hitDir = -(contact.point - collision.transform.position).normalized;
                    collision.gameObject.GetComponent<SphereMovement>().HitPlayer(hitDir * force, stunTime);
                    return;
                }
        }
    }
}