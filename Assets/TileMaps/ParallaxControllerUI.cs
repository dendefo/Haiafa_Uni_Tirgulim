using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxControllerUI : MonoBehaviour
{
    [SerializeField] List<RawImage> backgrounds;
    [SerializeField] List<float> parallaxScales;
    [SerializeField] Camera mainCamera;
    Vector3 cameraPreviousPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraPreviousPosition = mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 cameraDelta = mainCamera.transform.position - cameraPreviousPosition;
        for (int i = 0; i < backgrounds.Count; i++)
        {
            backgrounds[i].uvRect = new Rect(
                backgrounds[i].uvRect.x + (cameraDelta.x * parallaxScales[i] / backgrounds[i].texture.width),
                backgrounds[i].uvRect.y,
                backgrounds[i].uvRect.width,
                backgrounds[i].uvRect.height
            );
        }
        cameraPreviousPosition = mainCamera.transform.position;
    }
}
