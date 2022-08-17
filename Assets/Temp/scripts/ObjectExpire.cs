using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	public class ObjectExpire : MonoBehaviour

	{

		public float seconds = 5;

		void Start ()
		{
			Destroy (gameObject, seconds);
		}

	}