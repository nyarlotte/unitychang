﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




//Unityちゃんに関する基本パラメータに関するスクリプト
public class Status2 : MonoBehaviour
{
    public  int MaxHP = 150;　//maxHP
    public  int AT;
    public  int HP = 100;
    public  Text UiHP;
    public  Slider slider;
    public  List<string> Bug = new List<string>();

    void Awake () {
	DontDestroyOnLoad(gameObject);　//シーン移動でゆにてぃちゃんが変化しないように
  slider = GameObject.Find("Slider").GetComponent<Slider>();
  UiHP   = GameObject.Find("HPText").GetComponent<Text>();
}
    //public  int CurrentHP;

    public void Status(){//ステータス用関数

      if(HP > MaxHP){
        //MaxHPを超えないように
         HP  = MaxHP;
      }
    }


    public void HPGuI(){
      //スライダーのGUIを表示させるための
      slider.maxValue = MaxHP;
      UiHP.text = "HP"+ HP.ToString() + "/" + MaxHP.ToString();
      slider.value = HP;

    }
    void Update(){
      //毎フレーム変化していくだろうモノをぶち込む
      Death();
      Status();
      HPGuI();
    }

    public void Item(){//アイテム用関数
//アイテムを格納するための配列うまくいかなかったので後日改修
      if(Bug[0]=="リンゴ"){
          Debug.Log(Bug[0]);
      }
      if(Bug.Count==2){
        Debug.Log("これ以上拾えません");
      }

    }
    public void Death(){//ゲームオーバー用の関数
      if(HP <= 0 ){
        //Destroy(gameObject);
        SceneManager.LoadScene ("GameOver");
      }
    }

　
}
　　


//もし赤いリンゴを食べたら最大HPが5UPするとかいいんじゃないかな
//その場合は赤いリンゴを食べた回数を記録する変数が必要になるのだろうか
//if(eatApple== true){ hp =+5i 　i = i+1} みたいな記述？
