using System.Collections.ObjectModel; 
using System.Windows.Input; 
using TodoList.Models; 

namespace TodoList.ViewModels;

// Класс TaskViewModel наследуется от BaseViewModel, что позволяет использовать уведомления об изменении свойств
public class TaskViewModel : BaseViewModel
{
    // Список задач, привязанный к ListView в XAML
    public ObservableCollection<TaskModel> Tasks { get; set; } = new();

    // Свойство для ввода нового заголовка задачи
    private string _newTaskTitle;
    public string NewTaskTitle
    {
        get => _newTaskTitle;
        set => SetProperty(ref _newTaskTitle, value); // Устанавливаем значение с уведомлением об изменении
    }

    // Команды для добавления и удаления задач
    public ICommand AddTaskCommand { get; }
    public ICommand RemoveTaskCommand { get; }

    // Конструктор, инициализирующий команды
    public TaskViewModel()
    {
        AddTaskCommand = new Command(AddTask); // Команда для добавления задачи
        RemoveTaskCommand = new Command<TaskModel>(RemoveTask); // Команда для удаления задачи
    }

    // Метод для добавления новой задачи в список
    private void AddTask()
    {
        if (!string.IsNullOrWhiteSpace(NewTaskTitle)) // Проверка на пустое или пробельное значение
        {
            // Добавляем задачу в список и очищаем поле ввода
            Tasks.Add(new TaskModel { Title = NewTaskTitle, IsCompleted = false });
            NewTaskTitle = string.Empty; // Очищаем поле ввода
        }
    }

    // Метод для удаления задачи из списка
    private void RemoveTask(TaskModel task)
    {
        if (task != null) // Если задача не null, удаляем её
            Tasks.Remove(task);
    }
}