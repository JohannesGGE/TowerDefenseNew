namespace Classes {
    
    /// <summary>
    /// Klasse <c>Wave</c> enthaelt die Wellen-Informationen fuer eine Welle
    /// </summary>
    public class Wave {
        
        /// <summary>
        /// Variable <c>_birds</c> enthaelt die Voegel der Welle
        /// </summary>
        private Birds[] _birds;
        
        /// <summary>
        /// Konstruktor, setzt die Uebergebenen Voegel
        /// </summary>
        /// <param name="birds">zu setzende Voegel</param>
        public Wave(Birds[] birds) {
            _birds = birds;
        }
        
        /// <summary>
        /// enthaelt die Voegel der Welle
        /// </summary>
        public Birds[] Birds => _birds;
    }
}