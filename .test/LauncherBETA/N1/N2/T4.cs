using N1.N3;
using N1.N3.N5;

namespace N1.N2
{
    public class T4 : T5
    {
        public T4() : this(new T14())
        {
        }

        public T4(T14 parserConfiguration) : base((T16) parserConfiguration)
        {
        }

        public T14 P23
        {
            get => (T14) base.P24;
            set => this.P24 = (T16) value;
        }

        protected override void HandleDuplicatedKeyInCollection(string key, string value, T9 keyDataCollection, string sectionName)
        {
            keyDataCollection.set_Item(key, keyDataCollection.get_Item(key) + this.P23.P47 + value);
        }
    }
}
