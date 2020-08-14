using UniRx;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    private void Start()
    {
        MessageBroker.Default
            .Publish(MessageBase.Create
            (
                  this,
                  0,
                  "Attack!"
            ));
    }
}
