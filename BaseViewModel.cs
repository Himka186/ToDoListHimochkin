using System.ComponentModel; 
using System.Runtime.CompilerServices; 

namespace TodoList.ViewModels;

// Базовый класс для всех ViewModel, который реализует интерфейс INotifyPropertyChanged.
public class BaseViewModel : INotifyPropertyChanged
{
    // Событие для уведомления об изменении свойства
    public event PropertyChangedEventHandler PropertyChanged;

    // Метод для вызова события изменения свойства.
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); // Проверка и вызов события
    }

    // Метод для установки значения свойства с проверкой на изменение.
    // Если значение не изменилось, метод ничего не делает.
    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false; // Если значения равны, не делаем изменений
        field = value; // Установка нового значения
        OnPropertyChanged(propertyName); // Уведомляем об изменении свойства
        return true; // Возвращаем true, если свойство было изменено
    }
}