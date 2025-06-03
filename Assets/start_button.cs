using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectClickExample : MonoBehaviour
{
    // クリックされたときに呼び出されるメソッド
    public void OnClickButton()
    {
        print($"オブジェクト {name} がクリックされたよ！");
    }
}