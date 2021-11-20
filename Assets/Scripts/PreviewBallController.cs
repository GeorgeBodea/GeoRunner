using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewBallController : MonoBehaviour
{
    void Update()
    {
        string ballMaterialName = PlayerPrefs.GetString(Constants.BallMaterial);
        GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/" + ballMaterialName);
    }
}
