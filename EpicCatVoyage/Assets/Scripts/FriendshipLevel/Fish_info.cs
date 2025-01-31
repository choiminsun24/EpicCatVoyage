using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Level_Controller;
using Newtonsoft.Json;
using System.IO;

public class Fish_info : MonoBehaviour
{
    public List<NPCdata> npcData;

    public GameObject fishInfoScreen;
    public Text fishInfoLike;

    public Text fishInfoTalk;
    public string[] talks;

    public Animator screenAnim;

    // Start is called before the first frame update
    void Start()
    {
        screenAnim = fishInfoScreen.GetComponent<Animator>();
        npcData = StoreInfo.getFriendshipList();
        fishInfoLike.text = "ȣ���� : " + npcData[3].friendship_level.ToString();

        int index = (npcData[3].friendship_level - 1) / 25;
        fishInfoTalk.text = talks[index];
    }

    public void clickFish()
    {
        screenAnim.SetTrigger("downFish");
    }

    public void clickBtn()
    {
        screenAnim.SetTrigger("upFish");
    }
}
