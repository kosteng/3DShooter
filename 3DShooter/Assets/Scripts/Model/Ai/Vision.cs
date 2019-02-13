﻿using UnityEngine;
namespace ModelGame
{
    [System.Serializable]
    public class Vision
    {
        /// <summary>
        /// Радиус вокруг бота его обноружения цели
        /// </summary>
        public float ActiveDis = 10;

        /// <summary>
        /// Угол зрения бота
        /// </summary>
        public float ActiveAng = 35;

        /// <summary>
        /// Проверка сможем мы атаковать врага
        /// </summary>
        /// <param name="player"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool VisionM(Transform player, Transform target)
        {
            return Dist(player, target) && Angle(player, target) && !CheckBloked(player, target);

        }
        /// <summary>
        /// Проверка на преграду между ботом и целью для атаки
        /// </summary>
        /// <param name="player"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool CheckBloked (Transform player, Transform target)
        {
            if (!Physics.Linecast(player.position, target.position, out var hit)) return true;
            return hit.transform != target;
        }

        /// <summary>
        /// Метод проверят есть ли в поле зрения враг
        /// </summary>
        /// <param name="player"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool Angle (Transform player, Transform target)
        {
            var angle = Vector3.Angle(player.forward, target.position - player.position);
            return angle <= ActiveAng;
        }

        /// <summary>
        /// Метод проверяет есть ли рядом враг
        /// </summary>
        /// <param name="player"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool Dist (Transform player, Transform target)
        {
            var dist = Vector3.Distance(player.position, target.position);
            return dist <= ActiveDis;
        }
    }
}
/*
using UnityEngine;

namespace ModelGame
{
    [System.Serializable]
    public class Vision
    {
        public float ActiveDis = 10;
        public float ActiveAng = 35;

        public bool VisionM(Transform player, Transform target)
        {
            return Dist(player, target) && Angle(player, target) && !CheckBloked(player, target);
        }

        private bool CheckBloked(Transform player, Transform target)
        {
            if (!Physics.Linecast(player.position, target.position, out var hit)) return true;
            return hit.transform != target;
        }

        private bool Angle(Transform player, Transform target)
        {
            var angle = Vector3.Angle(player.forward, target.position - player.position);
            return angle <= ActiveAng;
        }

        private bool Dist(Transform player, Transform target)
        {
            // (pos1 - pos2).magnitude
            var dist = Vector3.Distance(player.position, target.position);
            return dist <= ActiveDis;
        }
    }
}*/