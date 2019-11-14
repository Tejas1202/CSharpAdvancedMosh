namespace CsharpAdvancedMosh.Generics.Constraints
{
    //Constraint : Value type (As value types like int, float etc. cannot be null, this constraint gives the ability to assign them null values also)
    public class Nullable<T> where T : struct
    {
        private object _value;

        public Nullable()
        {

        }

        public Nullable(T value)
        {
            _value = value;
        }

        public bool HasValue
        {
            get { return _value != null; }
        }

        public T GetValueOrDefault()
        {
            if (HasValue)
                return (T)_value;

            return default(T);
        }
    }
}
