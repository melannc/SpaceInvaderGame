using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
   public GameObject MenuUI;
   public GameObject GameUI;

   public GameObject ingameobjects;

   private GameObject score;
   private GameObject lives;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MenuUI.SetActive(true);
        GameUI.SetActive(false);
        ingameobjects.SetActive(false);
    }


    public void StartGame()
    {
        MenuUI.SetActive(false);
        GameUI.SetActive(true); 
        ingameobjects.SetActive(true);
    }

    

}
