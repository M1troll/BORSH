using System.Collections;
using UnityEngine;

public class FallingIce : MonoBehaviour
{
    [SerializeField]
    Vector3 _startPoint = new Vector3(0.5748f, 5.8228f);

    [SerializeField]
    Vector3 _endPoint = new Vector3(0.73f, -2.43f);

    [SerializeField]
    float _speed = 1.4f;

    void Start()
    {
        _startPoint = new Vector3(0.5748f, 5.8228f);
        _endPoint = new Vector3(0.73f, -2.43f);
    }

    private IEnumerator MovingCoroutine(Vector3 startPosition, Vector3 goalPosition)
    {
        float wTimer = 0;

        const int cost = 75;
        const int passiveMold = 1;

        if (GlobalData.addMoldPassiveCount + passiveMold >= passiveMold && GlobalData.moldCount + cost >= cost)
        {
            while (transform.position != goalPosition)
            {
                yield return transform.position = Vector3.Lerp(startPosition, goalPosition, wTimer);
                wTimer += Time.deltaTime * _speed;
            }
        }
    }

    [ContextMenu("Как падать?")]
    public void DropDownIceberg()
    {
        transform.position = _startPoint;
        StartCoroutine(MovingCoroutine(_startPoint, _endPoint));
    }

    public void DropDownIceberg(Vector3 start, Vector3 end, float speed = 1.4f)
    {
        _speed = speed;
        transform.position = start;
        StartCoroutine(MovingCoroutine(start, end));
    }
}
