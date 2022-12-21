using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class StoreInfo : MonoBehaviour
{
    private static int currentStage = 1;

    private static int friendship = 0;
    private static int coin = 0;
    private static int hungry = 0;

    public static List<CoinMoney> CoinList;
    public static List<Hungryhp> HPList;
    public static List<NPCdata> npcData = new List<NPCdata>();

    public static void setFriendship(int score)
    {
        currentStage = StageManager.getStage();
        friendship = score;
        npcData[currentStage - 1].friendship_level = friendship;
        SaveNPCdataToJson();
    }

    public static void setCoin(int getCoin)
    {
        coin = getCoin;
        CoinList[0].Money = coin.ToString();
        coinHPSave();
    }

    public static void setHungry(int h)
    {
        hungry = h;
        HPList[0].HP = h.ToString();
        coinHPSave();
    }

    public static int getFriendship()
    {
        currentStage = StageManager.getStage();
        LoadNPCdataFromJson();
        friendship = npcData[currentStage - 1].friendship_level;
        return friendship;
    }

    public static int getCoin()
    {
        coinHPLoad();
        coin = int.Parse(CoinList[0].Money);
        return coin;
    }

    public static int getHungry()
    {
        coinHPLoad();
        hungry = int.Parse(HPList[0].HP);
        return hungry;
    }


    private static void coinHPSave()
    {

        // 돈 정보 저장
        string jdata_coin = JsonConvert.SerializeObject(CoinList);
        File.WriteAllText(Application.streamingAssetsPath + "/JSON_files/CoinText.txt", jdata_coin);

        // 체력 정보 저장
        string jdata_hp = JsonConvert.SerializeObject(HPList);
        File.WriteAllText(Application.streamingAssetsPath + "/JSON_files/HPText.txt", jdata_hp);


    }

    private static void coinHPLoad()
    {

        string jdata_coin = File.ReadAllText(Application.streamingAssetsPath + "/JSON_files/CoinText.txt");
        CoinList = JsonConvert.DeserializeObject<List<CoinMoney>>(jdata_coin);

        string jdata_hp = File.ReadAllText(Application.streamingAssetsPath + "/JSON_files/HPText.txt");
        HPList = JsonConvert.DeserializeObject<List<Hungryhp>>(jdata_hp);

    }

    private static void SaveNPCdataToJson()
    {
        string jdata = JsonConvert.SerializeObject(npcData);
        File.WriteAllText(Application.streamingAssetsPath + "/JSON_files/NPCdata.json", jdata);
    }

    private static void LoadNPCdataFromJson()
    {
        string jdata = File.ReadAllText(Application.streamingAssetsPath + "/JSON_files/NPCdata.json");
        npcData = JsonConvert.DeserializeObject<List<NPCdata>>(jdata);
    }

}
