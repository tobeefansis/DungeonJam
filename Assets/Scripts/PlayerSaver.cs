using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;

public class PlayerSaver : MonoBehaviour
{

    public static void Set(Player player)
    {
        SetUserData(
            new Dictionary<string, string>()
            {
                {Constants.Money, player.Money.ToString() },
                {Constants.BestScore, player.BestScore.ToString() },
                {Constants.DeadPositions, JsonHelper.ToJson(player.DeadPositions.ToArray())}
            }
            );
    }
    static void SetUserData(Dictionary<string, string> data)
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>(data)
        }, result => Debug.Log("Update User Date Success"), LoginPlayFab.OnError);
    }
}