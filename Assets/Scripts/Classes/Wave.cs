using UnityEngine;

namespace Classes {
    
    /// <summary>
    /// Klasse <c>Wave</c> enthaelt die Wellen-Informationen fuer eine Welle
    /// </summary>
    public class Wave {

        /// <summary>
        /// Variable <c>_birds</c> enthaelt die Voegel der Welle
        /// </summary>
        private BirdLevel[] _birds;
        
        /// <summary>
        /// Variable <c>_spawnRate</c> enthaelt zu spawnenden Voegeln pro Sekunde
        /// </summary>
        private float _spawnRate;
        
        /// <summary>
        /// Konstruktor, setzt die Uebergebenen Voegel
        /// </summary>
        /// <param name="birds">zu setzende Voegel</param>
        /// <param name="spawnRate">wie viele pro Sekunde</param>
        public Wave(BirdLevel[] birds, float spawnRate) {
            _birds = birds;
            _spawnRate = spawnRate;
        }

        /// <summary>
        /// enthaelt die Zeit zwischen zwei zu spawnenden Voegeln
        /// </summary>
        public float SpawnRate => _spawnRate;

        /// <summary>
        /// enthaelt zu spawnenden Voegeln pro Sekunde
        /// </summary>
        public BirdLevel[] Birds => _birds;
    }
}