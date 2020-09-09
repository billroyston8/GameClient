using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    //public enum MoveType { Time, Speed }

    public int id;
    public GameObject explosionPrefab;
    private int throwCounter = 0;

    public void Initialize(int _id)
    {
        id = _id;
    }

    public void Move(Vector3 _position)
    {
        //if (throwCounter < 10)
        //{
            transform.position = _position;
        //    throwCounter++;
        //}
        //else
        //{
        //    StartCoroutine(LerpPosition(_position, .1f));
        //}
    }

    public void Explode(Vector3 _position)
    {
        transform.position = _position;
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        GameManager.projectiles.Remove(id);
        Destroy(gameObject);
    }

    //private IEnumerator Translation(Transform thisTransform, Vector3 startPos, Vector3 endPos, float value, MoveType moveType)
    //{
    //    float rate = (moveType == MoveType.Time) ? 1.0f / value : 1.0f / Vector3.Distance(startPos, endPos) * value;
    //    float t = 0.0f;
    //    while (t < 1.0)
    //    {
    //        t += Time.deltaTime * rate;
    //        thisTransform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0.0f, 1.0f, t));
    //        yield return null;
    //    }
    //}

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
