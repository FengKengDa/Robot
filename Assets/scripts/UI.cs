using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public car myCar;

    public Button astarButton;
    public Button bfsButton;

    public Slider kVal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getPathByAStar()
    {
        Node.setK(kVal.value);
        myCar.getPathByAStar();
        bfsButton.interactable = false;
        astarButton.interactable = false;
    }

    public void getPathByBFS()
    {
        myCar.getPathByBFS();
        bfsButton.interactable = false;
        astarButton.interactable = false;
    }

    public void ReloadSence()
    {
        SceneManager.LoadScene(0);
    }
}
