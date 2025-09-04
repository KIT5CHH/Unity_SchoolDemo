using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fadescreen : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float TimeToChange;
   
    void Update()
    {
        //start.onClick.AddListener(OnStartButtonClick);
      
    }
    public void OnStartButtonClick()
    {
        StartCoroutine(LoadLevel(0));
    }
    public void OnCardSceneClick()
    {
        StartCoroutine(LoadLevel(2));
    }
    public void OnMainSceneClick()
    {
        StartCoroutine(LoadLevel(1));
    }
    IEnumerator LoadLevel(int LevelIndex)
    {
        animator.SetTrigger("change");
        yield return new WaitForSeconds(TimeToChange);
        SceneManager.LoadScene(LevelIndex);
    }
}
