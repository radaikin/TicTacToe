public interface IControllerSubject
{
    void Attach(IControllerObserver observer);
    void Detach(IControllerObserver observer);
    void Notify(int cellNumber);

}
