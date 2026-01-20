using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetManager : MonoBehaviour
{

    public string assetName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadAsset(assetName));
    }

    IEnumerator LoadAsset(string assetName)
    {
        AsyncOperationHandle handle = Addressables.LoadAssetAsync<GameObject>(assetName);
        while (!handle.IsDone)
        {
            Debug.Log(handle.PercentComplete);
            yield return null; // wait for next frame
        }
        
        Debug.Log("Finish loading " + assetName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
