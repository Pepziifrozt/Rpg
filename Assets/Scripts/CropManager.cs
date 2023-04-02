using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    bool isPlanted = false;
    public SpriteRenderer plant;
    CircleCollider2D cirlceCollider;
    

    public Sprite[] plantStages;
    int plantStage = 0;
    float timeBtwStages = 2f;
    float timer;

    private bool _playerHere;

    private void Start()
    {
        
    }


    private void Update()
    {
        if (isPlanted)
        {
            timer -= Time.deltaTime;

           if (timer <= 0 && plantStage < plantStages.Length - 1)
           {
                timer = timeBtwStages;
                plantStage++;
                UpdatePlant();
           }
        }
        if (_playerHere)
        {
            if (Input.GetKeyDown(KeyCode.F) && isPlanted && plantStage == plantStages.Length - 1)
            {
                Harvest();
                Debug.Log("Harvest");
            }
            else if (Input.GetKeyDown(KeyCode.F) && !isPlanted)
            {
                Plant();
                Debug.Log("Plant");
            }
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerHere = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerHere = false;
        }
    }
    void Harvest()
    {
        Debug.Log("Harvested");
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }

    void Plant()
    {
        Debug.Log("Planted");
        isPlanted = true;
        plantStage = 0;
        UpdatePlant();
        timer = timeBtwStages;
        plant.gameObject.SetActive(true);
    }

    void UpdatePlant()
    {
        plant.sprite = plantStages[plantStage];
        
    }

}
