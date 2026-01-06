using DG.Tweening;
using System.Collections;
using UnityEngine;

public class AnimationControllerTest : MonoBehaviour
{
    [SerializeField] Transform StartPosition;
    [SerializeField] Transform EndPosition;
    [SerializeField] float time = 2;
    [SerializeField] AnimationCurve curve;
    [SerializeField] AnimationCurve curveColor;
    [SerializeField] SpriteRenderer spriteRenderer;

    [ContextMenu("Start Moving")]
    public void StartMoving()
    {
        transform.position = StartPosition.position;
        transform.DOMove(EndPosition.position, time).SetEase(curve);
        spriteRenderer.color = Color.white;
        spriteRenderer.DOColor(Color.black, time).SetEase(curveColor);
    }
    [ContextMenu("Stop")]
    public void Stop()
    {
        transform.DOKill();
    }
    Vector3 GetPos()
    {
        return transform.position;
    }
    void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }

    IEnumerator MovingCoroutine()
    {
        float elapsedTime = 0;
        while (elapsedTime < time)
        {
            float t = elapsedTime / time;
            t = curve.Evaluate(t);
            SetPos(Vector3.LerpUnclamped(StartPosition.position, EndPosition.position, t));

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = EndPosition.position;
    }
}
