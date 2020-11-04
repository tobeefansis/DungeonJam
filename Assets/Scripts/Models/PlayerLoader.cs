using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PlayFab;
using PlayFab.ClientModels;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerLoader
{
    public static event Action<Player> OnLoad;
    public static Player player = null;

    public static void Get()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest()
        {
            PlayFabId = LoginPlayFab.Instance.PlayFabId,
            Keys = null
        }, 
        GetUserDateSuccess, 
        LoginPlayFab.OnError);

    }


    private static void GetUserDateSuccess(GetUserDataResult result)
    {
        player = new Player();
        var data = result.Data;

        if (data.ContainsKey(Constants.Money))
        {
            player.Money = int.Parse(data[Constants.Money].Value);
        }

        if (data.ContainsKey(Constants.BestScore))
        {
            player.BestScore = int.Parse(data[Constants.BestScore].Value);
        }

        if (data.ContainsKey(Constants.DeadPositions))
        {
            player.DeadPositions = JsonHelper.FromJson<Vector2>(data[Constants.DeadPositions].Value).ToList();
        }
        OnLoad?.Invoke(player);
    }
}