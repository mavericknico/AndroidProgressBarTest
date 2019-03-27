using System.Collections;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour 
{
	void Start() 
    {
       StartCoroutine(Load());
	}

	IEnumerator Load()
    {
        UnityActivityIndicator.ShowActivityIndicator();
        yield return new WaitForSeconds(0);
    }
}
