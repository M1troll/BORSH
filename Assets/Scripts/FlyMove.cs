using System.Collections;
using UnityEngine;


public class FlyMove : MonoBehaviour
{
    [SerializeField]
    Vector3 _endPoint = new Vector3(4.2f, 4.8f);

    [SerializeField]
    Vector3 _startPoint = new Vector3(-4.5f, -3.71f);

    [SerializeField]
    float _speed = 0.3f;
    
    private IEnumerator MovingCoroutine(Vector3 startPosition, Vector3 goalPosition)
    {
        float wTimer = 0;

        while (transform.position != goalPosition)
        {
            yield return transform.position = Vector3.Lerp(startPosition, goalPosition, wTimer);
            wTimer += Time.deltaTime * _speed;
        }
    }

    [ContextMenu("Как какать")]
    public void StartFlyMove()
    {
        transform.position = _startPoint;
        StartCoroutine(MovingCoroutine(_startPoint, _endPoint));
    }

    public void StartFlyMove(Vector3 start, Vector3 end, float speed = 0.3f)
    {
        _speed = speed;
        transform.position = start;
        StartCoroutine(MovingCoroutine(start, end));
    }

}
