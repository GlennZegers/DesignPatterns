using System;

namespace CircuitBuilder
{
    public class Application
    {
        private InputParser _inputParser;
        private Circuit _circuit;
        private IView _view;

        public Application(IView view)
        {
            _view = view;
        }
        
        public void StartNewCircuit()
        {
            _inputParser = new InputParser(_view);
            _inputParser.ParseInput();
            
            _circuit = new Circuit();
            var ports = _inputParser.GetPorts();
            _circuit.Start(ports);
            
            _view.RenderOutputs(ports);
            
            _view.UserMakesNextMove(this);
        }

        public void ReGenerateCircuit()
        {
            _inputParser.ParseInput();
            
            var ports = _inputParser.GetPorts();
            _circuit.Start(ports);
            
            _view.RenderOutputs(ports);
            
            _view.UserMakesNextMove(this);
        }

        public InputParser GetInputParser()
        {
            if (_inputParser == null)
            {
                return _inputParser = new InputParser(_view);
            }

            return _inputParser;
        }
        
    }
}