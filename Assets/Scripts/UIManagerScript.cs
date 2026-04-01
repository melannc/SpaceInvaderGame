using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
   public GameObject MenuUI;
   public GameObject GameUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MenuUI.SetActive(true);
        GameUI.SetActive(false);
    }

    // Update is called once per frame
    public void StartGame()
    {
        MenuUI.SetActive(false);
        GameUI.SetActive(true); 
    }
}
