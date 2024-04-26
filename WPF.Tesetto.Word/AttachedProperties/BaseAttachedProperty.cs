namespace WPF.Tesetto.Word
{
    public abstract class BaseAttachedProperty<TParent, TProperty>
        where TParent : new()
    {
        public static TParent Instance { get; private set; } = new TParent(); 
     }
}
