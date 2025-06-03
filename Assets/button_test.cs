using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_test : MonoBehaviour
{
    public void Onclick_start()
    {
        Debug.Log("スタートボタンがクリックされた");
        script_mother.game_state = "戦闘準備";
        GameManager.Game_start();
    }
    public void Onclick_chara()
    {
        Debug.Log("キャラクターボタンがクリックされた");
        script_mother.game_state = "キャラクター準備";
        GameManager.go_to_zukan();
    }
    public void Onclick_setting()
    {
        Debug.Log("設定ボタンがクリックされた");
        script_mother.game_state = "設定";
    }
    public void Onclick_test()
    {
        Debug.Log("クリックを確認");
    }
}
