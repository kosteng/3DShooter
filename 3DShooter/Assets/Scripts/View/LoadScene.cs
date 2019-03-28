using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModelGame 
{
	public class LoadScene : MonoBehaviour 
	{
        [SerializeField] private int _loadLevel;

        public void LoadLevel (int loadLevel)
        {
            Application.LoadLevel(loadLevel);
        }
	
	
	}
}
