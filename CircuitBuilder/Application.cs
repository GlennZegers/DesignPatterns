using CircuitBuilder.Views;

namespace CircuitBuilder
{
    public class Application
    {
        private InputParser _inputParser;
        private Circuit _circuit;
        private FileInput _fileInput;
        private IConsoleView _consoleView;

        public Application()
        {
            _fileInput = new FileInput();
            _consoleView = new ConsoleView();
        }
        
        // Generates a whole new circuit with new file
        public void StartNewCircuit()
        {
            _inputParser = new InputParser(_fileInput);
            _inputParser.ParseInput();
            
            _circuit = new Circuit();
            var ports = _inputParser.GetPorts();
            _circuit.Start(ports);
            
            _consoleView.Print(ports, this);
        }

        // Regenerates current circuit with changed input nodes
        public void ReGenerateCircuit()
        {
            _inputParser.ParseInput();
            
            var ports = _inputParser.GetPorts();
            _circuit.Start(ports);
            
            _consoleView.Print(ports, this);
        }

        // Singleton pattern
        public InputParser GetInputParser()
        {
            if (_inputParser == null)
            {
                return _inputParser = new InputParser(_fileInput);
            }

            return _inputParser;
        }
        
    }
}