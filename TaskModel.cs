namespace TodoList.Models;

// Класс TaskModel представляет задачу с двумя свойствами: заголовок и статус выполнения
public class TaskModel
{
    public string Title { get; set; } // Заголовок задачи
    public bool IsCompleted { get; set; } // Статус выполнения задачи (выполнена или нет)
}