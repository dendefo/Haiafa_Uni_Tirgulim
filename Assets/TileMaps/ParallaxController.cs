using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] List<SpriteRenderer> backgrounds;
    [SerializeField] List<float> parallaxScales;
    [SerializeField] Camera mainCamera;
    Vector3 cameraPreviousPosition;
    private void Awake()
    {
        cameraPreviousPosition = mainCamera.transform.position;
    }

    void Update()
    {
        
        Vector3 difference = mainCamera.transform.position - cameraPreviousPosition;
        for (int i = 0; i < backgrounds.Count; i++)
        {
            backgrounds[i].transform.Translate(difference * parallaxScales[i]);
        }
        cameraPreviousPosition = mainCamera.transform.position;
    }
}
