using System.Collections.Generic;

namespace CircuitBuilder.InputReaders
{
    // Factory pattern
    public class InputReaderFactory
    {
        private Dictionary<string, IInputReader> _inputReaders;

        public InputReaderFactory()
        {
            _setInputReaders();
        }
        public IInputReader GetInputReader(string fileExtension)
        {
            return _inputReaders[fileExtension];
        }

        private void _setInputReaders()
        {
            _inputReaders = new Dictionary<string, IInputReader>();

            _inputReaders[".txt"] = new TextFileReader();
        }
    }
}