using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultDisplay;
    [SerializeField] private TextMeshProUGUI captionDisplay;
    [SerializeField] private float timeUntilTransition;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        GameManager.Loss += () => StartCoroutine(DisplayResult("You Lose", "There are no more ways to earn money"));
        GameManager.Win += () => StartCoroutine(DisplayResult("You Win", "You've reached your earning goal"));
    }

    private IEnumerator DisplayResult(string result, string caption)
    {
        resultDisplay.text = result;
        captionDisplay.text = caption;
        yield return new WaitForSeconds(timeUntilTransition);
        animator.enabled = true;
    }
}
