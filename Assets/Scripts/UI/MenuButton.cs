using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] public int thisIndex;


    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		if(menuButtonController.index == thisIndex)
		{
			Over(true);
			if(Input.GetAxis ("Submit") == 1)
			{
				Click(true);
			}
			else if (animator.GetBool ("pressed"))
			{
				Click(false);
				animatorFunctions.disableOnce = true;
			}
		}

		else
		{
			Over(false);
		}	
    }

    public void Over(bool state)
    {
		animator.SetBool("selected", state);
	}

    public void Click(bool state)
    {
		animator.SetBool("pressed", state);
	}


}
