using UnityEngine;

// Выгода и вся мощь этого подхода проявляет себя в комбинации стримов друг с другом.
// Скажем, слушать какое-то событие только между событием А и событием Б.
// На обычных коллбеках это все реализуется через какое-то внешнее состояние и очень легко ломается при изменениях.
// В случае observable — все сравнительно легко покрывается тестами и чутко относится к изменениям.

internal class MessageBase
{
    public MonoBehaviour Sender { get; private set; }
    public int Id { get; private set; }
    public object Data { get; private set; }

    public MessageBase(MonoBehaviour sender, int id, object data)
    {
        Sender = sender;
        Id = id;
        Data = data;
    }

    public static MessageBase Create(MonoBehaviour sender, int id, object data)
    {
        return new MessageBase(sender, id, data);
    }
}
