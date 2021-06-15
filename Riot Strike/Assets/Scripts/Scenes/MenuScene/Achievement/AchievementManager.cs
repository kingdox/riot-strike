﻿#region Access
using System;
using UnityEngine;
using XavHelpTo.Change;
using XavHelpTo.Set;
using AchievementRefresh;
#endregion

namespace MenuScene
{

    /// <summary>
    /// Loads the json and then check if the saved data surpass the requirements to set a check
    /// in <see cref="Environment.Scenes.MENU_SCENE"/>
    /// </summary>
    public class AchievementManager : MonoBehaviour
    {
        #region Variable
        [Header("Achievement Manager")]
        public Transform tr_parent_achievements;
        public GameObject pref_achievementItem;


        #endregion
        #region Events
        private void Start()
        {
            SavedData saved = DataSystem.Get;
            GenerateAchievements(ref saved);
        }
        #endregion
        #region Methods


        /// <summary>
        /// Creates the acheivements
        /// </summary>
        private void GenerateAchievements(ref SavedData saved)
        {

            if (!saved.achievementsPoints.Length.Equals(AchievementQty))
            {
                //Set the new length
                saved.achievementsPoints = Set.Length(in saved.achievementsPoints, AchievementQty);
                DataSystem.Set(saved);
            }

            for (int i = 0; i < AchievementQty; i++) CreateAchievement(in Environment.Data.ACHIEVEMENTS[i], saved.achievementsPoints[i]);
        }

        /// <summary>
        /// Create a achievement
        /// </summary>
        private void CreateAchievement(in AchievementData achievement, int pts){
            if (!achievement.ENABLED) return; //hides the achievement

            RefreshController _refresh = RefreshController
                .CreateRefresh(in pref_achievementItem, in tr_parent_achievements);

            bool isDone = pts >= achievement.REQUIREMENT;

            _refresh.RefreshImgColor(RefreshImage.ICON, new Color(1, 1, 1, isDone.ToInt()));

            _refresh.Translate(RefreshText.NAME, achievement.NAME);
            _refresh.Translate(RefreshText.DESCRIPTION, achievement.DESCRIPTION);
        }

        /// <summary>
        /// Qty of achievements
        /// </summary>
        private int AchievementQty => Environment.Data.ACHIEVEMENTS.Length;
        #endregion
    }
}



