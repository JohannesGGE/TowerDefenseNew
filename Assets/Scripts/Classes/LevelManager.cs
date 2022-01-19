using System.Collections.Generic;
using UnityEngine;
using static Classes.BirdLevel;

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
        /// Variable <c>_filename</c> enthealt den Namen der Datei fuer LevelStatusSpeicherung
        /// </summary>
        [SerializeField] private string _filename;

        /// <summary>
        /// Variable <c>_entries</c> enthealt die gelesenen oder zuschreibenen LevelStatusInformationen
        /// </summary>
        private List<LevelEntry> _entries;

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
            _entries = new List<LevelEntry> ();
            _filename = "towerdefense.json";
            SetLevelConfig();
        }

        /// <summary>
        /// Configuriert die Level und fuellt <c>_levels</c>
        /// </summary>
        private void SetLevelConfig() {
            _levels.Add(GameValues.GetLevel1());
            _levels.Add(GameValues.GetLevel2());
            _levels.Add(GameValues.GetLevel3());
            _levels.Add(GameValues.GetLevel4());
            _levels.Add(GameValues.GetLevel5());
            _levels.Add(GameValues.GetLevel6());
            _levels.Add(GameValues.GetLevel7());
            _levels.Add(GameValues.GetLevel8());
            _levels.Add(GameValues.GetLevel9());
            _levels.Add(GameValues.GetLevel10());
        }

        /// <summary>
        /// Lead die LevelStatusInformationen aus externer Datei falls vorhanden
        /// </summary>
        public void LoadLevelStatus() {
            _entries = FileHandler.ReadListFromJSON<LevelEntry> (_filename);
            
            if(_entries.Count == _levels.Count) {
                for(int i = 0; i < _levels.Count; i++) {
                    _levels[i].Unlocked = _entries[i].unlocked;
                    _levels[i].Stars = _entries[i].stars;
                }
            }
        }

        /// <summary>
        /// Speichert die LevelStatusInformationen in externer Datei
        /// </summary>
        public void SaveLevelStatus() {
            _entries.Clear();
            foreach(Level level in _levels) {
                _entries.Add(new LevelEntry(level.Unlocked, level.Stars));
            }
            FileHandler.SaveToJSON<LevelEntry> (_entries, _filename);
        }
        
        /// <summary>
        /// enhaelt die alle Level-Informationen
        /// </summary>
        public List<Level> Levels => _levels;
    }
}