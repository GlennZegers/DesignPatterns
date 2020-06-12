using System.Collections.Generic;

namespace CircuitBuilder.InputReaders
{
    // Factory pattern
    public class InputReaderFactory
    {
        public IInputReader GetInputReader(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".txt":
                    return new TextFileReader();
                default:
                    return null;
            }
        }
    }
}