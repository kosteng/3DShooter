
using UnityEngine;
using UnityEditor;

namespace ModelGame 
{
    [CustomEditor(typeof(GenerateObject))]
	public class TestEditor : Editor 
	{
        //private GenerateObject _generate;
        
        public override void OnInspectorGUI()
        {

            base.OnInspectorGUI();

            if (GUILayout.Button("Создать предметы"))
            {
                GenerateObject _generate = (GenerateObject) target;
                _generate.GetGenerateObject();
            }
        }

    }
}
