namespace BlazingBlog.State
{
    public class BlogStateService
    {
        public event Action? OnStateChanged;
        public void NotifyStateChanged() => OnStateChanged?.Invoke();
    }
}
