using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvisibleEvent : MonoBehaviour 
{
	public UnityEvent OnInvisible;

	void OnBecameInvisible()
    {
		OnInvisible.Invoke();
    }
	
}
