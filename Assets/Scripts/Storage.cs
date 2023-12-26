using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private Dictionary<int, int> available_seeds = new Dictionary<int, int>();
    private Dictionary<int, int> available_plants = new Dictionary<int, int>();
    private Dictionary<int, int> price_to_sold = new Dictionary<int, int>();
    private Dictionary<int, int> price_to_buy = new Dictionary<int, int>();
    private int money = 100;
    private int birdfood = 1;
    private int eggs = 0;
    private int price_to_buy_feed = 100;
    private int price_to_sold_egg = 30;
    private int price_to_add_patche = 250;
    private GameObject[] patches;
    public Dictionary<int, int> Available_seeds { get => available_seeds; set => available_seeds = value; }
    public Dictionary<int, int> Available_plants { get => available_plants; set => available_plants = value; }
    public Dictionary<int, int> Price_to_sold { get => price_to_sold; set => price_to_sold = value; }
    public Dictionary<int, int> Price_to_buy { get => price_to_buy; set => price_to_buy = value; }
    public int Money { get => money; set => money = value; }
    public int Birdfood { get => birdfood; set => birdfood = value; }
    public int Eggs { get => eggs; set => eggs = value; }

    [SerializeField]
    private List<TextMeshProUGUI> seeds;
    [SerializeField]
    private List<TextMeshProUGUI> plants;
    [SerializeField]
    private TextMeshProUGUI moneyText;
    [SerializeField]
    private TextMeshProUGUI birdfoodText;
    [SerializeField]
    private TextMeshProUGUI eggsText;
    private void Start()
    {
        available_seeds.Add(0, Random.Range(1, 5));
        available_seeds.Add(1, Random.Range(1, 5));
        available_seeds.Add(2, Random.Range(1, 5));

        available_plants.Add(0, 0);
        available_plants.Add(1, 0);
        available_plants.Add(2, 0);

        price_to_sold.Add(0, 12);
        price_to_sold.Add(1, 18);
        price_to_sold.Add(2, 24);

        price_to_buy.Add(0, 10);
        price_to_buy.Add(1, 15);
        price_to_buy.Add(2, 20);
        patches = GameObject.FindGameObjectsWithTag("Patche");
        SetDisable();
        //StartCoroutine(Print());
    }

    private void Update()
    {
        for (int i = 0; i < available_seeds.Count; i++)
        {
            seeds[i].text = available_seeds[i].ToString();
        }
        for (int i = 0; i < available_plants.Count; i++)
        {
            plants[i].text = available_plants[i].ToString();
        }
        moneyText.text = money.ToString();
        birdfoodText.text = birdfood.ToString();
        eggsText.text = eggs.ToString();

    }

    private void Print()
    {
        var end_time = Time.realtimeSinceStartup + 15f;
        string _str = "";
        foreach (var seed in available_seeds)
        {
            _str += seed.Key + ":" + seed.Value + ";";
        }
        Debug.Log("Seeds: " + _str);
        _str = "";
        foreach (var plant in available_plants)
        {
            _str += plant.Key + ":" + plant.Value + ";";
        }
        Debug.Log("Plants: " + _str);
    }

    private void OnMouseDown()
    {
        Print();
    }

    public void SoldPlant(int select_plant)
    {
        if (Available_plants[select_plant] > 0)
        {
            PlaySoundMoney();
            Available_plants[select_plant] -= 1;
            money += Price_to_sold[select_plant];
        }
    }

    public void BuySeed(int select_seed)
    {
        if (money >= Price_to_buy[select_seed])
        {
            PlaySoundMoney();
            Available_seeds[select_seed] += 1;
            money -= Price_to_buy[select_seed];
        }
    }

    public void BuyFeed()
    {
        if (money >= price_to_buy_feed)
        {
            PlaySoundMoney();
            Birdfood += 1;
            money -= price_to_buy_feed;
        }
    }

    public void SoldEgg()
    {
        if (eggs > 0)
        {
            PlaySoundMoney();
            eggs -= 1;
            money += price_to_sold_egg;
        }
    }

    private void SetDisable()
    {
        for (int i = 1; i < patches.Length; i++)
        {
            patches[i].SetActive(false);
        }
    }

    public void AddPathce()
    {
        for (int i = 1; i < patches.Length; i++)
        {
            if (patches[i].active == false && money >= price_to_add_patche)
            {
                PlaySoundMoney();
                patches[i].SetActive(true);
                money -= price_to_add_patche;
                break;
            }
        }
    }

    private void PlaySoundMoney()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
