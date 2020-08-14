using UniRx;
using UnityEngine;

/// <summary>
/// Тест таймера с помощью UniRx.
/// </summary>
public class Timers : MonoBehaviour
{
    private CompositeDisposable _disposables;

    private void OnEnable()
    {
        _disposables = new CompositeDisposable();
    }

    private void Start()
    {
        Timer3Second();
        Timer1SecondRepeat();
    }

    private void Timer3Second()
    {
        Observable.Timer(System.TimeSpan.FromSeconds(3)) // создаем timer Observable
            .Subscribe(_ =>
            {
                // подписываемся
                Debug.Log("Данное действие происходит через 3 секунды после вызова метода");
            })
            .AddTo(this); // привязываем подписку к disposable
    }

    private void Timer1SecondRepeat()
    {
        Observable.Timer(System.TimeSpan.FromSeconds(1))
            .Repeat()
            .Subscribe(_ =>
            {
                Debug.Log("Данное действие происходит через 1 секунду");
            })
            .AddTo(_disposables);
    }

    private void OnDisable()
    {
        if (_disposables != null)
            _disposables.Dispose();
    }
}
