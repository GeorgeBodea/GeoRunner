using UnityEngine;

public class PreviewBallController : MonoBehaviour
{
    private void Update()
    {
        var ballMaterialName = PlayerPrefs.GetString(Constants.BallMaterial);
        GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/" + ballMaterialName);
    }
}