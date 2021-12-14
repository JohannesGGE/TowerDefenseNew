namespace Classes {
    public class Wave {
        private Birds[] _birds;
        
        public Wave(Birds[] birds) {
            _birds = birds;
        }
        
        public Birds[] Birds => _birds;
    }
}