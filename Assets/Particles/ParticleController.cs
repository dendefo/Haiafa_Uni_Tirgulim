using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] float progress;
    [SerializeField] ParticleSystem system;
    public void MoveBack()
    {
        //system.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        var Main = system.main;
        Main.simulationSpeed = 1;
    }
    public void MoveForward()
    {
        system.Emit(50);
    }
}