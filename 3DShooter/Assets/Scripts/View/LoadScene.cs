using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ModelGame 
{
	public class LoadScene : MonoBehaviour 
	{
        [SerializeField] private int _loadLevel;

        public void LoadLevel (int loadLevel)
        {
            SceneManager.LoadScene(loadLevel);
        }

        public void LoadSave()
        {
        
          
        }
	
	}
}
