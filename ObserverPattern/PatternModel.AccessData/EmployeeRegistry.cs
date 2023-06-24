using PatternModel.Shared;
using PatternModel.Shared.Models;

namespace PatternModel.AccessData
{
    public class EmployeeRegistry : IObservable<Employee>
    {
        private static EmployeeRegistry? instance;
        private List<IObserver> observers = new List<IObserver>();
        private List<Employee> employees;

        private EmployeeRegistry()
        {
            observers = new List<IObserver>();
            employees = new List<Employee>();
        }

        public static EmployeeRegistry GetInstance()
        {
            if (instance == null)
            {
                instance = new EmployeeRegistry();
            }

            return instance;
        }

        public bool InsertEmployee(Employee employee)
        {
            employees.Add(employee);
            NotifyObservers(employee);
            return true;
        }

        public IDisposable Subscribe(IObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            return new Unsubscriber(observers, observer);
        }

        public IDisposable Subscribe(IObserver<Employee> observer)
        {
            throw new NotImplementedException();
        }

        private void NotifyObservers(Employee employee)
        {
            foreach (var observer in observers)
            {
                observer.Update(employee);
            }
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver> _observers;
            private IObserver _observer;

            public Unsubscriber(List<IObserver> observers, IObserver observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                {
                    _observers.Remove(_observer);
                }
            }
        }
    }
}
