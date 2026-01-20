using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "HealthData", menuName = "SO/HealthData")]
public class HealthData : ScriptableObject
{

    [Header("Testing")]
    [Delayed] public int MaxHealth;
    [TextArea] public string UniqueID;
    [Space(50)]
    [GradientUsage(true, ColorSpace.Linear)] public Gradient Lol;
    public DamageType damageType;

    [Tooltip("Damage dealt when hitting an enemy")]
    public int Damage;

    [Range(0, 10)] public int Minhealth;
    public float GetCurrentHealth()
    {
        return PlayerPrefs.GetFloat(UniqueID, MaxHealth);
    }
    public void SetCurrentHealth(float health)
    {
        PlayerPrefs.SetFloat(UniqueID, health);
    }

    private void Reset()
    {
        MaxHealth = 100;
        Minhealth = 0;
        UniqueID = System.Guid.NewGuid().ToString();
    }

    private void OnValidate()
    {
        if (MaxHealth < Minhealth)
        {
            MaxHealth = Minhealth;
        }
    }

}
public enum DamageType
{
    [InspectorName("Physical Damage")]
    Physical,
    [InspectorName("Magical Damage")]
    Magical,
    [InspectorName("True Damage")]
    True
}
