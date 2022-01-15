using UnityEngine;

public class ChangeBallColor : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var cameraList = FindObjectsOfType<Camera>();

            foreach (var camera in cameraList)
                if (camera.name == "Canvas Camera")
                {
                    var ray = camera.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out hit) && hit.transform.gameObject == gameObject)
                        PlayerPrefs.SetString(Constants.BallMaterial, hit.transform.name);
                }
        }
    }
}