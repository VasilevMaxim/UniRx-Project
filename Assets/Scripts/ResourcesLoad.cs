using UniRx;
using UnityEngine;

/// <summary>
/// Тест загрузки ресурсов с помощью UniRx.
/// </summary>
public class ResourcesLoad : MonoBehaviour
{
    private void Start()
    {
        var sprite = GetComponent<SpriteRenderer>();

        Resources.LoadAsync<Sprite>("sprite")
            .AsAsyncOperationObservable() // Превращаем загрузку в Observable поток
            .Subscribe(request => 
            {
                if (request.asset != null)
                { 
                    Sprite spriteResurce = request.asset as Sprite;
                    sprite.sprite = spriteResurce;
                }
            })
            .AddTo(this);
    }
}
