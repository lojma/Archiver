
namespace Archiver
{
    /// <summary>
    /// Класс содержаший все строки(сообщения исключений, ответы на пользовательские действия)
    /// </summary>
    public static class Strings
    {
       public readonly static string ioExp = "Ошибка чтения файла";
       public readonly static string archivatingComplete = "Файлы успешно записаны в архив ";
       public readonly static string typeAccessExc = "Попытка чтения, записи файла закрытого доступа";
       public readonly static string nullRefExp = "Параметр имеет значение null";
       public readonly static string fileNotFoundExp = "Данный файл не был найден";
       public readonly static string fileLoadExp = "Загрузка данного файла вызвала ошибку";
       public readonly static string endOfStreamExp = "Попытка прочтения потока за пределами файла";
       public readonly static string argExp = "Ошибка аргумента";
       public readonly static string dirNotFoundExp = "Директорию не удалось найти, проверьте существует ли она";
       public readonly static string notSupExp = "Непредвиденая ошибка.";
    }
}
