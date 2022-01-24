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
        /// Variable <c>_filenameLevel</c> enthealt den Namen der Datei fuer LevelStatusSpeicherung
        /// </summary>
        [SerializeField] private string _filenameLevel;

        /// <summary>
        /// Variable <c>_filenameSettings</c> enthealt den Namen der Datei fuer SettingsSpeicherung
        /// </summary>
        [SerializeField] private string _filenameSettings;

        /// <summary>
        /// Variable <c>_entries</c> enthealt die gelesenen oder zuschreibenen LevelStatusInformationen
        /// </summary>
        private List<LevelEntry> _entries;

        /// <summary>
        /// Variable <c>_levels</c> enhaelt die alle Level-Informationen
        /// </summary>
        private List<Level> _levels;

        /// <summary>
        /// Variable <c>_soundVolume</c> enhaelt die Lautstaerke der normalen Sounds (0-1)
        /// </summary>
        private float _soundVolume;
        
        /// <summary>
        /// Variable <c>_backgroundVolume</c> enhaelt enhaelt die Lautstaerke der Hintergrundmusik (0-1)
        /// </summary>
        private float _backgroundVolume;

        /// <summary>
        /// Variable <c>_settings</c> enthealt die zuschreibenen SettingsInformationen
        /// </summary>
        private List<Settings> _settings;

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
            _entries = new List<LevelEntry>();
            _settings = new List<Settings>();
            _filenameLevel = "towerdefense.json";
            _filenameSettings = "towerdefenseSettings.json";

            _backgroundVolume = GameValues.BackgroundInitialVolume;
            _soundVolume = GameValues.SoundsInitialVolume;

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
        }

        /// <summary>
        /// Lead die LevelStatusInformationen aus externer Datei falls vorhanden
        /// </summary>
        public void LoadLevelStatus() {
            _entries = FileHandler.ReadListFromJSON<LevelEntry>(_filenameLevel);

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

            FileHandler.SaveToJSON<LevelEntry>(_entries, _filenameLevel);
        }

        /// <summary>
        /// Lead die SettingsInformationen aus externer Datei falls vorhanden
        /// </summary>
        public void LoadSettings() {
            _settings = FileHandler.ReadListFromJSON<Settings>(_filenameSettings);
            if(_settings.Count == 1) {
                _backgroundVolume = _settings[0].volumeBackground;
                _soundVolume = _settings[0].volumeSounds;
            }
            
        }

        /// <summary>
        /// Speichert die SettingsInformationen in externer Datei
        /// </summary>
        public void SaveSettings() {
            _settings.Clear();
            _settings.Add(new Settings(_backgroundVolume, _soundVolume));
            FileHandler.SaveToJSON<Settings>(_settings, _filenameSettings);
        }

        /// <summary>
        /// enhaelt die alle Level-Informationen
        /// </summary>
        public List<Level> Levels => _levels;

        /// <summary>
        /// enhaelt die Lautstaerke der normalen Sounds (0-1)
        /// </summary>
        public float SoundVolume {
            get => _soundVolume;
            set => _soundVolume = value;
        }

        /// <summary>
        /// Venhaelt enhaelt die Lautstaerke der Hintergrundmusik (0-1)
        /// </summary>
        public float BackgroundVolume {
            get => _backgroundVolume;
            set => _backgroundVolume = value;
        }
    }
}