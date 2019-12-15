using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public bool tutorialStatus = true;
    public Toggle checkbox;
    public int tutorialState = 1;
    public GameObject tutorial1;
    public GameObject tutorial2;
    public GameObject tutorial3;
    public GameObject tutorial4;
    public GameObject tutorialPanel;
    // Start is called before the first frame update
    void Start()
    {
        if(tutorialStatus == true){
            tutorialPanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(checkbox.isOn && tutorialStatus == true){
            tutorialStatus = false;
            Debug.Log("on");
        }else if(!checkbox.isOn && tutorialStatus == false){
            tutorialStatus = true;
            Debug.Log("off");
        }
    }

    public void dontShow()
    {
        
        
    }

    public void nextTutorial()
    {
        if(tutorialState == 1){
            tutorial1.SetActive(false);
            tutorial2.SetActive(true);
            tutorialState = 2;
        }else if(tutorialState == 2){
            tutorial2.SetActive(false);
            tutorial3.SetActive(true);
            tutorialState = 3;
        }else if(tutorialState == 3){
            tutorial3.SetActive(false);
            tutorial4.SetActive(true);
            tutorialState = 4;
        }
    }

    public void prevTutorial()
    {
        if(tutorialState == 2){
            tutorial1.SetActive(true);
            tutorial2.SetActive(false);
            tutorialState = 1;
        }else if(tutorialState == 3){
            tutorial2.SetActive(true);
            tutorial3.SetActive(false);
            tutorialState = 2;
        }else if(tutorialState == 4){
            tutorial3.SetActive(true);
            tutorial4.SetActive(false);
            tutorialState = 3;
        }
    }

    public void okButton()
    {
        StartCoroutine(animDelay());
    }

    public void showTutorial()
    {
        if(tutorialStatus == true){
            tutorialPanel.SetActive(true);
        }
    }

    public IEnumerator animDelay()
    {
        tutorialPanel.GetComponent<AnimManager>().DestroyAnim();
        yield return new WaitForSeconds(1.5f);
        tutorialPanel.SetActive(false);
    }
}
