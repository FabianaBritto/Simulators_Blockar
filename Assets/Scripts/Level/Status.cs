using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public class Status : MonoBehaviour
    {
        private readonly List<Constants.Levels> availableLevels = new();
        public static Status Instance;

        private void Awake()
        {
            if (Instance) Destroy(gameObject);
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }

            UnlockLevel(Constants.Levels.Forest_01);
        }

        public void UnlockLevel(Constants.Levels level)
        {
            availableLevels.Add(level);
        }

        public bool IsAvailableLevel(Constants.Levels level)
        {
            return availableLevels.Contains(level);
        }
    }
}
