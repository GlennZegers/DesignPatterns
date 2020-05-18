namespace CircuitBuilder
{
    public interface IView
    {
        void Render();
        void RenderPort();
        void RenderOutput();
        string GetInputFromUser();
    }
}