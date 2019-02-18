using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ModelGame
{
    [ExecuteInEditMode]
    public class GenerateObject : MonoBehaviour
    {
        private GameObject _levelSize;
        /// <summary>
        /// Максимальный размер по оси Х
        /// </summary>
        [SerializeField] private float _maxX;
        /// <summary>
        /// Максимальный размер по оси Z
        /// </summary>
        [SerializeField] private float _maxZ;
        /// <summary>
        /// Количество мин
        /// </summary>
        [SerializeField] private int _countMine;
        /// <summary>
        /// Количество аптечек
        /// </summary>
        [SerializeField] private int _countMedic;
        /// <summary>
        /// Префаб мины
        /// </summary>
       [SerializeField] private GameObject _mineObject;
        /// <summary>
        /// Префаб аптечки
        /// </summary>
       [SerializeField] private GameObject _medicObject;

        
        void Start()
        {
            _levelSize = GameObject.FindGameObjectWithTag("Ground");
            _maxX = _levelSize.transform.localScale.x;
            _maxZ = _levelSize.transform.localScale.z;


           


        }
        /// <summary>
        /// Публичный метод выдает сгенерированные объекты
        /// </summary>
        public void GetGenerateObject()
        {
            GeneratorObject(_mineObject, _countMine);
            GeneratorObject(_medicObject, _countMedic);
        }
        /// <summary>
        /// Метод генерации объекта
        /// </summary>
        /// <param name="gameObj"> объект который нужно создать</param>
        /// <param name="count">количество объектов</param>
        private void GeneratorObject(GameObject gameObj, int count )
        {
            for (int i=0; i<count; i++)
            {
                i++;
                Instantiate(gameObj, new Vector3(Random.Range(1, _maxX), 0.5f, Random.Range(1, _maxZ)), Quaternion.identity); //new Vector3(Random.Range(1,20),1,Random.Range(1, 20))
            }
        }



    }
    
}
