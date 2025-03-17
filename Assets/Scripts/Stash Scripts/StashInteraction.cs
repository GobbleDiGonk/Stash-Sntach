using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StashInteraction : MonoBehaviour, Iinteractable

{
    int randomNumber;
    public GameObject stashMoneyPrefab;
    public GameObject bombPrefab;
    public Transform spawnPoint;
    bool isInteractable;
    Renderer stashRenderer;

    public void interact()
    {
        Debug.Log(Random.Range(0, 100));

        Chance();
    }
    
    private void Chance()
    {
        //range of random numbers
        randomNumber = Random.Range(1, 101);

        bool isInteractable = GetComponent<BoxCollider>().enabled = true;
        stashRenderer = GetComponent<Renderer>();

        //checks if a number is greater or equal to 90
        if(randomNumber >= 90)
        {
            //spawns a bomb, killing player and ending game
            Instantiate(bombPrefab, spawnPoint.position, spawnPoint.rotation);
            isInteractable = false;
            SceneManager.LoadScene("GameOverFailiure");
        }

        if (randomNumber <= 10 )
        {
            //player wins the game and ends the game
            Instantiate(stashMoneyPrefab,spawnPoint.position, spawnPoint.rotation);
            isInteractable = false;
            SceneManager.LoadScene("GameOverSuccess");
        }

        if(randomNumber > 11 && randomNumber < 89)
        {
            //deactivates stash trigger collider, preventing further interaction
            isInteractable = false;
            stashRenderer.material.color = Color.red;
        }
    }
}
