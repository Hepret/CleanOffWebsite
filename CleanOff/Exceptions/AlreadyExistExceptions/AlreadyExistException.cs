namespace CleanOff.Exceptions.AlreadyExistExceptions;

public class AlreadyExistException<T> : ArgumentException
{
    protected readonly T _item; // Обьект, который уже существует в базе данных
    
    public AlreadyExistException(T item)
    {
        _item = item;
    }

    public override string Message => $"{_item!.ToString()} уже существует в базе данных";
}

