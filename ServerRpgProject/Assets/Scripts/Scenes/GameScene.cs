﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        Managers.Map.LoadMap(1);

        GameObject player = Managers.Resource.Instantiate("Creatures/Player");
        player.name = "Player";
        Managers.Object.Add(player);

        for (int i =0; i < 5; ++i)
        {
            GameObject monster = Managers.Resource.Instantiate("Creatures/Monster");
            monster.name = $"Monster_{i+1}";

            // 랜덤 위치  스폰
            Vector3Int pos = new Vector3Int()
            {
                x = Random.Range(-20, 20),
                y = Random.Range(-10, 10)
            };

            monster.transform.position = pos;


            Managers.Object.Add(monster);
        }
        //Managers.UI.ShowSceneUI<UI_Inven>();
        //Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;
        //gameObject.GetOrAddComponent<CursorController>();

        //GameObject player = Managers.Game.Spawn(Define.WorldObject.Player, "UnityChan");
        //Camera.main.gameObject.GetOrAddComponent<CameraController>().SetPlayer(player);

        ////Managers.Game.Spawn(Define.WorldObject.Monster, "Knight");
        //GameObject go = new GameObject { name = "SpawningPool" };
        //SpawningPool pool = go.GetOrAddComponent<SpawningPool>();
        //pool.SetKeepMonsterCount(2);
    }

    public override void Clear()
    {
        
    }
}
