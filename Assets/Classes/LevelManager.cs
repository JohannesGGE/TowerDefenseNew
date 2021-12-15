using System.Collections.Generic;
using static Classes.Birds;

namespace Classes {
    public class LevelManager {
        private static LevelManager _instance;
        private List<Level> _levels;

        public static LevelManager GetInstance() {
            if(_instance == null) {
                _instance = new LevelManager();
            }

            return _instance;
        }

        private LevelManager() {
            _levels = new List<Level>();
            SetLevelConfig();
        }

        //Evt. bessere Implementierung möglich 
        private void SetLevelConfig() {
            Wave wave1 = new Wave(new[] {Small, Small, Small, Small});
            Wave wave2 = new Wave( new [] {Small, Medium, Small, Medium});
            Level level1 = new Level(new []{wave1, wave2});
            
            wave1 = new Wave(new[] {Small, Small, Small, Small});
            wave2 = new Wave( new [] {Small, Medium, Small, Medium});
            Wave wave3 = new Wave( new [] {Small, Medium, Small, Medium, Small, Medium, Small, Medium});
            Level level2 = new Level(new []{wave1, wave2, wave3});

            _levels.Add(level1);
            _levels.Add(level2);
        }
        
        public List<Level> Levels => _levels;
    }
}