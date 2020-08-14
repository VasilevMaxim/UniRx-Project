using System.Collections;
using UniRx;
using UnityEngine;

/// <summary>
/// Тест вызовов коррутин UniRx.
/// </summary>
public class Coroutines : MonoBehaviour
{
    private void Start()
    {
        SequentialСall();
        // ParallelСall();
    }

    private void SequentialСall()
    {
        Observable.FromCoroutine(AsyncA)
            .SelectMany(AsyncB)
            .SelectMany(AsyncC)
            .Subscribe(_ =>
            {
                Debug.Log("end");
            })
            .AddTo(this);
    }

    private void ParallelСall()
    {
        // WhenAll принимает в себя Observable потоки.
        Observable.WhenAll
        ( 
          // Превращаем корутины в Observable.
          Observable.FromCoroutine(AsyncA), 
          Observable.FromCoroutine(AsyncB),
          Observable.FromCoroutine(AsyncC)
        ).Subscribe(_ =>
        { 
            Debug.Log("end");
        }).AddTo(this);
    }


    private IEnumerator AsyncA()
    {
        Debug.Log("A start");
        yield return new WaitForSeconds(1);
        Debug.Log("A end");
    }

    private IEnumerator AsyncB()
    {
        Debug.Log("B start");
        yield return new WaitForFixedUpdate();
        Debug.Log("B end");
    }

    private IEnumerator AsyncC()
    {
        Debug.Log("C start");
        yield return new WaitForEndOfFrame();
        Debug.Log("C end");
    }
}
