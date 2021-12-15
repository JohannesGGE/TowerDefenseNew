using System.Collections.Generic;
using static Classes.Birds;

namespace Classes {
    
    /// <summary>
    /// Klasse <c>LevelManager</c> ist Singleton und dient der Datenverwaltung im Menue
    /// </summary>
    public class LevelManager {
        
        /// <summary>
        /// Variable <c>_instance</c> ist das Objekt der Klasse <c>LevelManager</c>
        /// </summary>
        private static LevelManager _instance;
        
        /// <summary>
        /// Variable <c>_levels</c> enhaelt die alle Level-Informationen
        /// </summary>
        private List<Level> _levels;

        /// <summary>
        /// Erstellt das <c>LevelManager</c> Objekt falls null
        /// </summary>
        /// <returns>Das <c>LevelManager</c> Objekt</returns>
        public static LevelManager GetInstance() {
            if(_instance == null) {
                _instance = new LevelManager();
            }

            return _instance;
        }

        /// <summary>
        /// Konstruktor, configuriert die Level und fuellt <c>_levels</c>
        /// </summary>
        private LevelManager() {
            _levels = new List<Level>();
            SetLevelConfig();
        }

        /// <summary>
        /// Configuriert die Level und fuellt <c>_levels</c>
        /// </summary>
        private void SetLevelConfig() {
            //Evt. bessere Implementierung möglich 
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
        
        /// <summary>
        /// enhaelt die alle Level-Informationen
        /// </summary>
        public List<Level> Levels => _levels;
    }
}