using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(TMPro.TMP_Text))]
public class HPObserver : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text hpText;
    [SerializeField] IntEventBuffer healthData;
    private void OnEnable()
    {
        healthData.Subscribe(OnHealthChanged);
    }
    private void OnDisable()
    {
        healthData.Unsubscribe(OnHealthChanged);
    }

    private void OnHealthChanged(int data)
    {
        hpText.text = "HP: " + data;
    }
}
