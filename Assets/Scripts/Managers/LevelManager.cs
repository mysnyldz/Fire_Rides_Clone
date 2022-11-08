using System;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using Enums;
using Signals;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serializefield Variables

        [SerializeField] private GameObject levelHolder;
        [SerializeField] private List<GameObject> levelList;

        #endregion

        #region Private Variables

        private GameObject _level;
        private const int levelLength = 160;

        #endregion

        #endregion


        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            LevelSignals.Instance.onNextlevel += OnGenerateNextLevel;
        }

        private void UnsubscribeEvents()
        {
            LevelSignals.Instance.onNextlevel -= OnGenerateNextLevel;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void Start()
        {
            Init();
        }
        private void Init()
        {
            GameObject level = Instantiate(Resources.Load<GameObject>("Level1"), levelHolder.transform);
            RandomizeLevel(level.transform.GetChild(1).transform);
            levelList.Add(level.transform.GetChild(1).gameObject);
        }

        private void OnGenerateNextLevel()
        {
            GameObject level =
                PoolSignals.Instance.onGetPoolObject?.Invoke(PoolType.Level.ToString(), levelHolder.transform);
            if (level != null)
            {
                RandomizeLevel(level.transform);
                level.transform.position = new Vector3(0, 0, levelLength) + levelList.Last().transform.position;
                levelList.Add(level);
            }

            RemoveBeforeLevel();
        }

        private void RemoveBeforeLevel()
        {
            if (levelList.Count <= 1)
            {
                return;
            }
            if (levelList.Count > 2)
            {
                ResetRandomizeLevel(levelList[0].transform);
                PoolSignals.Instance.onReleasePoolObject?.Invoke(PoolType.Level.ToString(),levelList[0].gameObject);
                levelList.RemoveAt(0);
                levelList.TrimExcess();
            }
        }

        private void RandomizeLevel(Transform level)
        {
            foreach (Transform ground in level.transform.GetChild(0))
            {
                ground.localPosition += new Vector3(0, Random.Range(-3, 5), 0);
            }

            foreach (Transform upper in level.transform.GetChild(1))
            {
                upper.localPosition += new Vector3(0, Random.Range(-3, 5), 0);
            }
        }

        private void ResetRandomizeLevel(Transform level)
        {
            foreach (Transform ground in level.transform.GetChild(0))
            {
                ground.localPosition = new Vector3(0, -29, ground.localPosition.z);
            }

            foreach (Transform upper in level.transform.GetChild(1))
            {
                upper.localPosition = new Vector3(0, 35, upper.localPosition.z);
            }
        }
    }
}