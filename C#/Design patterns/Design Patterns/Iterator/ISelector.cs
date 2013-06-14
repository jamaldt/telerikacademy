namespace Iterator
{
    using System;

    public interface ISelector
    {
        bool End();
        Object Current();
        void Next();
    }
}
