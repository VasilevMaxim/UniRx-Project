using UniRx;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    private CompositeDisposable _disposables;

    private void OnEnable()
    {
        _disposables = new CompositeDisposable();

        MessageBroker.Default
            .Receive<MessageBase>()
            .Where(msg => msg.Id == 0)
            .Subscribe(msg =>
            {
                string data = (string) msg.Data;
                Debug.Log("sender:" + msg.Sender.name + " receiver:" + name + " data:" + data);
            })
            .AddTo(_disposables);
    }

    private void OnDisable()
    {
        if (_disposables != null)
            _disposables.Dispose();
    }
}
