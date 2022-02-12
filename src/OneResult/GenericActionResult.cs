namespace OneResult
{
    public sealed class ActionResult<T>:ActionResult
    {
        public T Data { get;private set; }
        public static ActionResult<T> Success(T data)
        {
            return new ActionResult<T>() { Successed = true ,Data=data};
        }
    }
}
